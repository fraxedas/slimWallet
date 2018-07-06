using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace slimWallet
{
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        protected INavigation Navigation { get; }
    }
}