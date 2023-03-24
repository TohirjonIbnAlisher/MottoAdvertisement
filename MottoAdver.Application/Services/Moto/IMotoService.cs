using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MotoAddver.Application.Services;

public interface IMotoService
{
    ValueTask<MotoDto> CreateMotoAsync(CreationMotoDto moto);

    IQueryable<MotoDto> GetAllMotos();

    ValueTask<MotoDto> GetMotoByIdAsync(Guid id);

    ValueTask<MotoDto> UpdateMotoAsync(ModifyMotoDto moto);

    ValueTask<MotoDto> DeleteMotoByIdAsync(Guid id);
}
