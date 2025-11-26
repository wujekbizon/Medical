using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace Medical.Views.Controls
{
    public partial class WelcomeMapView : UserControl
    {
        private const double DefaultLatitude = 49.6200;
        private const double DefaultLongitude = 20.6953;
        private const int DefaultZoom = 12;
        private DispatcherTimer _simulationTimer;
        private Storyboard _iconPulse;

        public WelcomeMapView()
        {
            InitializeComponent();
            Loaded += WelcomeMapView_Loaded;
        }

        private void WelcomeMapView_Loaded(object sender, RoutedEventArgs e)
        {
            InitializeMap();
            PositionMapElements();
            StartLoadingSimulation();
        }

        private void StartLoadingSimulation()
        {
            _iconPulse = (Storyboard)this.Resources["IconPulse"];
            _iconPulse.Begin(this, true);
            _simulationTimer = new DispatcherTimer();
            _simulationTimer.Interval = TimeSpan.FromSeconds(3);
            _simulationTimer.Tick += SimulationTimer_Tick;
            _simulationTimer.Start();
        }

        private void SimulationTimer_Tick(object sender, EventArgs e)
        {
            _simulationTimer.Stop();
            _iconPulse.Stop(this);
            FadeOutWelcomeContent();
        }

        private void FadeOutWelcomeContent()
        {
            var fadeOut = new Storyboard();
            var duration = new System.Windows.Duration(TimeSpan.FromSeconds(0.5));

            var contentAnim = new DoubleAnimation(1, 0, duration);
            Storyboard.SetTargetName(contentAnim, "WelcomeContent");
            Storyboard.SetTargetProperty(contentAnim, new PropertyPath(OpacityProperty));
            fadeOut.Children.Add(contentAnim);

            var rectAnim = new DoubleAnimation(1, 0, duration);
            Storyboard.SetTargetName(rectAnim, "OverlayRectangle");
            Storyboard.SetTargetProperty(rectAnim, new PropertyPath(OpacityProperty));
            fadeOut.Children.Add(rectAnim);

            fadeOut.Completed += (s, ev) =>
            {
                WelcomeContent.Visibility = Visibility.Collapsed;
                OverlayRectangle.Visibility = Visibility.Collapsed;
            };

            fadeOut.Begin(this);
        }

        private void InitializeMap()
        {

            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            MapControl.MapProvider = OpenStreetMapProvider.Instance;

            MapControl.Position = new PointLatLng(DefaultLatitude, DefaultLongitude);
            MapControl.MinZoom = 2;
            MapControl.MaxZoom = 18;
            MapControl.Zoom = DefaultZoom;

            MapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            MapControl.CanDragMap = true;
            MapControl.DragButton = MouseButton.Left;

            MapControl.Opacity = 0.4;

            AddEmergencyMarkers();

        }

        private void AddEmergencyMarkers()
        {

            var markersOverlay = new GMapMarker(
                new PointLatLng(DefaultLatitude, DefaultLongitude));

            var marker = new System.Windows.Shapes.Ellipse
            {
                Width = 16,
                Height = 16,
                Fill = new System.Windows.Media.SolidColorBrush(
                    (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#9C27B0")),
                Stroke = System.Windows.Media.Brushes.White,
                StrokeThickness = 2
            };

            markersOverlay.Shape = marker;
            MapControl.Markers.Add(markersOverlay);

        }

        public void SetMapPosition(double latitude, double longitude, int zoom = -1)
        {

            MapControl.Position = new PointLatLng(latitude, longitude);
            if (zoom > 0)
            {
                MapControl.Zoom = zoom;
            }

        }

        private void PositionMapElements()
        {
            // TODO add logic to position elements based on control size if needed 
        }
    }
}