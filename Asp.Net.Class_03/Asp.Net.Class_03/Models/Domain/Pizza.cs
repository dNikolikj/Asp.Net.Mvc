using Asp.Net.Class_03.Models.Enums;
namespace Asp.Net.Class_03.Models.Domain
{
    public class Pizza
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public bool IsOnPromotion { get; set; }
        public bool HasExtras { get; set; }
    }
}
