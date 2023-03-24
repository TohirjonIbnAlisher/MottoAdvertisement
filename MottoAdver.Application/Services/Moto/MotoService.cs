using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.MappingFactories;
using MottoAdver.Application.Services;
using MottoAdver.Domain;

namespace MotoAddver.Application.Services;

public class MotoService : IMotoService
{
    private readonly IMotoRepository motoRepository;
    public MotoService(IMotoRepository motoRepository)
        => this.motoRepository = motoRepository;

    public async ValueTask<MotoDto> CreateMotoAsync(CreationMotoDto moto)
    {
        var mappedMoto = MotoFactory.MapToMoto(moto);


        var cretedMoto = await this.motoRepository.PostEntityAsync(mappedMoto);

        ImagesService.SaveImage(moto.images,
            cretedMoto.Id.ToString(),
            "uz");

        await this.motoRepository.SaveChangesAsync();

        var mappedMotodDto = MotoFactory.MapToMotoDto(cretedMoto);

        return mappedMotodDto;
    }

    public IQueryable<MotoDto> GetAllMotos()
    {
        var allMoto = this.motoRepository.SelectAllEntity();

        return allMoto.Select(moto => MotoFactory.MapToMotoDto(moto));
    }

    public async ValueTask<MotoDto> GetMotoByIdAsync(Guid id)
    {
        var selectedByIdMoto = await this.motoRepository.SelectEntityByIdAsync(id);

        return MotoFactory.MapToMotoDto(selectedByIdMoto);
    }

    public async ValueTask<MotoDto> UpdateMotoAsync(ModifyMotoDto modifyMotoDto)
    {
        var selectedById = await this.motoRepository.SelectEntityByIdAsync(modifyMotoDto.id);

        MotoFactory.MapToMoto(modifyMotoDto, selectedById);

        var updatedMoto = await this.motoRepository.UpdateEntityAsync(selectedById);

        await this.motoRepository.SaveChangesAsync();

        var mappedMotoDto = MotoFactory.MapToMotoDto(updatedMoto);

        return mappedMotoDto;
    }
    public async ValueTask<MotoDto> DeleteMotoByIdAsync(Guid id)
    {
        var selectedByIdMoto = await this.motoRepository.SelectEntityByIdAsync(id);

        var deletedMoto = await this.motoRepository
            .DeleteEntityAsync(selectedByIdMoto);

        await this.motoRepository.SaveChangesAsync();

        var mappedMotoDto = MotoFactory.MapToMotoDto(deletedMoto);

        return mappedMotoDto;
    }
}
