using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;

namespace BurgerApp.DataAccess_Refactored.Implementations
{
    public class UserRepository : IRepository<User>
    {
        public void Delete(int id)
        {
            User userDb = StaticDb.Users.FirstOrDefault(u=> u.Id == id);
            if(userDb == null)
            {
                throw new Exception($"The user with id {id} was not found!");
            }
            StaticDb.Users.Remove(userDb);  
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(u => u.Id == id);
        }

        public int Insert(User entity)
        {
            entity.Id = ++StaticDb.UserId;
            StaticDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User userDb = StaticDb.Users.First(u => u.Id == entity.Id); 
            if(userDb == null)
            {
                throw new Exception($"User with id {entity.Id} was not found!");
            }
            int index = StaticDb.Users.FindIndex(u => u.Id == entity.Id);
            if(index == -1)
            {
                throw new Exception($"User with id {entity.Id} was not found!");
            }
            StaticDb.Users[index] = entity;
        }
    }
}
