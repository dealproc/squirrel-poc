using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.WinHost {
    class Sample {
        public async void Task() {
            using (var mgr = new UpdateManager(urlOrPath: "", applicationName: "", appFrameworkVersion: Squirrel.FrameworkVersion.Net45)) {
                var re = await mgr.UpdateApp();
            }
        }
    }
}