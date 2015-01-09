using Owin;

namespace DataHub.ServiceHost {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseNancy();
            //StaticConfiguration.DisableErrorTraces = false;
        }
    }
}
