using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System.IO;
using System.Reflection;

namespace DataHub.ServiceHost {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseStaticFiles(new StaticFileOptions {
                RequestPath = new PathString("/releases"),
                FileSystem = new PhysicalFileSystem(
                    Path.Combine(
                        Path.GetDirectoryName(
                            Assembly.GetExecutingAssembly().Location
                        ), 
                        "Releases"
                    )
                ),
                ServeUnknownFileTypes = true
            });
            app.UseNancy();
            //StaticConfiguration.DisableErrorTraces = false;
        }
    }
}