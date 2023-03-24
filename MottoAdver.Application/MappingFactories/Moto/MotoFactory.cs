using MottoAdver.Application.DataTransferObjects;
using MottoAdver.Domain;

namespace MottoAdver.Application.MappingFactories;

internal static class MotoFactory
{
    internal static Motos MapToMoto(
        CreationMotoDto creationMotoDto)
    {
        var moto = new Motos()
        {
            MotoName = creationMotoDto.motoName,
            Charge = creationMotoDto.charge,
            DistanceFullCharge = creationMotoDto.distanceFullCharge,
            MaxSpeed = creationMotoDto.maxSpeed,
            MaxWeight = creationMotoDto.maxWeight,
            Year = creationMotoDto.year,
        };

        return moto; 
    }

    internal static MotoDto MapToMotoDto(Motos motos)
    {
        MotoDto motoDto = new MotoDto(
            id: motos.Id,
            motoName: motos.MotoName,
            charge: motos.Charge,
            distanceFullCharge: motos.DistanceFullCharge,
            maxWeight: motos.MaxWeight,
            year: motos.Year,
            maxSpeed: motos.MaxSpeed);

        return motoDto;
    }

    internal static void MapToMoto(
        ModifyMotoDto modifyMotoDto,
        Motos moto)
    {
        moto.MotoName = modifyMotoDto.motoName ?? moto.MotoName;
        moto.Year = modifyMotoDto.year ?? moto.Year;
        moto.Charge = modifyMotoDto.charge ?? moto.Charge;
        moto.MaxWeight = modifyMotoDto.maxWeight ?? moto.MaxWeight;
        moto.DistanceFullCharge = modifyMotoDto.distanceFullCharge ?? moto.DistanceFullCharge;
        moto.MaxSpeed = modifyMotoDto.maxSpeed ?? moto.MaxSpeed;
    }
}
