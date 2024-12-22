using FluentValidation;

namespace Application.Implementation.Command.Guest;

public class DeleteGuestUserCommandValidator : AbstractValidator<DeleteGuestUserCommand>
{
    public DeleteGuestUserCommandValidator()
    {
        RuleFor(x=>x.UserId).NotEmpty();    
    }
}