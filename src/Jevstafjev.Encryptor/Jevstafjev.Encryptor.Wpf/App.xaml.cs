using DryIoc;
using Jevstafjev.Encryptor.Wpf.Views;
using Prism.Ioc;
using System.Windows;

namespace Jevstafjev.Encryptor.Wpf
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }
    }
}
