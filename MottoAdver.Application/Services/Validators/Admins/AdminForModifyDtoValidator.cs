using FluentValidation;
using MottoAdver.Application.DataTransferObjects;

namespace MottoAdver.Application.Services.Validators.Admins;
public class AdminForModifyDtoValidator : AbstractValidator<ModifyAdminDto>
{
    public AdminForModifyDtoValidator()
    {
        RuleFor(admin => admin)
            .NotNull();

        RuleFor(admin => admin.id)
            .NotEqual(default(Guid));
    }
}
