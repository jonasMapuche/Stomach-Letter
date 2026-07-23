using Android.Hardware.Camera2;
using Android.Media;

namespace Letter.Platforms.Android.Sessions
{
    public class RecordSession : CameraCaptureSession.StateCallback
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
        private readonly MediaRecorder _mediaRecorder;
        #endregion

        #region CONSTRUCTOR
        public RecordSession(CameraDevice cameraDevice, CaptureRequest.Builder builder, MediaRecorder mediaRecorder)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Record\" session failed!");
                else this.error_message = string.Empty;

                this._cameraDevice = cameraDevice;
                this._builder = builder;
                this._mediaRecorder = mediaRecorder;
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
                if (this._error_off) throw new InvalidOperationException("Operation on configured \"Record\" session failed!");

                session.SetRepeatingRequest(this._builder.Build(), null, null);
                this._mediaRecorder.Start();
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
                if (this._error_off) throw new InvalidOperationException("Operation on configured failed \"Record\" session failed!");

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
