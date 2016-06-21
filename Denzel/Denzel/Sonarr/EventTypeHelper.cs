using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public class EventTypeHelper
    {
        private const string _prefix = "sonarr";

        private const string _prefixGrab = "release";
        private const string _prefixDownloadOrUpgrade = "episodefile";

        private const string _eventType = "eventtype";
        private const string _seriesTitle = "series_title";
        private const string _seasonNumber = "seasonnumber";
        private const string _episodeNumbers = "episodenumbers";
        private const string _episodeTitles = "episodetitles";
        private const string _quality = "quality";

        public string GetEventType()
        {
            return BaseReturn(_eventType);
        }

        public string GetSeriesTitle()
        {
            return BaseReturn(_seriesTitle);
        }

        public string GetSeasonNumber(string eventType)
        {
            return BaseReturn($"{GetPrefixForEventType(eventType)}_{_seasonNumber}");
        }

        public string GetGetEpisodeNumbers(string eventType)
        {
            return BaseReturn($"{GetPrefixForEventType(eventType)}_{_episodeNumbers}");
        }

        public string GetGetEpisodeTitles(string eventType)
        {
            return BaseReturn($"{GetPrefixForEventType(eventType)}_{_episodeTitles}");
        }

        public string GetQuality(string eventType)
        {
            return BaseReturn($"{GetPrefixForEventType(eventType)}_{_quality}");
        }

        private string GetPrefixForEventType(string eventType)
        {
            switch (eventType)
            {
                case "Grab":
                    return _prefixGrab;
                case "Download":
                    return _prefixDownloadOrUpgrade;
                default:
                    return "";
            }
        }

        private string BaseReturn(string requested)
        {
            return $"{Environment.GetEnvironmentVariable($"{_prefix}_{requested}")}";
        }
    }
}