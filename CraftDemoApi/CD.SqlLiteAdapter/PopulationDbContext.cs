using CD.Core.Interfaces;
using CD.SqlLiteAdapter.DbSets;
using Microsoft.EntityFrameworkCore;

namespace CD.SqlLiteAdapter
{
    public class PopulationDbContext : DbContext
    {
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<City> City { get; set; }

        public IAppSettings appSettings { get; set; }

        public PopulationDbContext()
        {
        }

        public PopulationDbContext(DbContextOptions<PopulationDbContext> options)
           : base(options)
        {
        }

        public PopulationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PopulationDbContext>();
            optionsBuilder.UseSqlite(args[0]);

            return new PopulationDbContext(optionsBuilder.Options);
        }
    }
}
