using System;
using System.Threading.Tasks;
using Plugin.Media;
using slimWallet.Base;
using Xamarin.Forms;
using System.Windows.Input;
using slimWallet.Model;

namespace slimWallet.ViewModel
{
    public class AddViewModel : BaseViewModel
    {
        private CardModel _model { get; set; }

        public AddViewModel(INavigation navigation) : base(navigation)
        {
            Model = CardModel.Current;
        }

        public ICommand FrontCommand => new Command(async () => await TakePhoto(true));

        public ICommand BackCommand => new Command(async () => await TakePhoto(false));

        public ICommand SaveCommand => new Command(async () => {
            Model.Save(Model.Selected);
            await Navigation.PopAsync();
        });

        public CardModel Model
        {
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChanged();
            }
        }

        public async Task TakePhoto(bool front)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                throw new Exception(":( No camera available.");
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "slimWallet",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            var source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            if (front) Model.Selected.FrontImage = source;
            else Model.Selected.BackImage = source;
        }
    }
}