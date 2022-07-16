using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;

namespace BurgerApp.DataAccess_Refactored.EntityFrameworkImplementations
{
    public class BurgerEFRepository : IRepository<Burger>
    {
        private BurgerAppDbContext _burgerAppDbContext;
        public BurgerEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }
        public void Delete(int id)
        {
            Burger burgerDb = _burgerAppDbContext.Burgers.FirstOrDefault(b => b.Id == id);  
            if(burgerDb == null)
            {
                throw new Exception($"Burger with id {id} cannot be found!");
            }
            _burgerAppDbContext.Burgers.Remove(burgerDb);
            _burgerAppDbContext.SaveChanges();
        }

        public List<Burger> GetAll()
        {
          return _burgerAppDbContext.Burgers.ToList();
        }

        public Burger GetById(int id)
        {
            return _burgerAppDbContext.Burgers.FirstOrDefault(b =>b.Id == id);  
        }

        public int Insert(Burger entity)
        {
            _burgerAppDbContext.Burgers.Add(entity);
            _burgerAppDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(Burger entity)
        {
            _burgerAppDbContext.Burgers.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }
    }
}
