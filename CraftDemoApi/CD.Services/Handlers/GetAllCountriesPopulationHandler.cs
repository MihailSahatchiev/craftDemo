using CD.Core.Entities;
using CD.Core.Interfaces;
using CD.Services.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CD.Services.Handlers
{
    public class GetAllCountriesPopulationHandler : IRequestHandler<PopulationForAllCountriesModel, AllCountriesPopulation>
    {
        private IDbManager dbManager;
        private IStatService statService;
        public GetAllCountriesPopulationHandler(IDbManager dbManager, IStatService statService)
        {
            this.statService = statService ?? throw new ArgumentNullException(nameof(statService));
            this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        public async Task<AllCountriesPopulation> Handle(PopulationForAllCountriesModel request, CancellationToken cancellationToken)
        {
            var dbCountryPopulation = await dbManager.GetPopulationForAllCountries();
            var combinedSourcesCountryPopulation = await statService.GetCountryPopulationsAsync(dbCountryPopulation);
            return combinedSourcesCountryPopulation;
        }
    }
}
