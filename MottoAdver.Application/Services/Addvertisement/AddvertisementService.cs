using Microsoft.EntityFrameworkCore;
using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.MappingFactories;
using MottoAdver.Domain;
using MottoAdver.Infastructure.DbContexts;
using System.Data;

namespace MotoAdd.Application.Services;

public class AddvertisementService : IAddvertisementService
{
    private readonly IAddvertisementRepository addvertisementRepository;
    private readonly IAddressService addressService;
    private readonly MottoAdverContext mottoAdverContext;

    public AddvertisementService(
        IAddvertisementRepository addvertisementRepository,
        IAddressService addressService,
        MottoAdverContext mottoAdverContext)
    {
        this.addvertisementRepository = addvertisementRepository;
        this.addressService = addressService;
        this.mottoAdverContext = mottoAdverContext;
    }

    public async ValueTask<AddvertisementDto> CreateAddvertisementAsync(
        CreationAddvertisementDto creationAddvertisementDto)
    {
        Addvertisements createdAdd = new Addvertisements();

        var executionStrategy = mottoAdverContext.Database.CreateExecutionStrategy();
        await executionStrategy.ExecuteAsync(async () =>
        {
            using (var transaction = mottoAdverContext.Database.BeginTransaction(
                IsolationLevel.Serializable))
            {
                try
                {
                    var storageAddress = await this.addressService.CreateAddressAsync(
                        creationAddvertisementDto.creationAddressDto);

                    var mappedAdd = AddvertisementFactory.MapToAdd(
                        creationAddvertisementDto: creationAddvertisementDto,
                        addressId: storageAddress.id);

                    createdAdd = await this.addvertisementRepository
                        .PostEntityAsync(mappedAdd);

                    await this.addvertisementRepository.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw ;
                }
            }
        });

        return AddvertisementFactory.MapToAddDto(createdAdd);
    }

    public async ValueTask<AddvertisementDto> UpdateAddvertisementAsync(
        ModifyAddvertisementDto modifyAddvertisementDto)
    {
        var selectedById = await this.addvertisementRepository
            .SelectEntityByIdAsync(modifyAddvertisementDto.id);

        AddvertisementFactory.MapToAdd(
            selectedById,
            modifyAddvertisementDto);

        var updateAdd = await this.addvertisementRepository
            .UpdateEntityAsync(selectedById);

        await this.addvertisementRepository.SaveChangesAsync();

        return AddvertisementFactory.MapToAddDto(updateAdd);
    }

    public async ValueTask<AddvertisementDto> GetAddvertisementByIdAsync(Guid id)
    {
        var selectedAddById = await this.addvertisementRepository
            .SelectEntityByExpressionAsync(
            add => add.Id == id,
            new string[] { "Moto", "Address" });

        return AddvertisementFactory.MapToAddDto(selectedAddById);
    }

    public IQueryable<AddvertisementDto> GetAllAddvertisements()
    {
        var allAdd = this.addvertisementRepository.SelectAllEntity();

        return allAdd.Select(add => AddvertisementFactory.MapToAddDto(add));
    }
    public async ValueTask<AddvertisementDto> DeleteAddvertisementByIdAsync(Guid id)
    { 
        var selectedAddById = await this.addvertisementRepository.SelectEntityByIdAsync(id);

        var deletedAdd = await this.addvertisementRepository.DeleteEntityAsync(selectedAddById);

        await this.addvertisementRepository.SaveChangesAsync();

        return AddvertisementFactory.MapToAddDto(deletedAdd);
    }

}
