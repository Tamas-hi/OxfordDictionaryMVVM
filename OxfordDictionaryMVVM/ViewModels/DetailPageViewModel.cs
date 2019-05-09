using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OxfordDictionaryMVVM.Models;
using OxfordDictionaryMVVM.Services;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Popups;
using Windows.UI.Xaml.Navigation;

namespace OxfordDictionaryMVVM.ViewModels
{
    /// <summary>
    /// Page of our Dictionary. You can translate, find synonyms - antonyms - sentences here.
    /// </summary>
    public class DetailPageViewModel : ViewModelBase
    {
        public ObservableCollection<Result> AllLanguages { get; set; } = new ObservableCollection<Result>();
        public ObservableCollection<Result> DestinationLanguages { get; set; } = new ObservableCollection<Result>();

        public ObservableCollection<string> Translations { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Synonyms { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Antonyms { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Sentences { get; set; } = new ObservableCollection<string>();

        public DelegateCommand<string> TranslateCommand { get; }
        public DelegateCommand<string> SynonymCommand { get; }
        public DelegateCommand<string> AntonymCommand { get; }
        public DelegateCommand<string> SentencesCommand { get; }

        /// <summary>
        /// Constructor used to apply Command pattern.
        /// </summary>
        public DetailPageViewModel()
        {
            TranslateCommand = new DelegateCommand<string>(TranslateClick);
            SynonymCommand = new DelegateCommand<string>(SynonymClick);
            AntonymCommand = new DelegateCommand<string>(AntonymClick);
            SentencesCommand = new DelegateCommand<string>(SentenceClick);
        }

        private string chosenSrc;

        public string ChosenSrc
        {
            get
            {
                return chosenSrc;
            }
            set
            {
                DestinationLanguages.Clear();
                chosenSrc = value;

                // filling DestinationLanguages with only the languages from allLanguages that has a sourceLanguage.id equivavelent to the chosen source.
                foreach (var lang in AllLanguages)
                {
                    if (lang.sourceLanguage.id == chosenSrc)
                    {
                        DestinationLanguages.Add(lang);
                    }
                }
            }
        }

        private async void SentenceClick(string obj)
        {
            Translations.Clear();
            Synonyms.Clear();
            Antonyms.Clear();
            Sentences.Clear();

            var reply = await new OxfordDictionaryMVVMService().GetSentenceAsync(chosenSrc, obj);

            if (reply != null)
            {
                foreach (var result in reply.results)
                {
                    foreach (var lexicalEntry in result.lexicalEntries)
                    {
                        foreach (var sentence in lexicalEntry.sentences)
                        {
                            Sentences.Add(sentence.text);
                        }
                    }
                }
            }

            // exception handling
            else if (ChosenSrc.ToString() != "en" && ChosenSrc.ToString() != "es")
            {
                var messageDialog = new MessageDialog("Sentences are not supported in this language at present.")
                {
                    Title = "Warning"
                };
                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("There is no example sentence for that word!")
                {
                    Title = "Warning"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
        }

        private async void SynonymClick(string obj)
        {
            Translations.Clear();
            Synonyms.Clear();
            Antonyms.Clear();
            Sentences.Clear();

            var reply = await new OxfordDictionaryMVVMService().GetSynonymAsync(chosenSrc, obj);

            if (reply != null)
            {
                foreach (var result in reply.results)
                {
                    foreach (var lexicalEntry in result.lexicalEntries)
                    {
                        foreach (var entry in lexicalEntry.entries)
                        {
                            foreach (var sense in entry.senses)
                            {
                                foreach (var synonym in sense.synonyms)
                                {
                                    Synonyms.Add(synonym.text);
                                }
                            }
                        }
                    }
                }
            }

            // exception handling 
            else if (ChosenSrc == null)
            {
                var messageDialog = new MessageDialog("Choose a source language!")
                {
                    Title = "Error"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
            else if (ChosenSrc.ToString() != "en")
            {
                var messageDialog = new MessageDialog("Synonyms are not supported in this language at present.")
                {
                    Title = "Warning"
                };
                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("There is no synonym for that word!")
                {
                    Title = "Warning"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
        }

        private async void AntonymClick(string obj)
        {
            Translations.Clear();
            Synonyms.Clear();
            Antonyms.Clear();
            Sentences.Clear();

            var reply = await new OxfordDictionaryMVVMService().GetAntonymAsync(chosenSrc, obj);

            if (reply != null)
            {
                foreach (var result in reply.results)
                {
                    foreach (var lexicalEntry in result.lexicalEntries)
                    {
                        foreach (var entry in lexicalEntry.entries)
                        {
                            foreach (var sense in entry.senses)
                            {
                                foreach (var anonym in sense.antonyms)
                                {
                                    Antonyms.Add(anonym.text);
                                }
                            }
                        }
                    }
                }
            }

            // exception handling
            else if (ChosenSrc == null)
            {
                var messageDialog = new MessageDialog("Choose a source language!")
                {
                    Title = "Error"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
            else if (ChosenSrc.ToString() != "en")
            {
                var messageDialog = new MessageDialog("Antonyms are not supported in this language at present.")
                {
                    Title = "Warning"
                };
                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("There is no antonym for that word!")
                {
                    Title = "Warning"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
        }

        public string ChosenDest { get; set; }

        private async void TranslateClick(string obj)
        {
            Translations.Clear();
            Synonyms.Clear();
            Antonyms.Clear();
            Sentences.Clear();

            var reply = await new OxfordDictionaryMVVMService().GetTranslationAsync(chosenSrc, obj, ChosenDest);

            if (reply != null)
            {
                foreach (var result in reply.results)
                {
                    foreach (var lexicalEntry in result.lexicalEntries)
                    {
                        foreach (var entry in lexicalEntry.entries)
                        {
                            foreach (var sense in entry.senses)
                            {
                                if (sense.translations == null) // exception handling
                                    return;
                                foreach (var translation in sense.translations)
                                {
                                    Translations.Add(translation.text);
                                }
                            }
                        }
                    }
                }
            } // exception handling
            else if (ChosenSrc == null)
            {
                var messageDialog = new MessageDialog("Choose a source language!")
                {
                    Title = "Error"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
            else if (ChosenDest == null)
            {
                var messageDialog = new MessageDialog("Choose a destination language!")
                {
                    Title = "Error"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("There is no translation for that word!")
                {
                    Title = "Warning"
                };

                messageDialog.Commands.Add(new UICommand("Close"));

                await messageDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Starting point after click on Start Now button. Loads all source languages (first ComboBox).
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="mode"></param>
        /// <param name="suspensionState"></param>
        /// <returns></returns>
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var languages = await new OxfordDictionaryMVVMService().GetLanguageAsync();
            var results = languages.results;
            if (results == null)
                return;

            foreach (var lang in results)
            {
                // load only those, which has source and target language too
                if (lang.sourceLanguage != null && lang.targetLanguage != null)
                {
                    AllLanguages.Add(lang);
                }

            }

            //Fire PropertyChangedEvent
            this.RaisePropertyChanged(nameof(AllLanguages));
            await base.OnNavigatedToAsync(parameter, mode, suspensionState);
        }

        /// <summary>
        /// Template 10 Minimal template -  When we navigate elsewhere from here.
        /// </summary>
        /// <param name="suspensionState"></param>
        /// <param name="suspending"></param>
        /// <returns></returns>
        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Task.CompletedTask;
        }

        /// <summary>
        /// Template 10 Minimal template -  When we navigate elsewhere from here.
        /// </summary>
        /// <param name="suspensionState"></param>
        /// <param name="suspending"></param>
        /// <returns></returns>
        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }
    }
}
