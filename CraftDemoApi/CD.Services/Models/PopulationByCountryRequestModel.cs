using CD.Core.Entities;
using MediatR;

namespace CD.Services.Models
{
    public class PopulationByCountryRequestModel : IRequest<Population>
    {
        public PopulationByCountryRequestModel(int countryId)
        {
            this.CountryId = countryId;
        }

        public int CountryId { get; set; }
    }
}
