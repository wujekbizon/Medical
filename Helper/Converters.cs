using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Medical.Helper
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
              
                bool inverse = parameter?.ToString()?.ToLower() == "inverse";

                if (inverse)
                {
                    return boolValue ? Visibility.Collapsed : Visibility.Visible;
                }

                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                bool inverse = parameter?.ToString()?.ToLower() == "inverse";
                bool result = visibility == Visibility.Visible;

                return inverse ? !result : result;
            }

            return false;
        }
    }

    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                return visibility != Visibility.Visible;
            }

            return true;
        }
    }
    public class CountToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = 0;

            if (value is int intValue)
            {
                count = intValue;
            }
            else if (value is System.Collections.ICollection collection)
            {
                count = collection.Count;
            }

            bool inverse = parameter?.ToString()?.ToLower() == "inverse";
            bool hasItems = count > 0;

            if (inverse)
            {
                return hasItems ? Visibility.Collapsed : Visibility.Visible;
            }

            return hasItems ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class IntToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is Enum)
                return (int)value;

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (targetType.IsEnum && value is int intValue)
                return Enum.ToObject(targetType, intValue);

            return value;
        }
    }

    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                if (parameter is string paramString && paramString.Contains("|"))
                {
                    var values = paramString.Split('|');
                    return boolValue ? values[0] : values[1];
                }

                return boolValue ? "TAK" : "NIE";
            }

            return "NIE";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                if (parameter is string paramString && paramString.Contains("|"))
                {
                    var values = paramString.Split('|');
                    return stringValue == values[0];
                }

                return stringValue == "TAK";
            }

            return false;
        }
    }
}