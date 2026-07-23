using CommunityToolkit.Maui.Views;

namespace Letter.Controls
{
    public class CameraPreview : View
    {
        public static readonly BindableProperty IsCaptureProperty =
            BindableProperty.Create(nameof(IsCapture), typeof(bool), typeof(CameraView), false);

        public static readonly BindableProperty IsStopProperty =
            BindableProperty.Create(nameof(IsStop), typeof(bool), typeof(CameraView), false);

        public bool IsCapture
        {
            get => (bool)GetValue(IsCaptureProperty);
            set => SetValue(IsCaptureProperty, value);
        }

        public bool IsStop
        {
            get => (bool)GetValue(IsStopProperty);
            set => SetValue(IsStopProperty, value);
        }
    }
}
