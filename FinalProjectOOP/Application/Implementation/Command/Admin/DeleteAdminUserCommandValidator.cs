using FluentValidation;

namespace Application.Implementation.Command.Admin;

public class DeleteAdminUserCommandValidator : AbstractValidator<DeleteAdminUserCommand>
{
    public DeleteAdminUserCommandValidator()
    {
        RuleFor(x=>x.AdminId).NotEmpty();
    }
}