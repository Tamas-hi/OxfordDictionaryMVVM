using System;
using OxfordDictionaryMVVM.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Popups;

namespace OxfordDictionaryMVVM.Views {
    public sealed partial class MainPage : Page {

        public MainPage() {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e) {
            Image image = sender as Image;
            image.RenderTransform = new ScaleTransform() { ScaleX = 1.2, ScaleY = 1.2 };
            Launch();
        }

        private async void Launch() {
            string uriToLaunch = @"http://www.github.com/hargitomi97/OxfordDictionaryMVVM";
            var uri = new Uri(uriToLaunch);

            var success = await Windows.System.Launcher.LaunchUriAsync(uri);

            if (success) {
                // URI launched
            } else {
                // URI launch failed
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e) {
            ViewModel.GotoDetailsPage();
        }

        private async void About_ClickAsync(object sender, RoutedEventArgs e) {

            var messageDialog = new MessageDialog("OxfordDictionary is a Universal Windows Platform (UWP) application where you can translate words, find synonyms and antonyms. This application is strongly follows Model-ViewModel-Model approach (MVVM) and uses Template10 framework.") {
                Title = "Information"
            };

            messageDialog.Commands.Add(new UICommand("Close"));
               
            await messageDialog.ShowAsync();
        }
    }
}