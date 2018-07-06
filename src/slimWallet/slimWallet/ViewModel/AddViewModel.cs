using System;
using System.Threading.Tasks;
using Plugin.Media;
using slimWallet.Base;
using Xamarin.Forms;

namespace slimWallet.ViewModel
{
    public class AddViewModel : BaseViewModel
    {
        private ImageSource _image;

        public AddViewModel(INavigation navigation) : base(navigation)
        {

        }

        public ImageSource Image { get => _image; set { _image = value; RaisePropertyChanged(); } }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();

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

            Image = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}