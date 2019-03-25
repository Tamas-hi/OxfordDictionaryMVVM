using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Microsoft.CSharp.RuntimeBinder;

namespace OxfordDictionaryMVVM.ViewModels {
    public class MainPageViewModel : ViewModelBase {

        public DelegateCommand StartCommand { get; }
        public DelegateCommand AboutCommand { get; }
        public DelegateCommand ImageCommand { get; }

        private Image image;

        public Image MyImage
        {
            get { return image; }
            set { image = value;
                RaisePropertyChanged("Image");
            }
        }

        public MainPageViewModel() {
            StartCommand = new DelegateCommand(StartNow);
            AboutCommand = new DelegateCommand(AboutWindow);
            ImageCommand = new DelegateCommand(Tapped);
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled) {
                Value = "Designtime value";
            }
        }

        private async void Tapped()
        {
            string uriToLaunch = @"http://www.github.com/hargitomi97/OxfordDictionaryMVVM";
            var uri = new Uri(uriToLaunch);

            var success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (success)
            {
                // URI launched
            }
            else
            {
                // URI launch failed
            }
        }

        private async void AboutWindow()
        {
            var messageDialog = new MessageDialog("OxfordDictionary is a Universal Windows Platform (UWP) application where you can translate words, find synonyms and antonyms. This application is strongly follows Model-ViewModel-Model approach (MVVM) and uses Template10 framework.")
            {
                Title = "Information"
            };

            messageDialog.Commands.Add(new UICommand("Close"));

            await messageDialog.ShowAsync();
        }

        private void StartNow()
        {
            GotoDetailsPage();
        }

        string _Value = "Gas";
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState) {
            if (suspensionState.Any()) {
                Value = suspensionState[nameof(Value)]?.ToString();
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending) {
            if (suspending) {
                suspensionState[nameof(Value)] = Value;
            }
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args) {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), Value);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}
