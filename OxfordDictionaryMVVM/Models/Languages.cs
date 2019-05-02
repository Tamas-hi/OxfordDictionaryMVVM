using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxfordDictionaryMVVM.Models {

    /// <summary>
    /// Fetch all data from API to list languages.
    /// </summary>
    public class Languages {
        public Metadata metadata { get; set; }
        public Result[] results { get; set; }
    }

    /// <summary>
    /// Metadata to our languages, it is not used in my project.
    /// </summary>
    public class Metadata {
    }

    /// <summary>
    /// Result of the async method call, used to determine source and target languages.
    /// </summary>
    public class Result {
        public string region { get; set; }
        public string source { get; set; }
        public Sourcelanguage sourceLanguage { get; set; }
        public Targetlanguage targetLanguage { get; set; }
        public string type { get; set; }
    }

    /// <summary>
    /// Class for the source languages.
    /// </summary>
    public class Sourcelanguage {
        public string id { get; set; }
        public string language { get; set; }
    }

    /// <summary>
    /// Class for the target languages.
    /// </summary>
    public class Targetlanguage {
        public string id { get; set; }
        public string language { get; set; }
    }

}
