using CD.Core.Entities;
using CD.Core.Interfaces;
using CD.Services.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CD.Services.Handlers
{
    public class GetPopulationByCountryHandler : IRequestHandler<PopulationByCountryRequestModel, Population>
    {
        private IDbManager dbManager;
        public GetPopulationByCountryHandler(IDbManager dbManager)
        {
            this.dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
        }

        public async Task<Population> Handle(PopulationByCountryRequestModel request, CancellationToken cancellationToken)
        {
            var populationByCountry = await dbManager.GetPopulationForByCountry(request.CountryId);

            return populationByCountry;
        }
    }
}
