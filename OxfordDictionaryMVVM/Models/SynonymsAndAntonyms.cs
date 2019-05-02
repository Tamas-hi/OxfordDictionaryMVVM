using System.Collections.Generic;
using OxfordDictionaryMVVM.Models;

namespace Oxfordify.Models {

    /// <summary>
    /// Fetch the needed data from API to list synonyms and antonyms.
    /// </summary>
    public class SynonymsAndAntonyms {
        public Metadata metadata { get; set; }
        public SAAResult[] results { get; set; }
    }

    public class SAAResult {
        public string id { get; set; }
        public string language { get; set; }
        public SAALexicalentry[] lexicalEntries { get; set; }
        public string type { get; set; }
        public string word { get; set; }
    }

    public class SAALexicalentry {
        public SAAEntry[] entries { get; set; }
        public string language { get; set; }
        public string lexicalCategory { get; set; }
        public string text { get; set; }
        public SAAVariantform1[] variantForms { get; set; }
    }

    public class SAAEntry {
        public string homographNumber { get; set; }
        public SAASens[] senses { get; set; }
        public SAAVariantform[] variantForms { get; set; }
    }

    public class SAASens {
        public Antonym[] antonyms { get; set; }
        public string[] domains { get; set; }
        public SAAExample[] examples { get; set; }
        public string id { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public SAASubsens[] subsenses { get; set; }
        public Synonym[] synonyms { get; set; }
    }

    public class Antonym {
        public string[] domains { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class SAAExample {
        public string[] definitions { get; set; }
        public string[] domains { get; set; }
        public SAANote[] notes { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string[] senseIds { get; set; }
        public string text { get; set; }
        public SAATranslation[] translations { get; set; }
    }

    public class SAANote {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class SAATranslation {
        public string[] domains { get; set; }
        public SAAGrammaticalfeature[] grammaticalFeatures { get; set; }
        public string language { get; set; }
        public SAANote1[] notes { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class SAAGrammaticalfeature {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class SAANote1 {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class SAASubsens {
    }

    public class Synonym {
        public string[] domains { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class SAAVariantform {
        public string[] regions { get; set; }
        public string text { get; set; }
    }

    public class SAAVariantform1 {
        public string[] regions { get; set; }
        public string text { get; set; }
    }

}
