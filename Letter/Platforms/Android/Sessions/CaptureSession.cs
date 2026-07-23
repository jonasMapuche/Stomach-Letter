using Android.Hardware.Camera2;

namespace Letter.Platforms.Android.Sessions
{
    public class CaptureSession : CameraCaptureSession.StateCallback
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
        private readonly CameraDevice _cameraDevice;
        private readonly CaptureRequest.Builder _builder;
        #endregion

        #region CONSTRUCTOR
        public CaptureSession(CameraDevice cameraDevice, CaptureRequest.Builder builder)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Capture\" session failed!");
                else this.error_message = string.Empty;

                this._cameraDevice = cameraDevice;
                this._builder = builder;
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
        public override void OnConfigured(CameraCaptureSession session)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on configured \"Capture\" state failed!");

                session.StopRepeating();
                session.Capture(this._builder.Build(), null, null);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public override void OnConfigureFailed(CameraCaptureSession session)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on configure failed \"Capture\" state failed!");

                this._cameraDevice.Close();
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
