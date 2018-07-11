using System;
using System.Globalization;
using slimWallet.Model;
using Xamarin.Forms;

namespace slimWallet.Converter
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var fileName = value?.ToString();
            if (string.IsNullOrEmpty(fileName)) return null;

            return ImageSource.FromStream(() => CardModel.Current.ReadAsync(fileName).Result);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
