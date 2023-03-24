using MottoAdver.Domain;
using MottoAdver.Infastructure.DbContexts;

namespace MotoAdd.Infastructure.Repositories;

public class AdminRepository : GenericRepository<Admins, Guid>, IAdminRepository
{
    public AdminRepository(MottoAdverContext motoAddDbContext) 
        : base(motoAddDbContext)
    {
    }
}
