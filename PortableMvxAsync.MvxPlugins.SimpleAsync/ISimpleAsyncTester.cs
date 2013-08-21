using System.Threading.Tasks;

namespace PortableMvxAsync.MvxPlugins.SimpleAsync
{
    public interface ISimpleAsyncTester
    {
        Task<string> LongRunningMethodAsync(string message);
    }
}
