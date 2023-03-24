using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MotoAdd.Application.Services;

public interface IAddressService
{
    ValueTask<AddressDto> CreateAddressAsync(CreationAddressDto address);
    IQueryable<AddressDto> RetrieveAddress();
    ValueTask<AddressDto> RetrieveAddressByIdAsync(Guid addressId);
    ValueTask<AddressDto> ModifyAddressAsync(ModifyAddressDto address);
    ValueTask<AddressDto> RemoveAddressAsync(Guid addressId);
}
