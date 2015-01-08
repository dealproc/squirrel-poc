using Owin;

namespace Management.WebHost {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseNancy();
        }
    }
}