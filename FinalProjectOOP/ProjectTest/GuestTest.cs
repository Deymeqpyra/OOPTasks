using Application.Abstraction.Interfaces;
using Application.Abstraction.Queries;
using Application.Implementation.Exceptions.User;
using Application.Implementation.Manager;
using Domain.Guest;
using Domain.User;
using NSubstitute;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;
using ProjectTest.Data;

namespace ProjectTest
{
    public class GuestTestManager : BaseIntegrationTest, IAsyncLifetime
    {
        private readonly IUserManager _userManager;
        private readonly IUserRepository _userRepositoryMock;
        private readonly ILogger _loggerMock;
        private readonly User _guest;

        public GuestTestManager(IntegrationTestHostFactory factory) : base(factory)
        {
            _guest = UserData.GuestUser(); 
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _loggerMock = Substitute.For<ILogger>();
            _userManager = new UserManager(_userRepositoryMock, Substitute.For<IUserQueries>(), _loggerMock);
        }

        [Fact]
        public async Task ShouldCreateGuestUser()
        {
            // Arrange
            var name = "guestUser";
            var role = "Guest";
            DateTime dateTime = DateTime.UtcNow;

            User expectedUser = Guest.Create(UserId.New(), dateTime, name, role); 

            _userRepositoryMock.Create(Arg.Any<User>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(expectedUser));

            // Act
            var result = await _userManager.CreateUser(name, role, [dateTime], CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(name);
            result.Role.Should().Be(role);
        }

        [Fact]
        public async Task ShouldNotCreateGuestUserBecauseOfWrongRole()
        {
            // Arrange
            var name = "guestUser";
            var role = "InvalidRole";
            var additionalParams = new object[] { "additionalParam" };

            // Act 
            Func<Task> act = () => _userManager.CreateUser(name, role, additionalParams, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<UserFactoryNotFoundException>();
            _loggerMock.Received().ErrorMessage($"User type {role} was not found.", nameof(UserManager));
        }

        [Fact]
        public async Task ShouldNotCreateGuestUserBecauseOfEmptyName()
        {
            // Arrange
            var name = "";  
            var role = "Guest";
            var additionalParams = new object[] { "additionalParam" };

            // Act 
            Func<Task> act = () => _userManager.CreateUser(name, role, additionalParams, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<EmptyCrenditalsException>();
            _loggerMock.Received().ErrorMessage("Name and role and additional parameters are required.", nameof(name));
        }

        [Fact]
        public async Task ShouldDeleteGuestUser()
        {
            // Arrange
            var user = _guest;
            _userRepositoryMock.Delete(Arg.Any<User>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(user));

            // Act
            var result = await _userManager.DeleteUser(user, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);
            _loggerMock.Received().InfoMessage($"Deleted user with id: {user.Id}");
        }

        [Fact]
        public async Task ShouldNotDeleteGuestUserBecauseOfUnknownException()
        {
            // Arrange
            var user = _guest;
            _userRepositoryMock.Delete(Arg.Any<User>(), Arg.Any<CancellationToken>())
                .Throws(new Exception("Database error"));

            // Act
            Func<Task> act = () => _userManager.DeleteUser(user, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<UserUnknownException>();
            _loggerMock.Received()
                .ErrorMessage("While deleting user error message: Database error", nameof(UserManager));
        }

        public async Task InitializeAsync()
        {
            await Context.Users.AddAsync(_guest);
            await SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            Context.Users.RemoveRange(Context.Users);
            await SaveChangesAsync();
        }
    }
}
