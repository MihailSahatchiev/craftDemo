using System;
using System.Threading.Tasks;
using CD.Common;
using CD.Services.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CraftDemoApi.Controllers
{
    [Route(Constants.CONTROLLER_ROUTE_POPULATION_INFO)]
    [ApiController]
    public class PopulationInfoController : ControllerBase
    {
        private readonly IMediator mediator;

        public PopulationInfoController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route(Constants.CONTROLLER_ROUTE_POPULATION_GET_INFO_PERCOUNTRY)]
        [HttpPost]
        public async Task<IActionResult> GePopulationInfo([FromBody]PopulationByCountryRequestModel model)
        {
            if (model != null)
            {
                var result = await this.mediator.Send(model);
                return this.Ok(result.CountryPopulation);
            }
            else
                return this.BadRequest();
        }

        [Route(Constants.CONTROLLER_ROUTE_POPULATION_GET_LIST_OF_POPULATION_FORALL_COUNTRIES)]
        [HttpGet]
        public async Task<IActionResult> GetListOfPopulationAllCountries()
        {
            bool pref = false;
            var model = new PopulationForAllCountriesModel(pref)
            {
                Preference = pref
            };
            var result = await this.mediator.Send(model);
            return this.Ok(result.AllCountriesPopulationList);
        }
    }
}