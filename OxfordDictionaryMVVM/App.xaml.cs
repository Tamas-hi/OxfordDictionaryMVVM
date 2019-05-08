using System;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using OxfordDictionaryMVVM.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Mvvm;
using Template10.Common;
using System.Linq;
using Windows.UI.Xaml.Data;

namespace OxfordDictionaryMVVM {
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    [Bindable]
    sealed partial class App : BootStrapper {
        /// <summary>
        /// Starting point of application.
        /// </summary>
        public App() {
            InitializeComponent();

            #region app settings

            // some settings must be set in app.constructor
            var settings = SettingsService.Instance;
            RequestedTheme = ApplicationTheme.Light;
            ShowShellBackButton = settings.UseShellBackButton;

            #endregion
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args) {
            // TODO: add your long-running task here
            await NavigationService.NavigateAsync(typeof(Views.MainPage));
        }
    }
}
