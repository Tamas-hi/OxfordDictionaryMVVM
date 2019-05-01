using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxfordDictionaryMVVM.Models;
using OxfordDictionaryMVVM.Services;
using Oxfordify.Models;
using Template10.Common;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

namespace OxfordDictionaryMVVM.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {

        OxfordDictionaryMVVMService service = new OxfordDictionaryMVVMService();

        public ObservableCollection<Result> AllLanguages { get; set; } = new ObservableCollection<Result>();
        public ObservableCollection<Result> DestinationLanguages { get; set; } = new ObservableCollection<Result>();


        // Ez van a Result2-ben
        public ObservableCollection<string> TranslationResults { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> SynonymResults { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> AntonymResults { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> SentencesResult { get; set; } = new ObservableCollection<string>();

        public DelegateCommand<string> TranslateCommand { get; }
        public DelegateCommand<string> SynonymCommand { get; }
        public DelegateCommand<string> AntonymCommand { get; }
        public DelegateCommand<string> SentencesCommand { get; }

        private string selectedSource;

        public string SelectedSource
        {
            get
            {
                return selectedSource;
            }
            set
            {
                selectedSource = value;
                DestinationLanguages.Clear();
                // azokat a nyleveket adjuk hozzá, amelyekhez tartozik forrásnyelv ami id-je megegyezik a kiválasztott nyelv id-jével
                foreach (var item in AllLanguages)
                {
                    if (item.sourceLanguage.id == selectedSource)
                    {
                        DestinationLanguages.Add(item);
                    }
                }
            }
        }

        public string SelectedDestination { get; set; }


        public DetailPageViewModel() {
            TranslateCommand = new DelegateCommand<string>(TranslateClick);
            SynonymCommand = new DelegateCommand<string>(SynonymClick);
            AntonymCommand = new DelegateCommand<string>(AntonymClick);
            SentencesCommand = new DelegateCommand<string>(SentenceClick);
        }

        private async void SentenceClick(string obj)
        {
            TranslationResults.Clear();
            SynonymResults.Clear();
            AntonymResults.Clear();
            SentencesResult.Clear();

            var response = await service.GetSentenceAsync(selectedSource, obj);
            if(response != null)
            {
                foreach(var result in response.results)
                {
                    foreach (var le in result.lexicalEntries){
                        foreach(var sentence in le.sentences)
                        {
                            SentencesResult.Add(sentence.text);
                        }
                    }
                }
            }
        }

        private async void SynonymClick(string text) {
            if (text.Length == 0) return;
            TranslationResults.Clear();
            SynonymResults.Clear();
            AntonymResults.Clear();
            SentencesResult.Clear();

            

            var response = await service.GetSynonymAsync(SelectedSource, text);
            if (response != null) {
                foreach (var result in response.results)
                {
                    foreach (var lexicalEntry in result.lexicalEntries )
                    {
                        foreach (var entry in lexicalEntry.entries)
                        {
                            foreach (var sense in entry.senses)
                            {
                                foreach (var synonym in sense.synonyms)
                                {
                                    SynonymResults.Add(synonym.text);
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void AntonymClick(string text) {
            if (text.Length == 0) return;
            TranslationResults.Clear();
            SynonymResults.Clear();
            AntonymResults.Clear();
            SentencesResult.Clear();

            var response = await service.GetSynonymAsync(SelectedSource, text);
            if (response != null) {
                foreach (var result in response.results)
                {
                    foreach (var lexicalEntry in result.lexicalEntries)
                    {
                        foreach (var entry in lexicalEntry.entries)
                        {
                            foreach (var sense in entry.senses)
                            {
                                foreach (var anonym in sense.antonyms ?? Enumerable.Empty<Antonym>())
                                {
                                    SynonymResults.Add(anonym.text);
                                }
                            }
                        }
                    }
                }
            }
        }





        private async void TranslateClick(string obj) {
            if (obj.Length == 0) return;
            //TranslateResults.Clear();
            TranslationResults.Clear();
            SynonymResults.Clear();
            AntonymResults.Clear();
            SentencesResult.Clear();

            var response = await service.GetTranslationsAsync(SelectedSource, obj, SelectedDestination);
            if (response != null) {
                foreach (var item in response.results) {
                    foreach (var le in item.lexicalEntries) {
                        foreach (var entry in le.entries)
                        {
                            foreach(var sens in entry.senses)
                            {
                                foreach(var translation in sens.translations ?? Enumerable.Empty<Translation1>())
                                {
                                    TranslationResults.Add(translation.text);
                                }
                            }
                        }
                    }
                }
            } else if (SelectedDestination == null) {
                var messageDialog = new MessageDialog("Choose a destination language!") {
                    Title = "Error"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            } else {
                var messageDialog = new MessageDialog("There is no translation for that word!") {
                    Title = "Warning"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
        }



        /// <summary>
        /// Starting point after click on Start Now button. Loads all languages (first ComboBox).
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="mode"></param>
        /// <param name="suspensionState"></param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
           var response = await service.GetLanguagesAsync();
           var results = response.results;

           // var values = results as ICollection<Result>;



          // List<Result> AvailableLanguages = results.GroupBy(lang => lang.sourceLanguage.id)
                                                //.Select(group => group.First())
                                                //.ToList();


            //values.RemoveAll(a => values.Exists(w => w.sourceLanguage == a.sourceLanguage));

            //.GroupBy(lang => lang.sourceLanguage.id)
            //                                       .Select(group => group.First())
            //                                         .ToList();

            //AvailableLanguages.ForEach(x => Languages.Add(x));


            foreach (var lang in results)
            {
                // csak azokat töltsük be, aminek van forrás és célnyelve
                if (lang.sourceLanguage != null && lang.targetLanguage != null)
                {
                    AllLanguages.Add(lang);
                }

            }
            //Required, unless Converter is not invoked after update.
            RaisePropertyChanged(nameof(AllLanguages));
            await base.OnNavigatedToAsync(parameter, mode, suspensionState);
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        /*public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);*/
    }
}
