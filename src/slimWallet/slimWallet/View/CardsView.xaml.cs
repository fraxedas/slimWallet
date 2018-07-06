using slimWallet.Base;

namespace slimWallet
{
    public partial class CardsView : BaseView
    {
        public CardsView()
        {
            InitializeComponent();

            BindingContext = new CardsViewModel(Navigation);
        }
    }
}
