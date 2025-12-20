using MaterialDesignThemes.Wpf;
using System;
using System.Windows;

namespace Medical.Helper
{
    public static class ThemeHelper
    {
        private static readonly PaletteHelper _paletteHelper = new PaletteHelper();
        public static void SetTheme(bool isDark)
        {
            Theme theme = _paletteHelper.GetTheme();

            if (isDark)
            {
                theme.SetBaseTheme(BaseTheme.Dark);
            }
            else
            {
                theme.SetBaseTheme(BaseTheme.Light);
            }

            _paletteHelper.SetTheme(theme);
        }

        public static bool IsDarkTheme
        {
            get
            {
                Theme theme = _paletteHelper.GetTheme();
                return theme.GetBaseTheme() == BaseTheme.Dark;
            }
        }
        public static void ToggleTheme()
        {
            SetTheme(!IsDarkTheme);
        }

        public static void SetPrimaryColor(System.Windows.Media.Color primaryColor)
        {
            Theme theme = _paletteHelper.GetTheme();
            theme.SetPrimaryColor(primaryColor);
            _paletteHelper.SetTheme(theme);
        }

        public static void SetAccentColor(System.Windows.Media.Color accentColor)
        {
            Theme theme = _paletteHelper.GetTheme();
            theme.SetSecondaryColor(accentColor);
            _paletteHelper.SetTheme(theme);
        }
    }
}