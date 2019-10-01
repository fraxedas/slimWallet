using GalaSoft.MvvmLight;
using SQLite;

namespace slimWallet.Contracts
{
    public class Card : ObservableObject
    {
        private string _image;
        private string _documentId;
        private bool _predictedBlurry;
        private bool _actualBlurry;
        private string _name;
        private string _thumbnail;

        [PrimaryKey] [AutoIncrement] 
        public int ID { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }

        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                RaisePropertyChanged();
            }
        }

        public string Thumbnail
        {
            get => _thumbnail;
            set
            {
                _thumbnail = value;
                RaisePropertyChanged();
            }
        }

        public string DocumentId
        {
            get => _documentId;
            set
            {
                _documentId = value;
                RaisePropertyChanged();
            }
        }

        public bool PredictedBlurry
        {
            get => _predictedBlurry;
            set
            {
                _predictedBlurry = value;
                RaisePropertyChanged();
            }
        }

        public bool ActualBlurry
        {
            get => _actualBlurry;
            set
            {
                _actualBlurry = value;
                RaisePropertyChanged();
            }
        }
    }
}