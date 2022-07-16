using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;

namespace BurgerApp.DataAccess_Refactored.Implementations
{
    public class OrderRepository : IRepository<Order>
    {
        public void Delete(int id)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {id} was not found!");
            }
            StaticDb.Orders.Remove(orderDb);    
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.First(o => o.Id == id);
        }

        public int Insert(Order entity)
        {
            entity.Id = ++StaticDb.OrderId;
            StaticDb.Orders.Add(entity);
            return entity.Id;
        }

        public void Update(Order entity)
        {
            Order orderDb = StaticDb.Orders.FirstOrDefault(o => o.Id == entity.Id);
            if(orderDb == null)
            {
                throw new Exception($"Order with id {entity.Id} was not found!");
            }
            int index = StaticDb.Orders.FindIndex(o => o.Id == entity.Id);
            if(index == -1)
            {
                throw new Exception($"Order with id{entity.Id} was not found!");
            }
            StaticDb.Orders[index] = entity;    
        }
    }
}
