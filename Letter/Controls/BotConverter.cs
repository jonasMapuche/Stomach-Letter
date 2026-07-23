using CommunityToolkit.Maui.Views;
using Letter.Models;

namespace Letter.Controls
{
    public class BotConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (values[0] != null && values[1] != null && values.Length == 2)
                {
                    string report = values[0].ToString();
                    CancellationToken token = (CancellationToken)values[1];

                    return new Agent { Message = report, Token = token };
                }
                if (values[0] != null && values.Length == 2)
                {
                    string report = values[0].ToString();
                    CancellationToken token = CancellationToken.None;

                    return new Agent { Message = report, Token = token};
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
