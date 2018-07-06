using Xamarin.Forms;

namespace slimWallet.Base
{
    public partial class BaseView : ContentPage
    {
        public BaseView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is BaseViewModel viewModel)
                await viewModel.OnAppearing();
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            if (BindingContext is BaseViewModel viewModel)
                await viewModel.OnDisappearing();
        }


    }
}
