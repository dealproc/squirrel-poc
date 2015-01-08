using Owin;

namespace DataHub.ServiceHost {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.UseNancy((config)=>{
                config.PerformPassThrough = context =>
                    context.Response.StatusCode == Nancy.HttpStatusCode.NotFound;
            });
        }
    }
}
