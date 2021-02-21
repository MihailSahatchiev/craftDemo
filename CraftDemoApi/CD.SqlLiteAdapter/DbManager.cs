using CD.Core.Entities;
using CD.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<AllCountriesPopulation> GetPopulationForAllCountries()
        {
            var allStates = await this.context.State.ToListAsync();
            var allCities = await this.context.City.FromSqlRaw("Select * From CITY where CityId IS NOT NULL AND CityName IS NOT NULL AND StateId IS NOT NULL AND Population IS NOT NULL").ToListAsync();
            var allCountries = await this.context.Country.ToListAsync();
            var model = new AllCountriesPopulation()
            {
                AllCountriesPopulationList = new Dictionary<string, int>()
            };
            foreach (var country in allCountries)
            {
                var population = 0;
                var allStatesInThisCountry = allStates.Where(a => a.CountryId == country.CountryId);
                foreach (var state in allStatesInThisCountry)
                {
                    var allCitiesInThisState = allCities.Where(c => c.StateId == state.StateId);
                    foreach (var city in allCitiesInThisState)
                    {
                        population += city.Population;
                    }
                }
                model.AllCountriesPopulationList.Add(country.CountryName, population);
                
            }
            return model;
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
