using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Application.MappingFactories;

internal static class AddressFactory
{
    internal static Addresses MapToAddress(
        CreationAddressDto creationAddressDto)
    {
        var storageAddress = new Addresses()
        {
            Country = creationAddressDto.country,
            District = creationAddressDto.country,
            Region = creationAddressDto.region,
            Street = creationAddressDto.street,
            PostalCode = creationAddressDto.postalCode,
        };

        return storageAddress;
    }

    internal static AddressDto MapToAddressDto(
        Addresses addresses)
    {
        var addressdDto = new AddressDto(
            id: addresses.Id,
            country: addresses.Country,
            region: addresses.Region,
            district: addresses.District,
            street: addresses.Street,
            postalCode: addresses.PostalCode);

        return addressdDto;
    }

    internal static void MapToAddress(
        ModifyAddressDto modifyAddressDto,
        Addresses addresses)
    {
        addresses.Country = modifyAddressDto.country ?? addresses.Country;
        addresses.Region = modifyAddressDto.region ?? addresses.Region;
        addresses.District = modifyAddressDto.district ?? addresses.District;
        addresses.Street = modifyAddressDto.street ?? addresses.Street;
        addresses.PostalCode = modifyAddressDto.postalCode ?? addresses.PostalCode;
    }
}
