using MottoAdver.Domain;
using MottoAdver.Infastructure.DbContexts;

namespace MotoAdd.Infastructure.Repositories;

public class MotoRepository : GenericRepository<Motos, Guid>, IMotoRepository
{
    public MotoRepository(MottoAdverContext motoAddDbContext)
        : base(motoAddDbContext)
    {
    }
}
