using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Classes
{
    public class DenzelArguments
    {
        public string AccessToken { get; set; }

        public string OnGrabTitle { get; set; }
        public string OnGrabBody { get; set; }

        public string OnDownloadTitle { get; set; }
        public string OnDownloadBody { get; set; }

        public string OnRenameTitle { get; set; }
        public string OnRenameBody { get; set; }

        public string OnAllTitle { get; set; }
        public string OnAllBody { get; set; }

        public string ArgsFileLocation { get; set; }
    }
}