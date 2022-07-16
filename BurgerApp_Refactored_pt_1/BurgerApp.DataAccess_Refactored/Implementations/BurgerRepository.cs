using BurgerApp.DataAccess_Refactored.Interfaces;
using BurgerApp.Domain_Refactored.Models;

namespace BurgerApp.DataAccess_Refactored.Implementations
{
    public class BurgerRepository : IRepository<Burger>
    {
        public void Delete(int id)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
            if(burgerDb == null)
            {
                throw new Exception($"Burger with id {id} was not found!");
            }
            StaticDb.Burgers.Remove(burgerDb);
        }

        public List<Burger> GetAll()
        {
            return StaticDb.Burgers;
        }

        public Burger GetById(int id)
        {
            return StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
        }

        public int Insert(Burger entity)
        {
            entity.Id = ++StaticDb.BurgerId;
            StaticDb.Burgers.Add(entity);
            return entity.Id;
        }

        public void Update(Burger entity)
        {
            Burger burgerDb = StaticDb.Burgers.FirstOrDefault(b => b.Id == entity.Id);
            if(burgerDb == null)
            {
                throw new Exception($"Burger with id {entity.Id} was not found!");
            }
            int index = StaticDb.Burgers.IndexOf(burgerDb);
            if(index == -1)
            {
                throw new Exception($"Burger with id {entity.Id} was not found!");
            }
            StaticDb.Burgers[index] = entity;
        }
    }
}
