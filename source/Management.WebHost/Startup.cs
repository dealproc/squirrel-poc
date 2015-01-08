using Microsoft.Owin.Extensions;
using Owin;

namespace Management.WebHost {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseNancy();
            app.UseStageMarker(PipelineStage.MapHandler);
        }
    }
}