using Nancy;
namespace DataHub.ServiceHost.Modules {
    public class ReleasesModule : NancyModule {
        public ReleasesModule() : base("/releases") {
            Get["/"] = parameters => Response.AsFile("Releases/index.html", "text/html");
        }
    }
}