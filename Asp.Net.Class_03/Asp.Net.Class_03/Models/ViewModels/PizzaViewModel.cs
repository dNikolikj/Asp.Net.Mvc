using Asp.Net.Class_03.Models.Enums;

namespace Asp.Net.Class_03.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
    }
}
