using HoloHouse.Common.Helpers;
using HoloHouse.Common.Models;
using HoloHouse.Common.Services;
using Holohouse.Prism.ViewModels;
using Holohouse.Prism;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Holohouse.Prism.ViewModels
{
    public class PropertiesPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IApiService _apiService;
        private OwnerResponse _owner;
        private ObservableCollection<PropertyItemViewModel> _properties;
        private DelegateCommand _addPropertyCommand;
        private static PropertiesPageViewModel _instance;

        public PropertiesPageViewModel(
            INavigationService navigationService,
            IApiService apiService) : base(navigationService)
        {
            _instance = this;
            _navigationService = navigationService;
            _apiService = apiService;
            Title = "Properties";
            LoadProperties();
        }

        public DelegateCommand AddPropertyCommand => _addPropertyCommand ?? (_addPropertyCommand = new DelegateCommand(AddPropertyAsync));

        public ObservableCollection<PropertyItemViewModel> Properties
        {
            get => _properties;
            set => SetProperty(ref _properties, value);
        }

        public static PropertiesPageViewModel GetInstance()
        {
            return _instance;
        }

        public async Task UpdateOwnerAsync()
        {
            var url = App.Current.Resources["UrlAPI"].ToString();
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);

            var response = await _apiService.GetOwnerByEmailAsync(
                url,
                "/api",
                "/Owners/GetOwnerByEmail",
                "bearer",
                token.Token,
                _owner.Email);

            if (response.IsSuccess)
            {
                var owner = (OwnerResponse)response.Result;
                Settings.Owner = JsonConvert.SerializeObject(owner);
                _owner = owner;
                LoadProperties();
            }
        }

        private void LoadProperties()
        {
            _owner = JsonConvert.DeserializeObject<OwnerResponse>(Settings.Owner);

            if (_owner.RoleId == 1)
            {
                Title = $"Properties of: {_owner.FullName}";
            }
            else
            {
                Title = "Available Properties";
            }

            Random rnd = new Random();
            int min = 990000000;
            int max = 999999999;

            //var contract = string.IsNullOrEmpty(p.Contracts.ToString());
            //var ContracStatic = new ObservableCollection<ContractResponse>
            //{
            //    new ContractResponse { Id = 1, Remarks = "Contratode inicio",Price=1.2m,StartDate= DateTime.Now,EndDate=DateTime.Now, Lessee={FirstName="Contrato Inicio" } },
             
            //};

            Properties = new ObservableCollection<PropertyItemViewModel>(_owner.Properties.Select(p => new PropertyItemViewModel(_navigationService)
            {
                Address = p.Address,
                PhoneNumber = (rnd.Next(min,max + 1)).ToString(),
                //Contracts = string.IsNullOrEmpty(p.Contracts.ToString())?p.Contracts:ContracStatic,
                Contracts=p.Contracts,
                HasParkingLot = p.HasParkingLot,
                IsAvailable = p.IsAvailable,
                Id = p.Id,
                Neighborhood = p.Neighborhood,
                Price = p.Price,
                PropertyImages = p.PropertyImages,
                PropertyType = p.PropertyType,
                Remarks = p.Remarks,
                Rooms = p.Rooms,
                SquareMeters = p.SquareMeters,
                Stratum = p.Stratum
                
            }).ToList());
        }

        private async void AddPropertyAsync()
        {
            await _navigationService.NavigateAsync("EditPropertyPage");
        }
    }
}