using MottoAdver.Domain;
using MottoAdver.Infastructure.DbContexts;

namespace MotoAdd.Infastructure.Repositories;

public class AddvertisementRepository
    : GenericRepository<Addvertisements, Guid>, IAddvertisementRepository
{
    public AddvertisementRepository(MottoAdverContext motoAddDbContext)
        : base(motoAddDbContext)
    {
    }
}
