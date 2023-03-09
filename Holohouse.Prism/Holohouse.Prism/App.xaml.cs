using Example;
using Holohouse.Prism.ViewModels;
using Holohouse.Prism.Views;
using HoloHouse.Common.Helpers;
using HoloHouse.Common.Models;
using HoloHouse.Common.Services;
using Newtonsoft.Json;
using Prism;
using Prism.Ioc;
using System;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace Holohouse.Prism
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MTI4MTYzOEAzMjMwMmUzNDJlMzBHRGxJYjN2SkFmbElxTXNsTm5OM25LYTlhaldOcGlGb05GM3NzbTlSNUk4PQ==");
            InitializeComponent();
            var token = JsonConvert.DeserializeObject<TokenResponse>(Settings.Token);
            if (Settings.IsRemembered && token?.Expiration > DateTime.Now)
            {
                await NavigationService.NavigateAsync("/LeasingMasterDetailPage/NavigationPage/PropertiesPage");
            }
            else
            {
                await NavigationService.NavigateAsync("/NavigationPage/LoginPage");
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.Register<IGeolocatorService, GeolocatorService>();
            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertiesPage, PropertiesPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyPage, PropertyPageViewModel>();
            containerRegistry.RegisterForNavigation<ContractsPage, ContractsPageViewModel>();
            containerRegistry.RegisterForNavigation<ContractPage, ContractPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyTabbedPage, PropertyTabbedPageViewModel>();
            containerRegistry.RegisterForNavigation<LeasingMasterDetailPage, LeasingMasterDetailPageViewModel>();
            containerRegistry.RegisterForNavigation<ModifyUserPage, ModifyUserPageViewModel>();
            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
            containerRegistry.RegisterForNavigation<RememberPasswordPage, RememberPasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<ChangePasswordPage, ChangePasswordPageViewModel>();
            containerRegistry.RegisterForNavigation<EditPropertyPage, EditPropertyPageViewModel>();
        }
    }
}
