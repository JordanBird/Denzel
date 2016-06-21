using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public class EventEpisodeDownload : EventEpisode
    {
        public string Series_Path { get; set; }
        public string Series_Type { get; set; }
        public string EpisodeFile_Id { get; set; }
        public string EpisodeFile_RelativePath { get; set; }
        public string EpisodeFile_Path { get; set; }
        public string EpisodeFile_EpisodeCount { get; set; }
        public string EpisodeFile_SeasonNumber { get; set; }
        public string EpisodeFile_EpisodeNumbers { get; set; }
        public string EpisodeFile_EpisodeAirDates { get; set; }
        public string EpisodeFile_EpisodeAirDatesUtc { get; set; }
        public string EpisodeFile_EpisodeTitles { get; set; }
        public string EpisodeFile_Quality { get; set; }
        public string EpisodeFile_QualityVersion { get; set; }
        public string EpisodeFile_ReleaseGroup { get; set; }
        public string EpisodeFile_SceneName { get; set; }
        public string EpisodeFile_SourcePath { get; set; }
        public string EpisodeFile_SourceFolder { get; set; }
    }
}