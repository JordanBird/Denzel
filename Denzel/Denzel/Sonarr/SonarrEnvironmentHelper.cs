using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public class SonarrEnvironmentHelper
    {
        public EventEpisode BuildBaseEventEpisodeFromEnvironment()
        {
            var environmentVariables = new SonarrEnvironmentVariables();

            var eventType = environmentVariables.SupportingData.EventType;

            switch (eventType)
            {
                case "Grab":
                    return GetGrabEventEpisode();
                case "Download":
                    return GetDownloadEventEpisode();
                case "Rename":
                    return GetRenameEventEpisode();
                default:
                    return null;
            }
        }

        private EventEpisode GetGrabEventEpisode()
        {
            var grab = new Grab();

            return new EventEpisodeGrab()
            {
                EventType = grab.ReferenceEventType,
                Release_EpisodeCount = grab.EpisodeCount,
                Release_EpisodeNumbers = grab.EpisodeNumbers,
                Release_Indexer = grab.Indexer,
                Release_ReleaseGroup = grab.ReleaseGroup,
                Release_SeasonNumber = grab.SeasonNumber,
                Release_Size = grab.Size,
                Release_Title = grab.Title,
                Series_Id = grab.Series_Id,
                Series_Title = grab.Series_Title,
                Series_TvdbId = grab.Series_TvdbId,
                Series_Type = grab.Series_Type
            };
        }

        private EventEpisode GetDownloadEventEpisode()
        {
            var download = new DownloadUpgrade();

            return new EventEpisodeDownload()
            {
                EpisodeFile_EpisodeAirDates = download.EpisodeAirDates,
                EpisodeFile_EpisodeAirDatesUtc = download.EpisodeAirDatesUtc,
                EpisodeFile_EpisodeCount = download.EpisodeCount,
                EpisodeFile_EpisodeNumbers = download.EpisodeNumbers,
                EpisodeFile_EpisodeTitles = download.EpisodeTitles,
                EpisodeFile_Id = download.Id,
                EpisodeFile_Path = download.Path,
                EpisodeFile_Quality = download.Quality,
                EpisodeFile_QualityVersion = download.QualityVersion,
                EpisodeFile_RelativePath = download.RelativePath,
                EpisodeFile_ReleaseGroup = download.ReleaseGroup,
                EpisodeFile_SceneName = download.SceneName,
                EpisodeFile_SeasonNumber = download.SeasonNumber,
                EpisodeFile_SourceFolder = download.SourceFolder,
                EpisodeFile_SourcePath = download.Path,
                EventType = download.ReferenceEventType,
                Series_Id = download.Id,
                Series_Path = download.Series_Path,
                Series_Title = download.Series_Title,
                Series_TvdbId = download.Series_TvdbId,
                Series_Type = download.Series_Type
            };
        }

        private EventEpisode GetRenameEventEpisode()
        {
            var rename = new Rename();

            return new EventEpisodeRename()
            {
                EventType = rename.ReferenceEventType,
                Series_Id = rename.Series_Id,
                Series_Path = rename.Series_Path,
                Series_Title = rename.Series_Title,
                Series_TvdbId = rename.Series_TvdbId
            };
        }
    }
}