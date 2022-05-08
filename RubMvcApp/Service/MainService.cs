
using RubApp.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace RubApp.Service {

public class MainService : IMainService
{
    private ApplicationContext db;

    public MainService(ApplicationContext db)
    {
        this.db = db;
    }

    public string[] GetMonthNames()
    {
        string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
        return months;
    }

    public List<CatalogOfItems> getCatalogOfItems()
    {
        return db.CatalogOfItems.ToList();
    }

    public void AddOrder(List<Item> items)
    {
        Order order = new Order { DateTime = DateTime.UtcNow, Items = items };
        db.Orders.Add(order);
        db.SaveChanges();
    }

    public Dictionary<string, int> GetOrder(int year, int month)
    {
        DateTime dateTime1 = new DateTime(year, month, 1);
        DateTime dateTime2 = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        dateTime2 = dateTime2.AddDays(1).AddTicks(-1);


        var name = db.Orders.Include(u => u.Items).Where(p => p.DateTime >= dateTime1).FirstOrDefault();
  


        List<Order> orders = db.Orders.Include(u => u.Items)
            .Where(p => p.DateTime >= dateTime1).Where(p => p.DateTime <= dateTime2).ToList();
        Console.WriteLine("dateTime1 " + dateTime1);
        Console.WriteLine("dateTime2 " + dateTime2);
        Console.WriteLine(orders.Count);
        Dictionary<string, int> reportData = new Dictionary<string, int>();
        List<CatalogOfItems> catalogOfItemsList = getCatalogOfItems();
        foreach (var catalogOfItem in catalogOfItemsList)
        {
            reportData[catalogOfItem.Name] = 0;
        }

        // пройдемся по всем заявкам и добавим в отчет
        // суммарное количество заказов конкретной позиции
        foreach (var order in orders)
        {
            foreach (var item in order.Items)
            {   
                reportData[item.ItemName] += item.Amount;
            }
        }
        return reportData;
    }

    public List<Order> GetOrdersByPage(int page, int limit)
    {
        return db.Orders.OrderByDescending(u => u.Id).Skip((page-1)*limit).Take(limit).Include(u => u.Items).ToList();
    }

    public int GetAmountOrders()
    {
        return db.Orders.Include(u => u.Items).Count();
    }

    
}
}