using Nancy;
using Nancy.Conventions;
namespace Management.WebHost {
    public class NancyBootstrapperWithCustomizations : DefaultNancyBootstrapper {
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions) {
            base.ConfigureConventions(nancyConventions);
            Conventions.StaticContentsConventions.AddDirectory("/Releases");
        }
    }
}