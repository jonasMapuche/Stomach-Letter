using Android.Hardware.Camera2;
using Letter.Platforms.Android.Services;

namespace Letter.Platforms.Android.Sessions
{
    public class PreviewSession : CameraCaptureSession.StateCallback
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
        private readonly CameraService _cameraService;
        private readonly CameraDevice _cameraDevice;
        private readonly CaptureRequest.Builder _builder;
        #endregion

        #region CONSTRUCTOR
        public PreviewSession(CameraService cameraService, CameraDevice cameraDevice, CaptureRequest.Builder builder)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Preview\" session failed!");
                else this.error_message = string.Empty;

                this._cameraDevice = cameraDevice;
                this._builder = builder;
                this._cameraService = cameraService;
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
                if (this._error_off) throw new InvalidOperationException("Operation on configured \"Preview\" session failed!");

                this._cameraService.CameraSession = session;
                this._cameraService.CameraSession.SetRepeatingRequest(this._builder.Build(), null, null);
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
                if (this._error_off) throw new InvalidOperationException("Operation on configured failed \"Preview\" session failed!");

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
