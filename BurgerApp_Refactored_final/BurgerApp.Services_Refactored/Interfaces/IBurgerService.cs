using BurgerApp.ViewModels_Refactored.BurgerViewModels;
using BurgerApp.ViewModels_Refactored.BurgerViewModels;
namespace BurgerApp.Services_Refactored.Interfaces
{
    public interface IBurgerService
    {

        List<BurgerDetailsViewModel> PrintBurgerMenu();


        BurgerDetailsViewModel SeeDetailsForTheChosenBurger(int id);

        void CreateBurger(BurgerViewModel burgerViewModel);

        BurgerViewModel EditBurger(int id);
        void EditBurgerPost(BurgerViewModel burgerViewModel);

        void DeleteBurger(int id);

        List<BurgerDDViewModel> GetBurgersForDD();

        string GetMostPopularBurger();

        double GetTheAveragePriceOfOrders();
        double GetTheNumberOfOrders();


    }
}
