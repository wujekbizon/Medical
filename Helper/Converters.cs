using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Medical.Helper
{
    /// <summary>
    /// Converts a boolean value to Visibility.
    /// true = Visible, false = Collapsed
    /// </summary>
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                // Check for inverse parameter
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

    /// <summary>
    /// Converts a boolean to Visibility with inverse logic.
    /// true = Collapsed, false = Visible
    /// Useful for showing content when a condition is false.
    /// </summary>
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

    /// <summary>
    /// Converts a collection count to Visibility.
    /// Count > 0 = Visible, Count = 0 = Collapsed
    /// Use parameter "inverse" to invert the logic.
    /// </summary>
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
}