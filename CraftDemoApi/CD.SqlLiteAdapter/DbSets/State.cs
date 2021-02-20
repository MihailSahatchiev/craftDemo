using System.ComponentModel.DataAnnotations;
namespace CD.SqlLiteAdapter.DbSets
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }

}
