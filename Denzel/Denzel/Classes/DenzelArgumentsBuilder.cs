using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzel.Classes
{
    public class DenzelArgumentsBuilder
    {
        public DenzelArguments BuildDenzelArgumentsFromArgsString(string args)
        {
            var denzelArguments = new DenzelArguments();

            args = args.Replace(",,", "[DELIMCOMMA]");
            var splitArgs = args.Split(',');
            
            foreach (var arg in splitArgs)
            {
                var argument = arg.Replace("[DELIMCOMMA]", ",");

                ParseArgToDenzelArguments(argument, denzelArguments);
            }

            return denzelArguments;
        }

        private DenzelArguments ParseArgToDenzelArguments(string argument, DenzelArguments denzelArguments)
        {
            argument = argument.Replace("==", "[DELIMEQUALS]");
            var argParts = argument.Split('=');

            return AddValueToDenzelArgumentsProp(argParts[0], argParts[1], denzelArguments);
        }

        private DenzelArguments AddValueToDenzelArgumentsProp(string argument, string value, DenzelArguments denzelArguments)
        {
            switch (argument.ToUpper())
            {
                case "ACCESSTOKEN":
                    denzelArguments.AccessToken = value;
                    break;
                case "ONGRABTITLE":
                    denzelArguments.OnGrabTitle = value;
                    break;
                case "ONGRABBODY":
                    denzelArguments.OnGrabBody = value;
                    break;
                case "ONDOWNLOADTITLE":
                    denzelArguments.OnDownloadTitle = value;
                    break;
                case "ONDOWNLOADBODY":
                    denzelArguments.OnDownloadBody = value;
                    break;
                case "ONRENAMETITLE":
                    denzelArguments.OnRenameTitle= value;
                    break;
                case "ONRENAMEBODY":
                    denzelArguments.OnRenameBody = value;
                    break;
                case "ONALLTITLE":
                    denzelArguments.OnAllTitle = value;
                    break;
                case "ONALLBODY":
                    denzelArguments.OnAllBody = value;
                    break;
                case "ARGSFILELOCATION":
                    denzelArguments.ArgsFileLocation = value;
                    break;
            }

            return denzelArguments;
        }
    }
}