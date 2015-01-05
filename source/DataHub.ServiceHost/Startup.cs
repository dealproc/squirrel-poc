using Owin;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHub.ServiceHost {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseNancy();
        }
    }

    public static class UpdateProcedure {
        public static void TryToUpdate() {
            using (var mgr = new UpdateManager(urlOrPath: "", applicationName: "", appFrameworkVersion: FrameworkVersion.Net45)) {
                SquirrelAwareApp.HandleEvents(
                    onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                    onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                    onAppUninstall: v => mgr.RemoveShortcutForThisExe()
                );
            }
        }
    }
}
