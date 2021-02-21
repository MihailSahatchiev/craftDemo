using CD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CD.Core.Interfaces
{
    public interface IStatService
    {
        List<Tuple<string, int>> GetCountryPopulations();
        Task<AllCountriesPopulation> GetCountryPopulationsAsync(AllCountriesPopulation model);
    }
}
