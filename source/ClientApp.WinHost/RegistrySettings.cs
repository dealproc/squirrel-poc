using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.WinHost {
    public class RegistrySettings {
        RegistryKey _ApplicationKey;
        public RegistrySettings() {
            _ApplicationKey = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);

            if (!_ApplicationKey.GetSubKeyNames().Any(sk => sk.Equals("Midnight Oil Systems"))) {
                _ApplicationKey.CreateSubKey("Midnight Oil Systems");
            }
            _ApplicationKey = _ApplicationKey.OpenSubKey("Midnight Oil Systems", true);

            if (!_ApplicationKey.GetSubKeyNames().Any(sk => sk.Equals("ClientApp"))) {
                _ApplicationKey.CreateSubKey("ClientApp");
            }
            _ApplicationKey = _ApplicationKey.OpenSubKey("ClientApp", true);
        }

        public string UpdateUrl {
            get {
                if (_ApplicationKey.GetValueNames().Any(key => key.Equals("Update Url"))) {
                    return _ApplicationKey.GetValue("Update Url").ToString();
                }
                return string.Empty;
            }
            set { _ApplicationKey.SetValue("Update Url", value); }
        }
        public string PackageId {
            get { return "clientapp"; }
        }
    }
}
