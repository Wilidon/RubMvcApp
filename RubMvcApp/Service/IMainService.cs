using RubApp.Models;
using System.Collections.Generic;

namespace RubApp.Service
{
    public interface IMainService
    {
        List<CatalogOfItems> getCatalogOfItems();
        void AddOrder(List<Item> items);
        Dictionary<string, int> GetOrder(int year, int month);
        string[] GetMonthNames();
        List<Order> GetOrdersByPage(int page, int limit = 3);
        int GetAmountOrders();

    }
}