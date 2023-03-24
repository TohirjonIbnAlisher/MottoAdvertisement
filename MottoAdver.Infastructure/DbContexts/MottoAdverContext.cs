using Microsoft.EntityFrameworkCore;
using MottoAdver.Infastructure.EntityTypeConfigurations;
using System.Reflection;

namespace MottoAdver.Infastructure.DbContexts;

public class MottoAdverContext : DbContext
{
    public MottoAdverContext(DbContextOptions<MottoAdverContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
