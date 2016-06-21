using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Sonarr
{
    public class QualityTypes
    {
        public string[] SonarrQualityTypes { get; set; } = new string[]
        {
            "Unknown",
            "SDTV",
            "WEBDL-480p",
            "DVD",
            "HDTV-720p",
            "HDTV-1080p",
            "Raw-HD",
            "WEBDL-720p",
            "Bluray-720p",
            "WEBDL-1080p",
            "Bluray-1080p",
            "HDTV-2160p",
            "Bluray-2160p"
        };
    }
}