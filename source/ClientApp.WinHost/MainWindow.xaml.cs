using Squirrel;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ClientApp.WinHost {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            var settings = new RegistrySettings();

            txtUpdateUrl.TextChanged += (s, e) => {
                settings.UpdateUrl = (s as TextBox).Text;
            };

            btnCheckForUpdates.Click += async (s, e) => {
                try {
                    using (var updateMgr = new UpdateManager(settings.UpdateUrl, settings.PackageId, FrameworkVersion.Net45)) {
                        txtSystemMessages.AppendText("Checking for updates" + Environment.NewLine);
                        var updateInfo = await updateMgr.CheckForUpdate(ignoreDeltaUpdates: false, 
                            progress: (progess) => {
                                txtSystemMessages.AppendText(string.Format("Download progress: {0}", progess));
                            }
                        );

                        if (updateInfo == null) {
                            txtSystemMessages.AppendText("No updates were found." + Environment.NewLine + Environment.NewLine);
                        } else if (!updateInfo.ReleasesToApply.Any()) {
                            txtSystemMessages.AppendText("System is up to date." + Environment.NewLine + Environment.NewLine);
                        } else {
                            foreach (var release in updateInfo.ReleasesToApply.OrderBy(x => x.Version)) {
                                txtSystemMessages.AppendText(string.Format("Version {0} is available." + Environment.NewLine, release.Version));
                            }
                        }
                    }
                } catch (Exception ex) {
                    AppendMessage(ex);
                }
            };

            btnApplyUpdates.Click += (s, e) => {
                using (var updateMgr = new UpdateManager(settings.UpdateUrl, settings.PackageId, FrameworkVersion.Net45)) {
                    try {
                        txtSystemMessages.AppendText("Downloading updates.");
                        updateMgr.UpdateApp((progess) => {
                            txtSystemMessages.AppendText(string.Format("Download progress: {0}", progess));
                        });
                    } catch (Exception ex) {
                        AppendMessage(ex);
                    }
                }
            };

            Loaded += (s, e) => {
                txtUpdateUrl.Text = settings.UpdateUrl;
                txtProductVersion.Text = FileVersionInfo.GetVersionInfo(this.GetType().Assembly.Location).FileVersion;
            };
        }

        private void AppendMessage(Exception ex) {
            txtSystemMessages.AppendText(ex.Message + Environment.NewLine);
        }
    }
}
