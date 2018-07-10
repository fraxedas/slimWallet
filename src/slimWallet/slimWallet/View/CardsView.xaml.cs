using slimWallet.Base;
using Xamarin.Forms;
using System;

namespace slimWallet
{
    public partial class CardsView : BaseView
    {
        public CardsView()
        {
            InitializeComponent();

            BindingContext = new CardsViewModel(Navigation);
        }

        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if(BindingContext is CardsViewModel viewModel) viewModel.SelectCommand.Execute(e.Item);
        }
    }
}
