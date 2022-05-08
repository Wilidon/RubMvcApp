using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Web.ModelBinding;

namespace RubApp.Models
{
    public class Order
    {
        [BindNever]
        [Column("id")]
        public int Id { set; get; }
        [BindNever]
        [Column("datetime")]
        public DateTime DateTime { set; get; }
        public List<Item> Items { set; get; }

    }
}