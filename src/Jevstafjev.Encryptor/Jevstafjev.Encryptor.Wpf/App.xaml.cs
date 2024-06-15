using DryIoc;
using Jevstafjev.Encryptor.Contracts;
using Jevstafjev.Encryptor.Wpf.Views;
using Prism.Ioc;
using System.IO;
using System.Reflection;
using System.Windows;

namespace Jevstafjev.Encryptor.Wpf
{
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pluginsDirectory))
            {
                return;
            }

            var files = Directory.GetFiles(pluginsDirectory, "*.dll");
            foreach (var file in files)
            {
                var assembly = Assembly.LoadFile(file);
                var cipherTypes = assembly.GetExportedTypes().Where(x => x.IsAssignableTo(typeof(ICipher))).ToList();
                foreach (var type in cipherTypes)
                {
                    containerRegistry.Register(typeof(ICipher), type);
                }
            }
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }
    }
}
