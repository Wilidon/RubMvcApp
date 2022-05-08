using System.ComponentModel.DataAnnotations.Schema;

namespace RubApp.Models
{

    public class CatalogOfItems
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}