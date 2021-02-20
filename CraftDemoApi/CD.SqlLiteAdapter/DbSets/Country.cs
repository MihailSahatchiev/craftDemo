using System.ComponentModel.DataAnnotations;

namespace CD.SqlLiteAdapter.DbSets
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public int CountryName { get; set; }
    }
}
