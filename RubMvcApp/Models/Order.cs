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
        // Локальное время заявки
        [NotMapped]
        public DateTime LocalDateTime
        {
            get { return DateTime.AddHours(4); }
            set { LocalDateTime = DateTime;}

        }
    }
}