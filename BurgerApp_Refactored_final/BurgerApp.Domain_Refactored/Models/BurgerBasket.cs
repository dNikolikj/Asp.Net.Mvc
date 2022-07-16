using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerApp.Domain_Refactored.Models
{
    public class BurgerBasket
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int BurgerId { get; set; }
        public Burger Burger { get; set; }
        public int NumberOfBurgers { get; set; }
    }
}
