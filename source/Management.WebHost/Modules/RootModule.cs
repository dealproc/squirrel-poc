using Nancy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Management.WebHost.Modules {
    public class RootModule : NancyModule {
        public RootModule()
            : base("/") {
            Get["/"] = parameters => {
                DirectoryInfo directory = new DirectoryInfo(HostingEnvironment.MapPath("~/Releases"));
                var files = directory.GetFiles().ToList();
                var model = new Models.ReleasesModel();
                var physPath = HostingEnvironment.ApplicationPhysicalPath;
                model.Files = files.Select(f => {
                    var fileUrl = f.FullName.Replace(physPath, string.Empty).Replace("\\", "/");
                    if (!fileUrl.StartsWith("/")) {
                        fileUrl = "/" + fileUrl;
                    }
                    return new Models.ReleasesModel.FilesModel { Filename = f.Name, Url = fileUrl };
                });

                return View[model];
            };
        }
    }
}