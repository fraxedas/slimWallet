using slimWallet.Base;
using slimWallet.ViewModel;
using System.IO;
using Xamarin.Forms;

namespace slimWallet.View
{
    public partial class CropView: BaseView
     {

        public CropView()
        {
            InitializeComponent();

            BindingContext = new CropViewModel(Navigation);
            
            saveButton.Command = new Command(async (arg) =>
            {
                try
                {
                    var result = await cropView.GetImageAsJpegAsync();
                    byte[] bytes = null;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        result.CopyTo(ms);
                        bytes = ms.ToArray();
                    }

                    var imageSource = ImageSource.FromStream(() =>
                    {
                        return new MemoryStream(bytes);
                    });

                    ((CropViewModel)BindingContext).Model.SavedImage = imageSource;
                }
                catch (System.Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Ok");
                }
            });
        }
    }
}