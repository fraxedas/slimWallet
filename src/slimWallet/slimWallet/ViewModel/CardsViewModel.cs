using System.Threading.Tasks;
using System.Windows.Input;
using slimWallet.Base;
using slimWallet.Contracts;
using slimWallet.Model;
using slimWallet.View;
using Xamarin.Forms;

namespace slimWallet
{

    public class CardsViewModel : BaseViewModel
    {
        CardModel _model;

        public CardsViewModel(INavigation navigation): base(navigation)
        {
            Model = CardModel.Current;
            AddCommand = new Command(async () => await Add());
            SelectCommand = new Command<Card>(async card => await Select(card));
        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            await Model.Init();
        }

        private async Task Select(Card card)
        {
            Model.Selected = card;
            await Navigation.PushAsync(new AddView());
        }

        private async Task Add()
        {
            Model.Selected = new Card();
            await Navigation.PushAsync(new AddView());
        }

        public ICommand AddCommand { get; }
        public ICommand SelectCommand { get; }

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