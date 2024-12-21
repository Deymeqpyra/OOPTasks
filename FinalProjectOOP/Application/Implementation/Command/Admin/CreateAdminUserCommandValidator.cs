using FluentValidation;

namespace Application.Implementation.Command.Admin;

public class CreateAdminUserCommandValidator : AbstractValidator<CreateAdminUserCommand>
{
    public CreateAdminUserCommandValidator()
    {
        RuleFor(x=>x.Name).NotEmpty().MinimumLength(3).MaximumLength(30);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}