using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace slimWallet.Contracts
{
    public class Card : ObservableObject
    {
        private string _name;
        private ImageSource _frontImage;
        private ImageSource _backImage;

        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }

        public ImageSource FrontImage { get => _frontImage; set { _frontImage = value; RaisePropertyChanged(); } }

        public ImageSource BackImage { get => _backImage; set { _backImage = value; RaisePropertyChanged(); } }
    }
}