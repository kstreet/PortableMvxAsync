using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace PortableMvxAsync.MvxPlugins.SimpleAsync.WindowsPhone
{
    // Plugin boilerplate code for the Implementation-side of an Mvx Plugin
    public class Plugin : IMvxPlugin
    {
        // you can be certain that this
        // Plugin Load method will only be called once
        public void Load()
        {
            // can use the same IoC methods here that
            // you use in Setup and App

            // whenever someone asks for an ISimpleAsyncTester on THIS platform
            // give them a MySimpleAsyncTest from this DLL
            Mvx.RegisterType<ISimpleAsyncTester, MySimpleAsyncTest>();
        }
    }
}
