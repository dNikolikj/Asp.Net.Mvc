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

        public BurgerService(IRepository<Burger> burgerRepository)
        {
            _burgerRepository = burgerRepository;
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
