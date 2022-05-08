
using System.Data.Entity;

namespace RubApp.Models {


    class MyContextInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            CatalogOfItems item1 = new CatalogOfItems { Name = "Стул" };
            CatalogOfItems item2 = new CatalogOfItems { Name = "Стол" };
            CatalogOfItems item3 = new CatalogOfItems { Name = "Калькулятор" };
            CatalogOfItems item4 = new CatalogOfItems { Name = "Ведро" };
            CatalogOfItems item5 = new CatalogOfItems { Name = "Веник" };


            db.CatalogOfItems.Add(item1);
            db.CatalogOfItems.Add(item2);
            db.CatalogOfItems.Add(item3);
            db.CatalogOfItems.Add(item4);
            db.CatalogOfItems.Add(item5);
            db.SaveChanges();
        }
    }


    public class ApplicationContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CatalogOfItems> CatalogOfItems { get; set; }

        static ApplicationContext()
        {
            // Инициализация базы данных при первом запуске
            Database.SetInitializer<ApplicationContext>(new MyContextInitializer());
        }
        public ApplicationContext()
            : base("DefaultConnection")
        {
        }
    }
}