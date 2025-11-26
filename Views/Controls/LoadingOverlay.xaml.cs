using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Medical.Views.Controls
{
    public partial class LoadingOverlay : UserControl
    {
        public static readonly DependencyProperty StatusMessageProperty =
            DependencyProperty.Register(
                "StatusMessage",
                typeof(string),
                typeof(LoadingOverlay),
                new PropertyMetadata("Przygotowywanie danych...", OnStatusMessageChanged));

        public static readonly DependencyProperty IsLoadingProperty =
            DependencyProperty.Register(
                "IsLoading",
                typeof(bool),
                typeof(LoadingOverlay),
                new PropertyMetadata(false, OnIsLoadingChanged));

        public string StatusMessage
        {
            get { return (string)GetValue(StatusMessageProperty); }
            set { SetValue(StatusMessageProperty, value); }
        }

        public bool IsLoading
        {
            get { return (bool)GetValue(IsLoadingProperty); }
            set { SetValue(IsLoadingProperty, value); }
        }

        public LoadingOverlay()
        {
            InitializeComponent();
        }

        private static void OnStatusMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LoadingOverlay overlay)
            {
                overlay.StatusText.Text = e.NewValue?.ToString() ?? string.Empty;
            }
        }

        private static void OnIsLoadingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is LoadingOverlay overlay)
            {
                bool isLoading = (bool)e.NewValue;
                if (isLoading)
                {
                    overlay.Show();
                }
                else
                {
                    overlay.Hide();
                }
            }
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;

            // Start all animations
            StartAnimations();

            // Fade in
            var fadeIn = (Storyboard)Resources["FadeInAnimation"];
            fadeIn?.Begin(this);
        }

        public void Hide()
        {
            var fadeOut = (Storyboard)Resources["FadeOutAnimation"];
            if (fadeOut != null)
            {
                fadeOut = fadeOut.Clone();
                fadeOut.Completed += (s, e) =>
                {
                    this.Visibility = Visibility.Collapsed;
                    StopAnimations();
                };
                fadeOut.Begin(this);
            }
            else
            {
                this.Visibility = Visibility.Collapsed;
                StopAnimations();
            }
        }

        private void StartAnimations()
        {
            var spinAnimation = (Storyboard)Resources["SpinAnimation"];
            var pulseAnimation = (Storyboard)Resources["PulseAnimation"];
            var dotsAnimation = (Storyboard)Resources["DotsAnimation"];

            spinAnimation?.Begin(this, true);
            pulseAnimation?.Begin(this, true);
            dotsAnimation?.Begin(this, true);
        }

        private void StopAnimations()
        {
            var spinAnimation = (Storyboard)Resources["SpinAnimation"];
            var pulseAnimation = (Storyboard)Resources["PulseAnimation"];
            var dotsAnimation = (Storyboard)Resources["DotsAnimation"];

            spinAnimation?.Stop(this);
            pulseAnimation?.Stop(this);
            dotsAnimation?.Stop(this);
        }

        public void SetStatus(string message)
        {
            StatusMessage = message;
        }
    }
}