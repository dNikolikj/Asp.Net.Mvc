using Asp.Net_Class04.Models.Enums;
namespace Asp.Net_Class04.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}
