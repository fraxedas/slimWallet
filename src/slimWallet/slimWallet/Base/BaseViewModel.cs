using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace slimWallet.Base
{
    public class BaseViewModel : ViewModelBase
    {
        public BaseViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }

        protected INavigation Navigation { get; }

        public virtual async Task OnAppearing()
        {
            await Task.Run(() => { });
        }

        public virtual async Task OnDisappearing()
        {
            await Task.Run(() => { });
        }
    }
}