using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxfordDictionaryMVVM.Models;
using Windows.UI.Xaml.Data;

namespace OxfordDictionaryMVVM.Converters
{
    /// <summary>
    /// A basic converter to transform the languages of result.
    /// </summary>
    public class LanguageConverter : IValueConverter
    {
        /// <summary>
        /// This method makes the conversion to seperate languages.
        /// </summary>
        /// <param name="value">The value that needs to be converted.</param>
        /// <param name="targetType">The type of the controller's property.</param>
        /// <param name="parameter">Optional extra parameter.</param>
        /// <param name="language">Culture information for localization.</param>
        /// <returns>Languages in converted form</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            
            var results = value as List<Result>;



            var temp = from r in results
                       group r by r.sourceLanguage.id into s
                       let first = s.First()
                       select first;

            var separateLanguages = temp.ToList();

            return separateLanguages;

            /*var values = value as ICollection<Result>;
            if (values == null)
                return null;

            List<Result> distinctBySource = values
                .GroupBy(lang => lang.sourceLanguage.id)
                .Select(group => group.First())
                .ToList();

            return distinctBySource;*/
        }

        /// <summary>
        /// This method makes the conversion back to original value.
        /// </summary>
        /// <param name="value">The value that needs to be converted.</param>
        /// <param name="targetType">The type of the controller's property.</param>
        /// <param name="parameter">Optional extra parameter.</param>
        /// <param name="language">Culture information for localization.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
