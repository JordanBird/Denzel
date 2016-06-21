using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public abstract class EventEpisode
    {
        public string EventType { get; set; }
        public string Series_Id { get; set; }
        public string Series_Title { get; set; }
        public string Series_TvdbId { get; set; }
    }
}