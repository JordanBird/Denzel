using Denzel.Logger;
using Denzel.NotificationServices.PushBullet;
using Denzel.Sonarr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Factories
{
    public class SonarrPushBulletPushFactory
    {
        public PushBulletPush BuildPushBulletPushForEventEpisode(EventEpisode eventEpisode)
        {
            switch (eventEpisode.EventType)
            {
                case "Grab":
                    return BuildPushBulletPushForGrab(eventEpisode);
                case "Download":
                    return BuildPushBulletPushForDownload(eventEpisode);
                case "Rename":
                    return BuildPushBulletPushForRename(eventEpisode);
            }

            throw new ArgumentOutOfRangeException("Event type not currently supported.");
        }

        private PushBulletPush BuildPushBulletPushForGrab(EventEpisode eventEpisode)
        {
            var episode = (EventEpisodeGrab)eventEpisode;
            var quality = new QualityTypes().SonarrQualityTypes.FirstOrDefault(x => episode.Release_Title.Contains(x));

            if (String.IsNullOrEmpty(quality))
            {
                quality = "Unrecognised";
            }

            new Slogger().AddToLog(new LoggerFactory().BuildLogForInfo($"Quality parsed was: {quality}.")); //Debug possible sending bug.

            return new PushBulletPush()
            {
                Body = $"Sonarr grabbed {episode.Series_Title} · S{episode.Release_SeasonNumber}E{episode.Release_EpisodeNumbers} · {quality}.",
                Title = BuildPushBulletPushTitle(episode.EventType, episode.Series_Title, episode.Release_SeasonNumber, episode.Release_EpisodeNumbers, quality),
                URL = ""
            };
        }

        private PushBulletPush BuildPushBulletPushForDownload(EventEpisode eventEpisode)
        {
            var episode = (EventEpisodeDownload)eventEpisode;
            return new PushBulletPush()
            {
                Body = $"Sonarr downloaded {episode.Series_Title} · S{episode.EpisodeFile_SeasonNumber}E{episode.EpisodeFile_EpisodeNumbers} · {episode.EpisodeFile_Quality}.",
                Title = BuildPushBulletPushTitle(episode.EventType, episode.Series_Title, episode.EpisodeFile_SeasonNumber, episode.EpisodeFile_EpisodeNumbers, episode.EpisodeFile_Quality),
                URL = ""
            };
        }

        private PushBulletPush BuildPushBulletPushForRename(EventEpisode eventEpisode)
        {
            var episode = (EventEpisodeRename)eventEpisode;
            return new PushBulletPush()
            {
                Body = $"Sonarr renamed a {episode.Series_Title} episode.",
                Title = BuildPushBulletPushTitle(episode.EventType, episode.Series_Title),
                URL = ""
            };
        }

        private string BuildPushBulletPushTitle(string eventType, string title, string seasonNumber = "", string episodeNumbers = "", string quality = "")
        {
            string pushTitle = $"[{eventType[0]}] {title}";

            if (!String.IsNullOrEmpty(seasonNumber))
            {
                pushTitle += $" · S{seasonNumber}E{episodeNumbers} · {quality}";
            }

            return pushTitle;
        }
    }
}