using System.ComponentModel.DataAnnotations;

namespace CD.SqlLiteAdapter.DbSets
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        public string CountryName { get; set; }
    }
}
