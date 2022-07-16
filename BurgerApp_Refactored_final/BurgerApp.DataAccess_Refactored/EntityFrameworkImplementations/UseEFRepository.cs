
using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;
namespace BurgerApp.DataAccess_Refactored.EntityFrameworkImplementations
{
    public class UseEFRepository : IRepository<User>
    {
        private BurgerAppDbContext _burgerAppDbContext;

        public UseEFRepository(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }
        public void Delete(int id)
        {
           User userDb = _burgerAppDbContext.Users.FirstOrDefault(u => u.Id == id); 
            if(userDb == null)
            {
                throw new Exception($"User with id {id} does not exist!");
            }
            _burgerAppDbContext.Users.Remove(userDb);
            _burgerAppDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _burgerAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _burgerAppDbContext.Users.FirstOrDefault(u =>u.Id == id);    
        }

        public int Insert(User entity)
        {
            _burgerAppDbContext.Users.Add(entity);
            _burgerAppDbContext.SaveChanges();
            return entity.Id;
        }

        public void Update(User entity)
        {
            _burgerAppDbContext.Update(entity);
            _burgerAppDbContext.SaveChanges();
        }
    }
}
