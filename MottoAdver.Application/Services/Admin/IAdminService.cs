using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MotoAdd.Application.Services;

public interface IAdminService
{
    ValueTask<AdminDto> CreateAdminAsync(CreationAdminDto creationAdminDto);
    IQueryable<AdminDto> RetrieveAdmins();
    ValueTask<AdminDto> RetrieveAdminByIdAsync(Guid adminId);
    ValueTask<AdminDto> ModifyAdminAsync(ModifyAdminDto modifyAdminDto);
    ValueTask<AdminDto> RemoveAdminAsync(Guid adminId);
}
