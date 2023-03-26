using MotoAdd.Infastructure.Repositories;
using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Application.MappingFactories;
using MottoAdver.Domain;

namespace MotoAdd.Application.Services;

public partial class AddressService : IAddressService
{
    private readonly IAddressRepository addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        this.addressRepository = addressRepository;
    }

    public async ValueTask<AddressDto> CreateAddressAsync(
        CreationAddressDto creationAddressDto)
    {
        var mappedAddress = AddressFactory.MapToAddress(creationAddressDto);

        var addressSelected = await addressRepository
            .PostEntityAsync(mappedAddress);

        await addressRepository.SaveChangesAsync();

        var mappedAddressDto = AddressFactory.MapToAddressDto(mappedAddress);

        return mappedAddressDto;
    }

    public async ValueTask<AddressDto> ModifyAddressAsync(
        ModifyAddressDto modifyAddressDto)
    {
        var selectedAddressById = await this.addressRepository
            .SelectEntityByIdAsync(modifyAddressDto.id);

        AddressFactory.MapToAddress(
            modifyAddressDto, selectedAddressById);

        var updatedAddress = await addressRepository.UpdateEntityAsync(selectedAddressById);

        await addressRepository.SaveChangesAsync();

        var mappedAddressDto = AddressFactory.MapToAddressDto(updatedAddress);

        return mappedAddressDto;
    }

    public async ValueTask<AddressDto> RemoveAddressAsync(Guid addressId)
    {
        var address = await this.addressRepository.SelectEntityByIdAsync(addressId);

        var deletedAddress = await addressRepository
            .DeleteEntityAsync(address);

        await addressRepository.SaveChangesAsync();

        var mappedAddressDto = AddressFactory.MapToAddressDto(deletedAddress);

        return mappedAddressDto;
    }

    public async ValueTask<AddressDto> RetrieveAddressByIdAsync(Guid addressId)
    {
        var selectedAddressById = await addressRepository
            .SelectEntityByIdAsync(addressId);

        var mappedAddressDto = AddressFactory.MapToAddressDto(selectedAddressById);

        return mappedAddressDto;

    }

    public IQueryable<AddressDto> RetrieveAddress()
    {
        return addressRepository.SelectAllEntity().Select(
            address => AddressFactory.MapToAddressDto(address));
    }
}
