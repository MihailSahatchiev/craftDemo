using CD.Core.Entities;
using MediatR;

namespace CD.Services.Models
{
    public class PopulationForAllCountriesModel : IRequest<AllCountriesPopulation>
    {
        public PopulationForAllCountriesModel(bool preference)
        {
            this.Preference = preference;
        }

        public bool Preference { get; set; }
    }
}
