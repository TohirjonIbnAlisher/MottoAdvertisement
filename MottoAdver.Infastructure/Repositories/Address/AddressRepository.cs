using MottoAdver.Domain;
using MottoAdver.Infastructure.DbContexts;

namespace MotoAdd.Infastructure.Repositories;

public class AddressRepository : GenericRepository<Addresses, Guid>, IAddressRepository
{
    public AddressRepository(MottoAdverContext motoAddDbContext) 
        : base(motoAddDbContext)
    {
    }
}
