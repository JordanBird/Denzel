using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public class EventEpisodeRename : EventEpisode
    {
        public string Series_Path { get; set; }
    }
}