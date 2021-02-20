using CD.Core.Entities;
using CD.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CD.SqlLiteAdapter
{
    public class DbManager : IDbManager
    {
        private PopulationDbContext context;

        public DbManager(PopulationDbContext context)
        {
            this.context = context;
        }

        public async Task<Population> GetPopulationForByCountry(int id)
        {
            var statesByCountry = await this.context.State.Where(x => x.CountryId == id).ToListAsync();
            var result = new Population()
            {
                Id = id,
            };
            foreach (var state in statesByCountry)
            {
                var citiesInState = await this.context.City.Where(x => x.StateId == state.StateId).ToListAsync();
                foreach (var city in citiesInState)
                {
                    result.CountryPopulation += city.Population;
                }
            }
            return result;
        }
    }
}
