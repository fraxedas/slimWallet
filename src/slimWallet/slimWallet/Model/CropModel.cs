using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace slimWallet.Model
{
    public class CropModel : ObservableObject
    {
        public static CropModel Current => _current ?? (_current = new CropModel());

        private static CropModel _current;
        private ImageSource originalImage;
        private ImageSource savedImage;

        public ImageSource OriginalImage
        {
            get => originalImage; 
            set
            {
                originalImage = value;
                RaisePropertyChanged();
            }
        }

        public ImageSource SavedImage
        {
            get => savedImage; 
            set
            {
                savedImage = value;
                RaisePropertyChanged();
            }
        }
    }
}