using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;

namespace BurgerApp.DataAccess_Refactored.EntityFrameworkImplementations
{
    public class OrderEFRepository : IRepository<Order>
    {
        private BurgerAppDbContext _burgerAppDbContext;
        public OrderEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }
        public void Delete(int id)
        {
            Order orderDb = _burgerAppDbContext.Orders.FirstOrDefault(o => o.Id == id); 
            if(orderDb == null)
            {
                throw new Exception($"The order with id {id} does not exist");
            }
            _burgerAppDbContext.Orders.Remove(orderDb);
            _burgerAppDbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _burgerAppDbContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _burgerAppDbContext.Orders.FirstOrDefault(o =>o.Id == id);   

        }

        public int Insert(Order entity)
        {
           _burgerAppDbContext.Orders.Add(entity);
            _burgerAppDbContext.SaveChanges();
            return entity.Id;   
        }

        public void Update(Order entity)
        {
            _burgerAppDbContext.Orders.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }
    }
}
