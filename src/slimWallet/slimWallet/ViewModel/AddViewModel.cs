using System;
using System.Linq;
using System.Threading.Tasks;
using Plugin.Media;
using slimWallet.Base;
using Xamarin.Forms;
using System.Windows.Input;
using Plugin.Media.Abstractions;
using slimWallet.Model;
using slimWallet.Data;

namespace slimWallet.ViewModel
{
    public class AddViewModel : BaseViewModel
    {
        private CardModel _model { get; set; }

        public AddViewModel(INavigation navigation) : base(navigation)
        {
            Model = CardModel.Current;
        }

        public ICommand FrontCommand => new Command(async () => await TakePhoto());

        public ICommand PredictCommand => new Command(async () => await Model.Predict());

        public ICommand VerifyCommand => new Command(async () => await Model.Verify());

        public ICommand RemoveCommand => new Command(async () =>
        {
            await Model.RemoveAsync(Model.Selected);
            await Navigation.PopAsync();
        });

        public ICommand SaveCommand => new Command(async () =>
        {
            await Model.SaveAsync(Model.Selected);
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

        public async Task TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            var action = await Navigation.NavigationStack.Last()
                .DisplayActionSheet("Select source", "Cancel", null, "Take photo", "Select from gallery");



            MediaFile file = null;
            if (action == "Take photo")
            {
                if (!CrossMedia.Current.IsCameraAvailable)
                {
                    throw new Exception(":( No camera available.");
                }

                file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "slimWallet",
                    Name = "test.jpg",
                    AllowCropping = true,
                    PhotoSize = PhotoSize.Medium
                });
            }
            else if (action == "Select from gallery")
            {
                if (!CrossMedia.Current.IsTakePhotoSupported)
                {
                    throw new Exception(":( No camera available.");
                }
                file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });
            }

            if (file == null)
                return;

            await _model.SaveFileAsync(Model.Selected, file.GetStreamWithImageRotatedForExternalStorage());
        }

    }
}