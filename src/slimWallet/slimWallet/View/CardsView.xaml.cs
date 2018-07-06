using Xamarin.Forms;

namespace slimWallet
{
    public partial class CardsView : ContentPage
    {
        public CardsView()
        {
            InitializeComponent();

            BindingContext = new CardsViewModel(Navigation);
        }
    }
}
