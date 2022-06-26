using Asp.Net_Class04.Models.Enums;
namespace Asp.Net_Class04.Models.Domain
{
    public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public bool IsOnPromotion { get; set; }
        public bool HasExtras { get; set; }

    }
}
