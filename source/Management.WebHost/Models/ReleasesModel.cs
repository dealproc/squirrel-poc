using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Management.WebHost.Models {
    public class ReleasesModel {
        public IEnumerable<FilesModel> Files { get; set; }
        public class FilesModel {
            public string Filename { get; set; }
            public string Url { get; set; }
        }
    }
}