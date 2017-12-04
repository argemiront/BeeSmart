using System;
using System.Windows.Data;

namespace core.Utilities
{
    [ValueConversion(typeof(Int32), typeof(System.Windows.Visibility))]
    class VisibilityToEstadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var estado = (int)value;

            if (estado == 0)
                return System.Windows.Visibility.Hidden;
            else
                return System.Windows.Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var visibilidade = (System.Windows.Visibility)value;

            if (visibilidade == System.Windows.Visibility.Visible)
                return 1;
            else
                return 0;
        }
    }
}
