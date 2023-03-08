using Example;
using Holohouse.Prism.ViewModels;
using Holohouse.Prism.Views;
using HoloHouse.Common.Services;
using Prism;
using Prism.Ioc;
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
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.Register<IApiService, ApiService>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertiesPage, PropertiesPageViewModel>();
            containerRegistry.RegisterForNavigation<PropertyPage, PropertyPageViewModel>();
        }
    }
}
