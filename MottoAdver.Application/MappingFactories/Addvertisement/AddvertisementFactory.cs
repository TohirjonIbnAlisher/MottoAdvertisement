using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Application.MappingFactories;

internal static class AddvertisementFactory
{
    internal static Addvertisements MapToAdd(
        CreationAddvertisementDto creationAddvertisementDto,
        Guid addressId)
    {
        var add = new Addvertisements()
        {
            AddvertiserFullName = creationAddvertisementDto.addvertiserFullName,
            AddvertiserTelegramUserName = creationAddvertisementDto.addvertiserTelegramUserName,
            AddvertiserTellNumber = creationAddvertisementDto.addvertiserTellNumber,
            Price = creationAddvertisementDto.price,
            MotoId = creationAddvertisementDto.motoId,
            AddressId = addressId
        };

        return add;
    }

    internal static AddvertisementDto MapToAddDto(
        Addvertisements addvertisements)
    {
        var addDto = new AddvertisementDto(
            id: addvertisements.Id,
            addvertiserFullName: addvertisements.AddvertiserFullName,
            addvertiserTelegramUserName: addvertisements.AddvertiserTelegramUserName,
            addvertiserTellNumber: addvertisements.AddvertiserTellNumber,
            price: addvertisements.Price);

        return addDto;
    }

    internal static void MapToAdd(
        Addvertisements addvertisement,
        ModifyAddvertisementDto modifyAddvertisementDto)
    {
        addvertisement.AddvertiserFullName = modifyAddvertisementDto.addvertiserFullName 
            ?? addvertisement.AddvertiserFullName;

        addvertisement.AddvertiserTellNumber = modifyAddvertisementDto.addvertiserTellNumber 
            ?? addvertisement.AddvertiserTellNumber;

        addvertisement.AddvertiserTelegramUserName = modifyAddvertisementDto.addvertiserTelegramUserName
            ?? addvertisement.AddvertiserTelegramUserName;

        addvertisement.Price = modifyAddvertisementDto.price 
            ?? addvertisement.Price;

        addvertisement.MotoId = modifyAddvertisementDto.motoId 
            ?? addvertisement.MotoId;

        addvertisement.AddressId = modifyAddvertisementDto.addressId
            ?? addvertisement.AddressId;
    }
}
