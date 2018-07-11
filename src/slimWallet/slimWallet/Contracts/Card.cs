using GalaSoft.MvvmLight;
using SQLite;

namespace slimWallet.Contracts
{
    public class Card : ObservableObject
    {
        private string _name;
        private string _frontImage;
        private string _backImage;

        [PrimaryKey, AutoIncrement]
        public int ID { get; internal set; }

        public string Name { get => _name; set { _name = value; RaisePropertyChanged(); } }

        public string FrontImage { get => _frontImage; set { _frontImage = value; RaisePropertyChanged(); } }

        public string BackImage { get => _backImage; set { _backImage = value; RaisePropertyChanged(); } }
    }
}