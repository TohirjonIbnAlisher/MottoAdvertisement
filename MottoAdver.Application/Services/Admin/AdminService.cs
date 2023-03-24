using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.MappingFactories;
using MottoAdver.Domain;

namespace MotoAdd.Application.Services;

public class AdminService : IAdminService
{
    private readonly IAdminRepository adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        this.adminRepository = adminRepository;
    }

    public async ValueTask<AdminDto> CreateAdminAsync(
        CreationAdminDto creationAdminDto)
    {
        var mappedAdmin = AdminFactory.MapToAdmin(creationAdminDto);

        var adminSelected = await adminRepository.PostEntityAsync(mappedAdmin);

        await adminRepository.SaveChangesAsync();

        return AdminFactory.MapToAdminDto(adminSelected);
    }

    public async ValueTask<AdminDto> ModifyAdminAsync(
        ModifyAdminDto modifyAdminDto)
    {
        var storageAdmin = await this.adminRepository.SelectEntityByIdAsync(modifyAdminDto.id);

        AdminFactory.MapToAdmin(modifyAdminDto, storageAdmin);

        var adminSelected = await adminRepository.UpdateEntityAsync(storageAdmin);

        await adminRepository.SaveChangesAsync();

        return AdminFactory.MapToAdminDto(adminSelected);
    }

    public async ValueTask<AdminDto> RemoveAdminAsync(Guid adminId)
    {
        var admin = await this.adminRepository
            .SelectEntityByIdAsync(adminId);

        var adminSelected = await adminRepository
            .DeleteEntityAsync(admin);

        await adminRepository.SaveChangesAsync();

        return AdminFactory.MapToAdminDto(adminSelected);
    }

    public async ValueTask<AdminDto> RetrieveAdminByIdAsync(Guid adminId)
    {
        var storageAdmin = await adminRepository
            .SelectEntityByIdAsync(adminId);

        return AdminFactory.MapToAdminDto(storageAdmin);
    }
    public IQueryable<AdminDto> RetrieveAdmins()
    {
        return adminRepository.SelectAllEntity()
            .Select(admin => AdminFactory.MapToAdminDto(admin));
    }

}
