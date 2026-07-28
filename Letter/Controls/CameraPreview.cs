using Letter.Enums;
using Letter.Platforms.Android.Services;

namespace Letter.Controls
{
    public class CameraPreview : View
    {
        public static readonly BindableProperty IsStopProperty =
            BindableProperty.Create(nameof(IsStop), typeof(bool), typeof(CameraPreview), false);

        public static readonly BindableProperty IsCaptureProperty =
            BindableProperty.Create(nameof(IsCapture), typeof(bool), typeof(CameraPreview), false);

        public static readonly BindableProperty IsRecordProperty =
            BindableProperty.Create(nameof(IsRecord), typeof(bool), typeof(CameraPreview), false);

        public static readonly BindableProperty IsStopRecordProperty =
            BindableProperty.Create(nameof(IsStopRecord), typeof(bool), typeof(CameraPreview), false);

        public static readonly BindableProperty SetRotateProperty =
            BindableProperty.Create(nameof(SetRotate), typeof(Rotate), typeof(CameraPreview), Rotate.Unknown);

        public static readonly BindableProperty SetFlashProperty =
            BindableProperty.Create(nameof(SetFlash), typeof(Flash), typeof(CameraPreview), Flash.Unknown);

        public static readonly BindableProperty ImageBytesProperty =
            BindableProperty.Create(nameof(ImageBytes), typeof(byte[]), typeof(CameraPreview), null, propertyChanged: OnImageBytesChanged);

        public bool IsStop
        {
            get => (bool)GetValue(IsStopProperty);
            set => SetValue(IsStopProperty, value);
        }

        public bool IsCapture
        {
            get => (bool)GetValue(IsCaptureProperty);
            set => SetValue(IsCaptureProperty, value);
        }

        public bool IsRecord
        {
            get => (bool)GetValue(IsRecordProperty);
            set => SetValue(IsRecordProperty, value);
        }

        public bool IsStopRecord
        {
            get => (bool)GetValue(IsStopRecordProperty);
            set => SetValue(IsStopRecordProperty, value);
        }

        public Rotate SetRotate
        {
            get => (Rotate)GetValue(SetRotateProperty);
            set => SetValue(SetRotateProperty, value);
        }

        public Flash SetFlash
        {
            get => (Flash)GetValue(SetFlashProperty);
            set => SetValue(SetFlashProperty, value);
        }

        public byte[] ImageBytes
        {
            get => (byte[])GetValue(ImageBytesProperty);
            set => SetValue(ImageBytesProperty, value);
        }

        public event EventHandler? OnImageBytes;

        public void InvokeImageBytes()
        {
            OnImageBytes?.Invoke(this, EventArgs.Empty);
        }

        public ImageSource? DisplayImage { get; private set; }

        private static void OnImageBytesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CameraPreview)bindable;
            if (newValue is byte[] bytes && bytes.Length > 0)
            {
                control.DisplayImage = ImageSource.FromStream(() => new MemoryStream(bytes));
            }
        }

        /*
        private static void OnImageDataChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CameraPreview control && newValue is byte[] data)
            {
                _ = control.ProcessDataAsync(data);
            }
        }

        private async Task ProcessDataAsync(byte[] data)
        {
            //await CaptureCamera();

            MainThread.BeginInvokeOnMainThread(() =>
            {
                this.Handler?.UpdateValue(nameof(ImageBytes));
            });
        }
        */
    }
}
