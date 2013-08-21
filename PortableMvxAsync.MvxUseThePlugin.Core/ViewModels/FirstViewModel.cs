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

        private MvxCommand _simpleAsyncCommand;
        public ICommand SimpleAsyncCommand
        {
            get
            {
                // TODO: Neither One of these Approaches makes the await issue below go away
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

            string result = await _asyncTesterPlugin.LongRunningMethodAsync(
                "this is a call and message to LongRunningMethodAsync inside the Mvx plugin from FirstViewModel!!");

            // TODO:
            // this is where I would set a View property to the return Value above
        }
    }
}
