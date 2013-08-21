using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace PortableMvxAsync.MvxPlugins.SimpleAsync
{
    // all Mvx PLugins have this same boilerplate code using this naming
    public class PluginLoader : IMvxPluginLoader
    {

        // another part of the Plugin convention is to add an instance of self
        public static readonly PluginLoader Instance = new PluginLoader();

        public void EnsureLoaded()
        {
            var pluginMgr = Mvx.Resolve<IMvxPluginManager>();

            // find the associated Plugin file for my platform based on my namespace name
            pluginMgr.EnsurePlatformAdaptionLoaded<PluginLoader>();
        }
    }
}

