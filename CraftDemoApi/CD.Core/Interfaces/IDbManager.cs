using CD.Core.Entities;
using System.Threading.Tasks;

namespace CD.Core.Interfaces
{
    public interface IDbManager
    {
        Task<Population> GetPopulationForByCountry(int id);
    }
}
