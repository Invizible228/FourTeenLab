using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace MVVMp.Converters
{
    public class DiscountToStrikeLineConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parametr, CultureInfo culture)
        {
            var hasDiscount = (bool)value;
            if (hasDiscount)
            {
                return TextDecorations.Strikethrough;
            }
            else { return new TextDecoration(); }
        }
        public object ConvertBack(object value, Type targetType, object parametr, CultureInfo culture)
        {
            var decoration = value as TextDecoration;
            if (decoration != null)
            {
                return decoration.Location == TextDecorationLocation.Strikethrough;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
