using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using slimWallet.View;
using Xamarin.Forms;

namespace slimWallet
{

    public class CardsViewModel : BaseViewModel
    {
        CardModel _model;
        List<Card> _cards;

        public CardsViewModel(INavigation navigation): base(navigation)
        {
            Model = new CardModel();
            _cards = Model.List();
            AddCommand = new Command(async () =>  await Add());
        }

        private async Task Add()
        {
            await Navigation.PushAsync(new AddView());
        }

        public ICommand AddCommand { get; }

        public List<Card> Cards
        {
            get => _cards;
            set
            {
                _cards = value;
                RaisePropertyChanged();
            }
        }

        public CardModel Model
        {
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChanged();
            }
        }
    }
}