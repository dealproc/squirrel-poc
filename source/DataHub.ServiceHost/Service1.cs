using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DataHub.ServiceHost {
    public partial class Service1 : ServiceBase {
        public static void Main() {
            if (Environment.UserInteractive) {
                var bootstrapper = new Service1();
                bootstrapper.OnStart(new string[0]);
                Console.WriteLine("Press any key to stop program.");
                Console.ReadLine();
                bootstrapper.OnStop();
            } else {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
            { 
                new Service1() 
            };
                ServiceBase.Run(ServicesToRun);
            }
        }

        IDisposable _WebApp;
        string _Url = "http://+:8080";

        public Service1() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            _WebApp = WebApp.Start<Startup>(_Url);
        }

        protected override void OnStop() {
            _WebApp.Dispose();
        }
    }
}
