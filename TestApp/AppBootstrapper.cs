using System.Runtime.Versioning;
using System.Windows;
using Caliburn.Micro;
using TestApp.ViewModels;
namespace TestApp
{
    [SupportedOSPlatform("windows7.0")]
    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
}