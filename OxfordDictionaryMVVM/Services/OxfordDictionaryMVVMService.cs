using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OxfordDictionaryMVVM.Models;
using Oxfordify.Models;

namespace OxfordDictionaryMVVM.Services {
    public class OxfordDictionaryMVVMService {

        private readonly Uri serverUrl = new Uri("https://od-api.oxforddictionaries.com");

        /// <summary>
        /// A generic method which calls GET asynchronously and deserializes result from JSON. Handles exceptions e.g., no word found.
        /// </summary>
        /// <typeparam name="T">Type of the returned result.</typeparam>
        /// <param name="uri">The uri to fetch from. </param>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(Uri uri) {
            using (var client = new HttpClient()) {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("app_id", "737bf108");
                client.DefaultRequestHeaders.Add("app_key", "5f69062e1685769a904ffaa7c56b34cb");
                var response = await client.GetAsync(uri);
                // pl. ha nincs találat az adott szóra
                if (response.IsSuccessStatusCode) {
                    var json = await response.Content.ReadAsStringAsync();
                    T result = JsonConvert.DeserializeObject<T>(json);
                    return result;
                } 
                else {
                    return default(T);
                }
            }
        }

        /// <summary>
        /// Get the languages asynchronously using <see cref="GetAsync{T}(Uri)"/>
        /// </summary>
        /// <returns>The languages.</returns>
        public async Task<Languages> GetLanguagesAsync() {
           return await GetAsync<Languages>(new Uri(serverUrl, "/api/v1/languages"));
        }

        /// <summary>
        /// Get the translations asynchronously using <see cref="GetAsync{T}(Uri)"/>
        /// </summary>
        /// <param name="source_translation_language"></param>
        /// <param name="word_id"></param>
        /// <param name="target_translation_language"></param>
        /// <returns></returns>
        public async Task<Translations> GetTranslationsAsync(string source_translation_language, string word_id, string target_translation_language) {
            return await GetAsync<Translations>(new Uri(serverUrl, "/api/v1/entries/" +
                                                                    source_translation_language + "/" +
                                                                    word_id + "/" +
                                                                    "translations=" + target_translation_language));
        }

        public async Task<Thesaurus> GetSynonymAsync(string source_lang, string word_id) {
            return await GetAsync<Thesaurus>(new Uri(serverUrl, "api/v1/entries" + "/" + source_lang + "/" + word_id + "/" + "synonyms;antonyms"));
        }

        public async Task<Sentences> GetSentenceAsync(string source_lang, string word_id)
        {
            return await GetAsync<Sentences>(new Uri(serverUrl, "api/v1/entries" + "/" + source_lang + "/" + word_id + "/" + "sentences"));
        }


    }
}
