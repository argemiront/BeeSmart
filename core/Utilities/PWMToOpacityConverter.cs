using System;
using System.Windows.Data;

namespace core.Utilities
{
    [ValueConversion(typeof(Double), typeof(Double))]
    class PWMToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var estado = (double)value;

            return estado / 1023;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var estado = (double)value;

            return estado * 1023;
        }
    }
}

