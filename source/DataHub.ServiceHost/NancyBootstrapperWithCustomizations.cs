using Nancy;
using Nancy.Conventions;
namespace DataHub.ServiceHost {
    public class NancyBootstrapperWithCustomizations : DefaultNancyBootstrapper {
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions) {
            base.ConfigureConventions(nancyConventions);
            Conventions.StaticContentsConventions.AddDirectory("/releases");
            Conventions.StaticContentsConventions.AddDirectory("/Content");
            Conventions.StaticContentsConventions.AddDirectory("/fonts");
            Conventions.StaticContentsConventions.AddDirectory("/Scripts");
        }
    }
}