using slimWallet.Base;
using Xamarin.Forms;

namespace slimWallet
{
    public partial class CardsView : BaseView
    {
        public CardsView()
        {
            InitializeComponent();

            BindingContext = new CardsViewModel(Navigation);
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(BindingContext is CardsViewModel viewModel) viewModel.SelectCommand.Execute(e.Item);
        }
    }
}
