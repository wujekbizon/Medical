using System.Windows;
using System.Windows.Controls;

namespace Medical.Views
{
    /// <summary>
    /// Base class for all "Add/Edit One" views (single entity forms)
    /// </summary>
    public class JedenViewBase : UserControl
    {
        static JedenViewBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(JedenViewBase),
                new FrameworkPropertyMetadata(typeof(JedenViewBase)));
        }
    }
}
