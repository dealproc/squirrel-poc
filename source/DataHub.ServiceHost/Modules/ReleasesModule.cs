﻿using Nancy;
using System.IO;
using System.Reflection;
namespace DataHub.ServiceHost.Modules {
    public class ReleasesModule : NancyModule {
        public ReleasesModule() : base("/install") {
            Get[""] = parameters => Response.AsFile("Releases/index.html", "text/html");
            Get["releases"] = parameters => Response.FromStream(File.OpenRead("./Releases/RELEASES"), "text/plain");
        }
    }
}