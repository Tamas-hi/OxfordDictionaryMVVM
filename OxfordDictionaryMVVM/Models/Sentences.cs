using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxfordDictionaryMVVM.Models
{

    public class Sentences
    {
        public Metadata metadata { get; set; }
        public SentenceResult[] results { get; set; }
    }

    public class SentenceResult
    {
        public string id { get; set; }
        public string language { get; set; }
        public SentenceLexicalentry[] lexicalEntries { get; set; }
        public string type { get; set; }
        public string word { get; set; }
    }

    public class SentenceLexicalentry
    {
        public SentenceGrammaticalfeature[] grammaticalFeatures { get; set; }
        public string language { get; set; }
        public string lexicalCategory { get; set; }
        public Sentence[] sentences { get; set; }
        public string text { get; set; }
    }

    public class SentenceGrammaticalfeature
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Sentence
    {
        public string[] definitions { get; set; }
        public string[] domains { get; set; }
        public SentenceNote[] notes { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string[] senseIds { get; set; }
        public string text { get; set; }
        public Translation[] translations { get; set; }
    }

    public class SentenceNote
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class SentenceTranslation
    {
        public string[] domains { get; set; }
        public SentenceGrammaticalfeature1[] grammaticalFeatures { get; set; }
        public string language { get; set; }
        public SentenceNote1[] notes { get; set; }
        public string[] regions { get; set; }
        public string[] registers { get; set; }
        public string text { get; set; }
    }

    public class SentenceGrammaticalfeature1
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class SentenceNote1
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

}
