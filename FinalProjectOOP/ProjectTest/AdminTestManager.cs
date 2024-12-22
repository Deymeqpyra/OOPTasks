using Application.Abstraction.Interfaces;
using Application.Abstraction.Queries;
using Application.Implementation.Exceptions.User;
using Application.Implementation.Manager;
using Domain.Admin;
using Domain.User;
using NSubstitute;
using FluentAssertions;
using MediatR;
using NSubstitute.ExceptionExtensions;
using ProjectTest.Common;
using ProjectTest.Data;

namespace ProjectTest
{
    public class AdminTestManager : BaseIntegrationTest, IAsyncLifetime
    {
        private readonly IUserManager _userManager;
        private readonly IUserRepository _userRepositoryMock;
        private readonly ILogger _loggerMock;
        private readonly User _admin;

        public AdminTestManager(IntegrationTestHostFactory factory) : base(factory)
        {
            _admin = UserData.AdminUser();
            _userRepositoryMock = Substitute.For<IUserRepository>();
            _loggerMock = Substitute.For<ILogger>();
            _userManager = new UserManager(_userRepositoryMock, Substitute.For<IUserQueries>(), _loggerMock);
        }

        [Fact]
        public async Task ShouldCreateAdminUser()
        {
            // Arrange
            var name = "adminUser";
            var role = "Admin";
            string password = "password";

            User expectedUser = Admin.Create(UserId.New(), password, name, role);

            _userRepositoryMock.Create(Arg.Any<User>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(expectedUser));

            // Act
            var result = await _userManager.CreateUser(name, role, [password], CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(name);
            result.Role.Should().Be(role);
        }


        [Fact]
        public async Task ShouldNotCreateAdminUserBecauseOfWrongRole()
        {
            // Arrange
            var name = "adminUser";
            var role = "InvalidRole";
            var additionalParams = new object[] { "additionalParam" };

            // Act 
            Func<Task> act = () => _userManager.CreateUser(name, role, additionalParams, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<UserFactoryNotFoundException>();
            _loggerMock.Received().ErrorMessage($"User type {role} was not found.", nameof(UserManager));
        }

        [Fact]
        public async Task ShouldNotCreateAdminUserBecauseOfEmptyName()
        {
            // Arrange
            var name = "";
            var role = "Admin";
            var additionalParams = new object[] { "additionalParam" };

            // Act 
            Func<Task> act = () => _userManager.CreateUser(name, role, additionalParams, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<EmptyCrenditalsException>();
            _loggerMock.Received().ErrorMessage("Name and role and additional parameters are required.", nameof(name));
        }

        [Fact]
        public async Task ShouldDeleteUser()
        {
            // Arrange
            var user = _admin;
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
        public async Task ShouldNotDeleteUserBecauseOfUnknownException()
        {
            // Arrange
            var user = _admin;
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
            await Context.Users.AddAsync(_admin);
            await SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            Context.Users.RemoveRange(Context.Users);
            await SaveChangesAsync();
        }
    }
}