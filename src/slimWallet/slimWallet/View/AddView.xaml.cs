using slimWallet.Base;
using slimWallet.ViewModel;
using Xamarin.Forms;

namespace slimWallet.View
{
    public partial class AddView : BaseView
    {
        public AddView()
        {
            InitializeComponent();
            BindingContext = new AddViewModel(Navigation);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {

        }
    }
}
