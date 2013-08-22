using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using PortableMvxAsync.MvxPlugins.SimpleAsync;

namespace PortableMvxAsync.MvxUseThePlugin.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly ISimpleAsyncTester _asyncTesterPlugin;


        public FirstViewModel(ISimpleAsyncTester asyncTesterPlugin)
        {
            _asyncTesterPlugin = asyncTesterPlugin;
        }

        private string _hello = "Hello MvvmCross";
        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }

        private string _simpleAsyncText;
        public string SimpleAsyncText
        {
            get { return _simpleAsyncText; }
            set { _simpleAsyncText = value; RaisePropertyChanged(() => SimpleAsyncText); }
        }

        private MvxCommand _simpleAsyncCommand;
        public ICommand SimpleAsyncCommand
        {
            get
            {
                // TODO: Neither One of these cmd syntax Approaches makes the await error below go away
                _simpleAsyncCommand = _simpleAsyncCommand ?? new MvxCommand(DoMySimpleAsyncCommand);
                return _simpleAsyncCommand;

                // return _simpleAsyncCommand ?? (_simpleAsyncCommand = new MvxCommand(async () => DoMySimpleAsyncCommand()));
            }
        }

        // the method that is CALLING the thing we are waiting on needs o be async
        private async void DoMySimpleAsyncCommand()
        {
            // original code
            //string result = await LongRunningMethodAsync("World");
            //Label3.Content = result;


            // AWAIT ERROR HERE:
            // Cannot await 'System.Threading.Tasks.Task<string>'	
            // VS red squiggle on await says "Type System.Threading.Tasks.Task<string> not awaitable"

            string result = await _asyncTesterPlugin.LongRunningMethodAsync(
                "this is a call and message to LongRunningMethodAsync inside the Mvx plugin from FirstViewModel!!");

            // set property on theis ViewModel with result of Async call
            SimpleAsyncText = result;
        }
    }
}
