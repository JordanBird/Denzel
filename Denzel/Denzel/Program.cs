using Denzel.Factories;
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
            var eventEpisode = new SonarrEnvironmentHelper().BuildBaseEventEpisodeFromEnvironment();

            var pushBulletPush = new SonarrPushBulletPushFactory().BuildPushBulletPushForEventEpisode(eventEpisode);
            new PushBullet(args[0]).Send(pushBulletPush);
        }
    }
}