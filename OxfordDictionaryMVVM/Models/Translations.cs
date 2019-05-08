namespace OxfordDictionaryMVVM.Models
{
    /// <summary>
    /// Fetch all data from Oxford Dictionaires API to translate.
    /// </summary>
    public class Translations
    {
        public Metadata metadata { get; set; }
        public Result2[] results { get; set; }
    }

    public class Result2
    {
        public string id { get; set; }
        public string language { get; set; }
        public Lexicalentry[] lexicalEntries { get; set; }
        public Pronunciation3[] pronunciations { get; set; }
        public string type { get; set; }
        public string word { get; set; }
    }

    public class Lexicalentry
    {
        public Derivativeof[] derivativeOf { get; set; }
        public Derivative[] derivatives { get; set; }
        public Entry[] entries { get; set; }
        public Grammaticalfeature3[] grammaticalFeatures { get; set; }
        public string language { get; set; }
        public string lexicalCategory { get; set; }
        public Note5[] notes { get; set; }
        public Pronunciation2[] pronunciations { get; set; }
        public string text { get; set; }
        public Variantform2[] variantForms { get; set; }
    }

    public class Derivativeof
    {
        public string[] domains { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class Derivative
    {
        public string[] domains { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class Entry
    {
        public string[] etymologies { get; set; }
        public Grammaticalfeature[] grammaticalFeatures { get; set; }
        public string homographNumber { get; set; }
        public Note[] notes { get; set; }
        public Pronunciation[] pronunciations { get; set; }
        public Sens[] senses { get; set; }
        public Variantform1[] variantForms { get; set; }
    }

    public class Grammaticalfeature
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Note
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Pronunciation
    {
        public string audioFile { get; set; }
        public string[] dialects { get; set; }
        public string phoneticNotation { get; set; }
        public string phoneticSpelling { get; set; }
        public string[] regions { get; set; }
    }

    public class Sens
    {
        public string[] crossReferenceMarkers { get; set; }
        public Crossreference[] crossReferences { get; set; }
        public string[] definitions { get; set; }
        public string[] domains { get; set; }
        public Example[] examples { get; set; }
        public string id { get; set; }
        public Note3[] notes { get; set; }
        public Pronunciation1[] pronunciations { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string[] short_definitions { get; set; }
        public Subsens[] subsenses { get; set; }
        public Thesauruslink[] thesaurusLinks { get; set; }
        public Translation1[] translations { get; set; }
        public Variantform[] variantForms { get; set; }
    }

    public class Crossreference
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Example
    {
        public string[] definitions { get; set; }
        public string[] domains { get; set; }
        public Note1[] notes { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string[] senseIds { get; set; }
        public string text { get; set; }
        public Translation[] translations { get; set; }
    }

    public class Note1
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Translation
    {
        public string[] domains { get; set; }
        public Grammaticalfeature1[] grammaticalFeatures { get; set; }
        public string language { get; set; }
        public Note2[] notes { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class Grammaticalfeature1
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Note2
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Note3
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Pronunciation1
    {
        public string audioFile { get; set; }
        public string[] dialects { get; set; }
        public string phoneticNotation { get; set; }
        public string phoneticSpelling { get; set; }
        public string[] regions { get; set; }
    }

    public class Subsens
    {
    }

    public class Thesauruslink
    {
        public string entry_id { get; set; }
        public string sense_id { get; set; }
    }

    public class Translation1
    {
        public string[] domains { get; set; }
        public Grammaticalfeature2[] grammaticalFeatures { get; set; }
        public string language { get; set; }
        public Note4[] notes { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class Grammaticalfeature2
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Note4
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Variantform
    {
        public string[] regions { get; set; }
        public string text { get; set; }
    }

    public class Variantform1
    {
        public string[] regions { get; set; }
        public string text { get; set; }
    }

    public class Grammaticalfeature3
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Note5
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Pronunciation2
    {
        public string audioFile { get; set; }
        public string[] dialects { get; set; }
        public string phoneticNotation { get; set; }
        public string phoneticSpelling { get; set; }
        public string[] regions { get; set; }
    }

    public class Variantform2
    {
        public string[] regions { get; set; }
        public string text { get; set; }
    }

    public class Pronunciation3
    {
        public string audioFile { get; set; }
        public string[] dialects { get; set; }
        public string phoneticNotation { get; set; }
        public string phoneticSpelling { get; set; }
        public string[] regions { get; set; }
    }

}
