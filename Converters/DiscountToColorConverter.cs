using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MVVMp.Converters
{
    public class DiscountToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parametr, CultureInfo culture)
        {
            var hasDiscount = (bool)value;
            if (hasDiscount)
            {
                return Visibility.Visible;
            }
            else { return Visibility.Collapsed; }
        }
        public object ConvertBack(object value, Type targetType, object parametr, CultureInfo culture)
        {
            return (Visibility)value == Visibility.Visible;
        }
    }
}
