using RubApp.Models;
using RubApp.Service;
using RubApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RubMvcApp.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        private IMainService _mainService;

        public MainController()
        {
            _mainService = new MainService(new ApplicationContext());
        }


        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            SelectList CatalogOfItems = new SelectList(_mainService.getCatalogOfItems(), "Name", "Name");
            ViewBag.CatalogOfItems = CatalogOfItems;
            return View();
        }


        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromBody] List<Item> items)
        {
            if (items != null)
            {
                _mainService.AddOrder(items);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Report(string Date, int page = 1)
        {
            int year, month;
            if (Date == null)
            {
                DateTime dateTime = DateTime.Now;
                year = dateTime.Year;
                month = dateTime.Month;
            }
            else
            {   
                string[] year_month = Date.Split('-');
                year = Convert.ToInt32(year_month[0]);
                month = Convert.ToInt32(year_month[1]);
            }

            ViewBag.MonthNames = _mainService.GetMonthNames();
            ViewBag.OrderDateYear = year;
            ViewBag.OrderDateMonth = month;
            ViewBag.OrderDate = string.Format("{0}-{1}", year,  month < 10 ? "0" + month.ToString() : month.ToString());
            ViewBag.Orders = _mainService.GetOrder(year, month);

            int pageSize = 3;
            List<Order> items = _mainService.GetOrdersByPage(page);
            var count = _mainService.GetAmountOrders();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel(items, pageViewModel);
            return View(viewModel);
        }
    }

}
