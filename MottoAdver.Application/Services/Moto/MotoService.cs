using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.MappingFactories;
using MottoAdver.Domain;

namespace MottoAdver.Application.Services;
public partial class MotoService : IMotoService
{
    private readonly IMotoRepository motoRepository;
    public MotoService(IMotoRepository motoRepository)
        => this.motoRepository = motoRepository;

    public async ValueTask<MotoDto> CreateMotoAsync(CreationMotoDto moto)
    {
        ValidationMotoForCreationDto(creationMotoDto: moto);

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
        ValidationMotoId(motoId: id);

        var selectedByIdMoto = await this.motoRepository.SelectEntityByIdAsync(id);

        ValidationStorageMoto(moto: selectedByIdMoto, motoId: id);

        return MotoFactory.MapToMotoDto(selectedByIdMoto);
    }

    public async ValueTask<MotoDto> UpdateMotoAsync(ModifyMotoDto modifyMotoDto)
    {
        ValidationMotoForModifyDto(modifyMotoDto: modifyMotoDto);

        var selectedById = await this.motoRepository.SelectEntityByIdAsync(modifyMotoDto.id);

        ValidationStorageMoto(moto: selectedById, motoId: modifyMotoDto.id);

        MotoFactory.MapToMoto(modifyMotoDto, selectedById);

        var updatedMoto = await this.motoRepository.UpdateEntityAsync(selectedById);

        await this.motoRepository.SaveChangesAsync();

        var mappedMotoDto = MotoFactory.MapToMotoDto(updatedMoto);

        return mappedMotoDto;
    }

    public async ValueTask<MotoDto> DeleteMotoByIdAsync(Guid id)
    {
        var selectedByIdMoto = await this.motoRepository.SelectEntityByIdAsync(id);

        ValidationStorageMoto(moto: selectedByIdMoto, motoId: id);

        var deletedMoto = await this.motoRepository
            .DeleteEntityAsync(selectedByIdMoto);

        await this.motoRepository.SaveChangesAsync();

        var mappedMotoDto = MotoFactory.MapToMotoDto(deletedMoto);

        return mappedMotoDto;
    }
}