using FluentValidation;

namespace Application.Implementation.Command.Guest;

public class CreateGuestUserCommandValidator : AbstractValidator<CreateGuestUserCommand>
{
    public CreateGuestUserCommandValidator()
    {
        RuleFor(x=>x.Name).Length(2,50).NotEmpty();
    }
}