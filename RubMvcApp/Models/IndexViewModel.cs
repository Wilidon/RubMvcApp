using RubApp.ViewModel;
using System.Collections.Generic;

namespace RubApp.Models
{

    public class IndexViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public IndexViewModel(IEnumerable<Order> orders, PageViewModel viewModel)
        {
            this.Orders = orders;
            this.PageViewModel = viewModel;
        }
    }
}