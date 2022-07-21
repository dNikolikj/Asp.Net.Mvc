﻿using BurgerApp.Domain_Refactored.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BurgerApp.Domain_Refactored.Models
{
    public class Order
    {

        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public StoreAddress StoreAddress { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool IsDelivered { get; set; }

        public List<BurgerBasket> FoodPornBasket { get; set; }  
    }
}
