using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MotoAdd.Application.Services;

public interface IAddvertisementService
{
    ValueTask<AddvertisementDto> CreateAddvertisementAsync(
        CreationAddvertisementDto creationAddvertisementDto);

    IQueryable<AddvertisementDto> GetAllAddvertisements();

    ValueTask<AddvertisementDto> GetAddvertisementByIdAsync(
        Guid id);

    ValueTask<AddvertisementDto> UpdateAddvertisementAsync(
        ModifyAddvertisementDto modifyAddvertisementDto);

    ValueTask<AddvertisementDto> DeleteAddvertisementByIdAsync(
        Guid id);
}
