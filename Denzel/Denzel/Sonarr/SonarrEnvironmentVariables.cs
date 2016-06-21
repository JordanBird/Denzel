using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public class SonarrEnvironmentVariables
    {
        public SupportingData SupportingData = new SupportingData();
        public Grab Grab = new Grab();
        public DownloadUpgrade DownloadUpgrade = new DownloadUpgrade();
        public Rename Rename = new Rename();
    }

    public class SupportingData : BaseEnvironmentVariablesSet
    {
        public string EventType { get { return GetEnvironmentVariable("eventtype"); } }
    }

    public class Grab : EpisodeEventSet
    {
        public override string Prefix { get { return "release"; } }
        public override string ReferenceEventType { get { return "Grab"; } }
        
        public string Title { get { return GetEnvironmentVariable(Prefix, "title"); } }
        public string Indexer { get { return GetEnvironmentVariable(Prefix, "indexer"); } }
        public string Size { get { return GetEnvironmentVariable(Prefix, "size"); } }
    }

    public class DownloadUpgrade : EpisodeEventSet
    {
        public override string Prefix { get { return "episodefile"; } }
        public override string ReferenceEventType { get { return "Download"; } }

        public string Id { get { return GetEnvironmentVariable(Prefix, "id"); } }
        public string RelativePath { get { return GetEnvironmentVariable(Prefix, "relativepath"); } }
        public string Path { get { return GetEnvironmentVariable(Prefix, "path"); } }
        public string EpisodeAirDates { get { return GetEnvironmentVariable(Prefix, "episodeairdates"); } }
        public string EpisodeAirDatesUtc { get { return GetEnvironmentVariable(Prefix, "episodeairdatesutc"); } }
        public string EpisodeTitles { get { return GetEnvironmentVariable(Prefix, "episodetitles"); } }
        public string Quality { get { return GetEnvironmentVariable(Prefix, "quality"); } }
        public string QualityVersion { get { return GetEnvironmentVariable(Prefix, "qualityversion"); } }
        public string SceneName { get { return GetEnvironmentVariable(Prefix, "scenename"); } }
        public string SourcePath { get { return GetEnvironmentVariable(Prefix, "sourcepath"); } }
        public string SourceFolder { get { return GetEnvironmentVariable(Prefix, "sourcefolder"); } }
        public virtual string Series_Path { get { return GetEnvironmentVariable("series_path"); } }
    }

    public class Rename : BaseEnvironmentVariablesSet
    {
        public override string ReferenceEventType { get { return "Rename"; } }
        public virtual string Series_Path { get { return GetEnvironmentVariable("series_path"); } }
    }

    public class EpisodeEventSet : BaseEnvironmentVariablesSet
    {
        public string EpisodeCount { get { return GetEnvironmentVariable(Prefix, "episodecount"); } }
        public string SeasonNumber { get { return GetEnvironmentVariable(Prefix, "seasonnumber"); } }
        public string EpisodeNumbers { get { return GetEnvironmentVariable(Prefix, "episodenumbers"); } }
        public string ReleaseGroup { get { return GetEnvironmentVariable(Prefix, "releasegroup"); } }
    }

    public class BaseEnvironmentVariablesSet
    {
        private string SonarrPrefix = "sonarr";
        public virtual string Prefix { get { return "NOTSET"; } }
        public virtual string ReferenceEventType { get { return "NOTSET"; } }

        public string Series_Id { get { return GetEnvironmentVariable("series_id"); } }
        public string Series_Title { get { return GetEnvironmentVariable("series_title"); } }
        public string Series_TvdbId { get { return GetEnvironmentVariable("series_tvdbId"); } }
        public string Series_Type { get { return GetEnvironmentVariable("series_type"); } }

        protected string GetEnvironmentVariable(string variableName)
        {
            return Environment.GetEnvironmentVariable($"{SonarrPrefix}_{variableName}");
        }

        protected string GetEnvironmentVariable(string prefix, string variableName)
        {
            return Environment.GetEnvironmentVariable($"{SonarrPrefix}_{prefix}_{variableName}");
        }
    }
}