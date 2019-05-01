using System.Collections.Generic;
using OxfordDictionaryMVVM.Models;

namespace Oxfordify.Models {
    /// <summary>
    /// Model classes for the Oxford Dictionaries API
    /// </summary>
    /// <remarks>
    /// Documentation: https://developer.oxforddictionaries.com/documentation
    /// </remarks>
    public class Thesaurus {
        public Metadata metadata { get; set; }
        public List<HeadwordThesaurus> results { get; set; }
    }

    public class HeadwordThesaurus {
        public string id { get; set; }
        public string language { get; set; }
        public List<ThesaurusLexicalEntry> lexicalEntries { get; set; }
        public string type { get; set; }
        public string word { get; set; }
    }

    public class ThesaurusLexicalEntry {
        public List<ThesaurusEntry> entries { get; set; }
        public string language { get; set; }
        public string lexicalCategory { get; set; }
        public string text { get; set; }
        public List<ThesaurusVariantform1> variantForms { get; set; }
    }

    public class ThesaurusEntry {
        public string homographNumber { get; set; }
        public List<ThesaurusSense> senses { get; set; }
        public List<ThesaurusVariantform> variantForms { get; set; }
    }

    public class ThesaurusSense {
        public List<Antonym> antonyms { get; set; }
        public List<string> domains { get; set; }
        public List<ThesaurusExample> examples { get; set; }
        public string id { get; set; }
        public List<string> regions { get; set; }
        public List<string> registers { get; set; }
        public List<ThesaurusSense> subsenses { get; set; }
        public List<Synonym> synonyms { get; set; }
    }

    public class Antonym {
        public List<string> domains { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public List<string> regions { get; set; }
        public List<string> registers { get; set; }
        public string text { get; set; }
    }

    public class ThesaurusExample {
        public List<string> definitions { get; set; }
        public List<string> domains { get; set; }
        public List<ThesaurusNote> notes { get; set; }
        public List<string> regions { get; set; }
        public List<string> registers { get; set; }
        public List<string> senseIds { get; set; }
        public string text { get; set; }
        public List<Translation> translations { get; set; }
    }

    public class ThesaurusNote {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class ThesaurusNote1 {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Synonym {
        public List<string> domains { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public List<string> regions { get; set; }
        public List<string> registers { get; set; }
        public string text { get; set; }
    }

    public class ThesaurusVariantform {
        public List<string> regions { get; set; }
        public string text { get; set; }
    }

    public class ThesaurusVariantform1 {
        public List<string> regions { get; set; }
        public string text { get; set; }
    }
}
