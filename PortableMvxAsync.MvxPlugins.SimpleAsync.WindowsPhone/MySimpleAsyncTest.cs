using System.Threading;
using System.Threading.Tasks;

namespace PortableMvxAsync.MvxPlugins.SimpleAsync.WindowsPhone
{
    public class MySimpleAsyncTest : ISimpleAsyncTester
    {
        // note that this method does NOT need "async" because it is not awaiting anything
        // it is doing the work that the CALLER will be "await" to be done
        public Task<string> LongRunningMethodAsync(string message)
        {
            // use this old school one for now
            return Task.Factory.StartNew<string>(() => LongRunningMethod(message));

            // Note that I cannot use original Task.Run here with references I have..
            // return Task.Run<string>(() => LongRunningMethod(message));

            // TODO: I don't have access to Task.Run BUT I do have TaskEx.Run in Async Lib?.  Is that okay to use?
            // return TaskEx.Run<string>(() => LongRunningMethod(message));

        }

        private string LongRunningMethod(string message)
        {
            Thread.Sleep(2000);
            return "Hello " + message;
        }
    }
}

