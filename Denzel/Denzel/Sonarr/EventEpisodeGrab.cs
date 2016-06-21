using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public class EventEpisodeGrab : EventEpisode
    {
        public string Series_Type { get; set; }
        public string Release_EpisodeCount { get; set; }
        public string Release_SeasonNumber { get; set; }
        public string Release_EpisodeNumbers { get; set; }
        public string Release_Title { get; set; }
        public string Release_Indexer { get; set; }
        public string Release_Size { get; set; }
        public string Release_ReleaseGroup { get; set; }
    }
}