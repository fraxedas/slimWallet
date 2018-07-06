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
    }
}
