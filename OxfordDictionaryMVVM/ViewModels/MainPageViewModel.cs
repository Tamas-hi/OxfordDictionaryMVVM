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

namespace OxfordDictionaryMVVM.ViewModels
{
    /// <summary>
    /// Welcome Screen - starting point of my application.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {

        public DelegateCommand StartCommand { get; }
        public DelegateCommand AboutCommand { get; }
        public DelegateCommand ImageCommand { get; }

        /// <summary>
        /// Constructor used to apply Command pattern.
        /// </summary>
        public MainPageViewModel()
        {
            StartCommand = new DelegateCommand(StartNow);
            AboutCommand = new DelegateCommand(AboutWindow);
            ImageCommand = new DelegateCommand(Tapped);
        }

        private async void Tapped()
        {
            string uriToLaunch = @"http://www.github.com/hargitomi97/OxfordDictionaryMVVM";
            var uri = new Uri(uriToLaunch);

            var success = await Windows.System.Launcher.LaunchUriAsync(uri);
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

        /// <summary>
        /// Template 10 Minimal template -  When we navigate elsewhere from here.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        /// <summary>
        /// Navigate to DetailsPage.
        /// </summary>
        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage));

        /// <summary>
        /// Navigate to Settings default page.
        /// </summary>
        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        /// <summary>
        /// Navige to Privacy Tab of Settings page.
        /// </summary>
        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        /// <summary>
        /// Navigate to About Tab of Settings page.
        /// </summary>
        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}
