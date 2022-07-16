using BurgerApp.Services_Refactored.Interfaces;
using BurgerApp.ViewModels_Refactored.BurgerViewModels;
using BurgerApp.Domain_Refactored.Models;
using BurgerApp.Mappers_Refactored.BurgerMappers;
using BurgerApp.DataAccess_Refactored.Interfaces;

namespace BurgerApp.Services_Refactored.Implementations
{
    public class BurgerService : IBurgerService
    {
        private IRepository<Burger> _burgerRepository;
        private IRepository<Order> _orderRepository;

        public BurgerService(IRepository<Burger> burgerRepository, IRepository<Order> orderRepository)
        {
            _burgerRepository = burgerRepository;
            _orderRepository = orderRepository;
        }
        public void CreateBurger(BurgerViewModel burgerViewModel)
        {
            if(String.IsNullOrWhiteSpace(burgerViewModel.BurgerName))
            {
                throw new Exception($"You have to state the name of the burger you are looking for!");
            }

            Burger domainBurger = DomainBurgerMapper.ToBurgerModel(burgerViewModel);

            int domainBurgerId = _burgerRepository.Insert(domainBurger);
            if(domainBurgerId <= 0)
            {
                throw new Exception("An error occurred, please try again later!");
            }
        }

        public void DeleteBurger(int burgerId)
        {
            Burger burgerDb = _burgerRepository.GetById(burgerId);
            if(burgerDb == null)
            {
                throw new Exception($"Burger with id {burgerId} was not found!");
            }
            _burgerRepository.Delete(burgerId);
        }

        public BurgerViewModel EditBurger(int id)
        {
            Burger burgerDb = _burgerRepository.GetById(id);
            if(burgerDb == null)
            {
                throw new Exception($"The burger with {id} was not found!");
            }
            BurgerViewModel burgerViewModel = BurgerViewModelMapper.ToBurgerViewModel(burgerDb);
            return burgerViewModel;
        }

        public void EditBurgerPost(BurgerViewModel burgerViewModel)
        {
            Burger burgerDb = _burgerRepository.GetById(burgerViewModel.Id);
            if(burgerDb == null)
            {
                throw new Exception($"The burger with id {burgerViewModel.Id} was not found!");
            }
            if(String.IsNullOrWhiteSpace(burgerViewModel.BurgerName))
            {
                throw new Exception($"The name of the burger can not be empty!");
            }
            burgerDb.Name = burgerViewModel.BurgerName;
            burgerDb.TypeOfBurger = burgerViewModel.TypeOfBurger;
            burgerDb.HasFries = burgerViewModel.Fries;
            _burgerRepository.Update(burgerDb);
        }

        public List<BurgerDDViewModel> GetBurgersForDD()
        {
            List<Burger> burgersDb = _burgerRepository.GetAll();

            List<BurgerDDViewModel> burgersForDropDown = burgersDb.Select(b => BurgerDDMapper.ToBurgerDDViewModel(b)).ToList();
            return burgersForDropDown;

        }

        public string GetMostPopularBurger()
        {
            List<Order> ordersDb = _orderRepository.GetAll();

            List<BurgerBasket> burgerOrders = ordersDb.SelectMany(x => x.FoodPornBasket).ToList();
            return burgerOrders.GroupBy(b => b.BurgerId)
                .OrderByDescending(b => b.Count())
                .First()
                .Select(b => b.Burger.Name)
                .First();

        }

        public double GetTheNumberOfOrders()
        {
            List<Order> ordersDb = _orderRepository.GetAll();
            return ordersDb.Count();
        }

        public double GetTheAveragePriceOfOrders()
        {
            List<Order> ordersDb = _orderRepository.GetAll();

            List<BurgerBasket> burgerOrders = ordersDb.SelectMany(b => b.FoodPornBasket).ToList();
            double average = (burgerOrders.Sum(b => b.Burger.Price)) / burgerOrders.Count();
            return average;
        }

        public List<BurgerDetailsViewModel> PrintBurgerMenu()
        {
            List<Burger> burgersDb = _burgerRepository.GetAll();
            List<BurgerDetailsViewModel> burgersViewModels = burgersDb.Select(b => BurgerDetailsViewModelMapper.ToBurgerDetailsViewModel(b)).ToList();
            return burgersViewModels;
        }

        public BurgerDetailsViewModel SeeDetailsForTheChosenBurger(int id)
        {
            Burger burgerDb = _burgerRepository.GetById(id);
            if(burgerDb == null)
            {
                throw new Exception($"Burger with id {id} was not found!");
            }
            BurgerDetailsViewModel burgerViewModel = BurgerDetailsViewModelMapper.ToBurgerDetailsViewModel(burgerDb);
            return burgerViewModel;
        }
    }
}
