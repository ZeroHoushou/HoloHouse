using HoloHouse.Common.Helpers;
using HoloHouse.Common.Models;
using Holohouse.Prism.ViewModels;

using Newtonsoft.Json;
using Prism.Navigation;

namespace Holohouse.Prism.ViewModels
{
    public class PropertyTabbedPageViewModel : ViewModelBase
    {
        public PropertyTabbedPageViewModel(
            INavigationService navigationService) : base(navigationService)
        {
            var property = JsonConvert.DeserializeObject<PropertyResponse>(Settings.Property);
            Title = $"Property: {property.Neighborhood}";
        }
    }
}