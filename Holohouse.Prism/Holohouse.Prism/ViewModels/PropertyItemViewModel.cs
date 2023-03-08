using HoloHouse.Common.Helpers;
using HoloHouse.Common.Models;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Holohouse.Prism.ViewModels
{
    public class PropertyItemViewModel : PropertyResponse
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectPropertyCommand;

        public PropertyItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectPropertyCommand => _selectPropertyCommand ?? (_selectPropertyCommand = new DelegateCommand(SelectProperty));

        private async void SelectProperty()
        {
            Settings.PropertyImages = JsonConvert.SerializeObject(PropertyImages);

            var parameters = new NavigationParameters
            {
                { "property", this }
            };

            await _navigationService.NavigateAsync("PropertyPage", parameters);
        }
    }
}