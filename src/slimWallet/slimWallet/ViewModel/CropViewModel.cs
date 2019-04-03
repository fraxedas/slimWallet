using FFImageLoading.Transformations;
using FFImageLoading.Work;
using slimWallet.Base;
using slimWallet.Model;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace slimWallet.ViewModel
{
    public class CropViewModel : BaseViewModel
    {
        CropModel _model;
        private int rotation;
        private double xOffset;
        private double yOffset;
        private double zoom;
        private List<ITransformation> previewTransformations;

        public CropViewModel(INavigation navigation) : base(navigation)
        {
            Model = CropModel.Current;

            PreviewTransformations = new List<ITransformation>() { new RoundedTransformation(1) };

            RotateCommand = new Command((arg) =>
            {
                var rotation = Rotation + 90;

                if (rotation >= 360)
                    rotation = 0;

                Rotation = rotation;
            });

            Zoom = 1d;
        }

        public CropModel Model
        {
            get => _model;
            set
            {
                _model = value;
                RaisePropertyChanged();
            }
        }

        public ICommand RotateCommand { get; set; }

        public ICommand ManualOffsetCommand { get; set; }

        public int Rotation
        {
            get => rotation; set
            {
                rotation = value;
                RaisePropertyChanged();
            }
        }

        public double XOffset
        {
            get => xOffset; set
            {
                xOffset = value;
                RaisePropertyChanged();
            }
        }

        public double YOffset
        {
            get => yOffset; set
            {
                yOffset = value;
                RaisePropertyChanged();
            }
        }

        public double Zoom
        {
            get => zoom; set
            {
                zoom = value;
                RaisePropertyChanged();
            }
        }

        public List<ITransformation> PreviewTransformations
        {
            get => previewTransformations; set
            {
                previewTransformations = value;                
                RaisePropertyChanged();
            }
        }
    }
}
