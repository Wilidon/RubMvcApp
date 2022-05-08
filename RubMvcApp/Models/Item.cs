using System.ComponentModel.DataAnnotations.Schema;
using System.Web.ModelBinding;

namespace RubApp.Models {
    public class Item
    {
        [BindNever]
        [Column("id")]
        public int Id { set; get; }
        [Column("item_name")]
        public string ItemName { set; get; }
        [Column("amount")]
        public int Amount { set; get; }
        [Column("comment")]
        public string Comment { set; get; }
    }
}