using slimWallet.ViewModel;
using Xamarin.Forms;

namespace slimWallet.View
{
    public partial class AddView : ContentPage
    {
        public AddView()
        {
            InitializeComponent();
            BindingContext = new AddViewModel(Navigation);
        }
    }
}
