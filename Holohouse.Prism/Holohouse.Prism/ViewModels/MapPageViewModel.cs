using Holohouse.Prism.ViewModels;
using Prism.Navigation;

namespace Holohouse.Prism.ViewModels
{
    public class MapPageViewModel : ViewModelBase
    {
        public MapPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Map";
        }
    }
}