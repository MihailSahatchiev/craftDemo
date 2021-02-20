using System.ComponentModel.DataAnnotations;

namespace CD.SqlLiteAdapter.DbSets
{
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public int StateId { get; set; }

        public int Population { get; set; }
    }
}
