using Android.Hardware.Camera2;
using Android.Runtime;
using Letter.Platforms.Android.Services;

namespace Letter.Platforms.Android.States
{
    public class CaptureState : CameraDevice.StateCallback
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
        #endregion

        #region CONSTRUCTOR
        public CaptureState(CameraService cameraService)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Camera\" state failed!");
                else this.error_message = string.Empty;

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
        public override void OnDisconnected(CameraDevice camera)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on disconnected \"Camera\" state failed!");

                camera.Close();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public override void OnError(CameraDevice camera, [GeneratedEnum] CameraError error)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on error \"Camera\" state failed!");
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public override void OnOpened(CameraDevice camera)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on opened \"Camera\" state failed!");

                this._cameraService.CaptureSession(camera);
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
