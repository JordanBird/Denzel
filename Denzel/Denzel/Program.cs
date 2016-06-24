using Denzel.Classes;
using Denzel.Factories;
using Denzel.Logger;
using Denzel.NotificationServices.PushBullet;
using Denzel.Sonarr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel
{
    class Program
    {
        static void Main(string[] args)
        {
            DenzelArguments denzelArgs = new DenzelArguments();
            if (args.Length > 0)
            {
                denzelArgs = new DenzelArgumentsBuilder().BuildDenzelArgumentsFromArgsString(args[0]);
            }

            var logger = new Slogger();
            var loggerFactory = new LoggerFactory();

            logger.AddToLog(loggerFactory.BuildLogForStartup());
            RunDenzel(denzelArgs, logger, loggerFactory);

            logger.AddToLog(loggerFactory.BuildLogForExit());
        }

        static void RunDenzel(DenzelArguments args, Slogger logger, LoggerFactory loggerFactory)
        {
            var eventEpisode = new SonarrEnvironmentHelper().BuildBaseEventEpisodeFromEnvironment();

            if (eventEpisode == null)
            {
                logger.AddToLog(loggerFactory.BuildLogForError("EventEpisode is null so cannot notify."));
                return;
            }

            logger.AddToLog(loggerFactory.BuildLogForInfo("Building Push."));
            var pushBulletPush = new SonarrPushBulletPushFactory().BuildPushBulletPushForEventEpisode(eventEpisode);
            logger.AddToLog(loggerFactory.BuildLogForInfo("Sending Push."));
            new PushBullet(args.AccessToken).Send(pushBulletPush);
            logger.AddToLog(loggerFactory.BuildLogForInfo("Sent Push."));
        }
    }
}