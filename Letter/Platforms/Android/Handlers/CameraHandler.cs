using Android.Views;
using Letter.Controls;
using Letter.Platforms.Android.Services;
using Microsoft.Maui.Handlers;

namespace Letter.Platforms.Android.Handlers
{
    public class CameraHandler : ViewHandler<CameraPreview, TextureView>
    {
        #region ERROR
        private bool _error_on = true;
        private bool _error_off = false;
        private string? _error_message;

        public string? error_message
        {
            get => _error_message;
            set
            {
                _error_message = value;
            }
        }

        public event EventHandler<string>? OnError;
        #endregion

        #region VARIABLE
        private CameraService _cameraService;
        #endregion

        #region CONSTRUCTOR
        public CameraHandler() : base(Mapper) { }
        #endregion

        #region COMMAND
        #endregion

        #region EVENT
        public static IPropertyMapper<CameraPreview, CameraHandler> Mapper = new PropertyMapper<CameraPreview, CameraHandler>(ViewHandler.ViewMapper)
        {
            [nameof(CameraPreview.IsCapture)] = MapIsCapture,
            [nameof(CameraPreview.IsStop)] = MapIsStop
        };

        protected override TextureView CreatePlatformView()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation create plataform view \"Camera\" handler failed!");

                TextureView textureView = new TextureView(Context);
                this._cameraService = new CameraService(Context, textureView);
                textureView.SurfaceTextureListener = this._cameraService;
                return textureView;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region FUNCTION
        private static void MapIsCapture(CameraHandler handler, CameraPreview view)
        {
            try
            {
                //if (this._error_off) throw new InvalidOperationException("Operation map is capture \"Camera\" handler failed!");

                if (view.IsCapture)
                {
                    handler.CapturePhoto();
                    view.IsCapture = false;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        private static void MapIsStop(CameraHandler handler, CameraPreview view)
        {
            try
            {
                //if (this._error_off) throw new InvalidOperationException("Operation map is stop \"Camera\" handler failed!");

                if (view.IsStop)
                {
                    handler.StopControl();
                    view.IsStop = false;
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        private void CapturePhoto()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture photo \"Camera\" handler failed!");

                this._cameraService.CaptureCamera();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void StopControl()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop control \"Camera\" handler failed!");

                this._cameraService.StopPreview();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion
    }
}
