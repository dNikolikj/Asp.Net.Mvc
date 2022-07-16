using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels_Refactored.HomeViewModels
{
   public  class HomeViewModel
    {
        public string MostPopularBurger { get; set; }   
        public double NumberOfOrders { get; set; }  
        public double AveragePrice { get; set; }

    }
}
