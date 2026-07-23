using Android.Media;
using Java.Nio;

namespace Letter.Platforms.Android.States
{
    public class ImageState : Java.Lang.Object, ImageReader.IOnImageAvailableListener
    {
        #region ERROR
        private bool _error_on = true;
        private bool _error_off = false;
        private string? _error_message;

        public string? error_message
        {
            get => this._error_message;
            set
            {
                this._error_message = value;
            }
        }
        #endregion

        #region VARIABLE
        private readonly TaskCompletionSource<byte[]> _photo;
        #endregion

        #region CONSTRUCTOR
        public ImageState(TaskCompletionSource<byte[]> photo)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Image\" state failed!");
                else this.error_message = string.Empty;

                this._photo = photo;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        public void OnImageAvailable(ImageReader? reader)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on image available \"Image\" state failed!");

                using global::Android.Media.Image? image = reader.AcquireNextImage();
                ByteBuffer? buffer = image.GetPlanes()[0].Buffer;
                byte[] bytes = new byte[buffer.Remaining()];
                buffer.Get(bytes);
                this._photo.SetResult(bytes);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region FUNCTION
        #endregion
    }
}
