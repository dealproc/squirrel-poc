﻿using Nancy;
using Nancy.Conventions;
using System.IO;
using System.Reflection;
namespace DataHub.ServiceHost {
    public class NancyBootstrapperWithCustomizations : DefaultNancyBootstrapper {
        protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions) {
            base.ConfigureConventions(nancyConventions);

            Conventions.StaticContentsConventions.AddDirectory("/Content");
            Conventions.StaticContentsConventions.AddDirectory("/fonts");
            Conventions.StaticContentsConventions.AddDirectory("/Scripts");
        }
    }
}