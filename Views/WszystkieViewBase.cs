using System.Windows;
using System.Windows.Controls;

namespace Medical.Views
{
    /// <summary>
    /// Base class for all "List All" views (displaying collections of entities)
    /// </summary>
    public class WszystkieViewBase : UserControl
    {
        static WszystkieViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(WszystkieViewBase),
                new FrameworkPropertyMetadata(typeof(WszystkieViewBase)));
        }
    }
}
