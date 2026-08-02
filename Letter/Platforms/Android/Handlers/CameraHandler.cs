using Android.Views;
using Letter.Controls;
using Letter.Enums;
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
        #endregion

        #region VARIABLE
        private CameraService? _cameraService;
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
            [nameof(CameraPreview.IsStop)] = MapIsStop,
            [nameof(CameraPreview.IsRecord)] = MapIsRecord,
            [nameof(CameraPreview.IsStopRecord)] = MapIsStopRecord,
            [nameof(CameraPreview.SetRotate)] = MapSetRotate,
            [nameof(CameraPreview.SetFlash)] = MapSetFlash,
            [nameof(CameraPreview.SetPath)] = MapSetPath
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
        private static async void MapIsCapture(CameraHandler handler, CameraPreview preview)
        {
            try
            {
                if (handler._error_off) throw new InvalidOperationException("Operation map is capture \"Camera\" handler failed!");

                if (preview.IsCapture)
                {
                    byte[] data = preview.ImageBytes;
                    if (data == null || data.Length == 0)
                    {
                        data = await handler.CapturePhotoAsync();
                        MainThread.BeginInvokeOnMainThread(() => {
                            preview.ImageBytes = data;
                            preview.InvokeImageBytes();
                        });
                    }
                    preview.IsCapture = false;
                }
            }
            catch (Exception ex)
            {
                handler.error_message = ex.Message;
                throw new InvalidOperationException(handler.error_message);
            }
        }

        private static void MapIsStop(CameraHandler handler, CameraPreview preview)
        {
            try
            {
               if (handler._error_off) throw new InvalidOperationException("Operation map is stop \"Camera\" handler failed!");

                if (preview.IsStop)
                {
                    handler.StopRecord();
                    preview.IsStop = false;
                }
            }
            catch (Exception ex)
            {
                handler.error_message = ex.Message;
                throw new InvalidOperationException(handler.error_message);
            }
        }

        private static void MapIsRecord(CameraHandler handler, CameraPreview preview)
        {
            try
            {
                if (handler._error_off) throw new InvalidOperationException("Operation map is record \"Camera\" handler failed!");

                if (preview.IsRecord)
                {
                    if (handler._output != string.Empty) 
                        handler.RecordCamera(handler._output);
                    preview.IsRecord = false;
                }
            }
            catch (Exception ex)
            {
                handler.error_message = ex.Message;
                throw new InvalidOperationException(handler.error_message);
            }
        }

        private static void MapIsStopRecord(CameraHandler handler, CameraPreview preview)
        {
            try
            {
                if (handler._error_off) throw new InvalidOperationException("Operation map is stop record \"Camera\" handler failed!");

                if (preview.IsStopRecord)
                {
                    handler.StopRecord();
                    preview.IsStopRecord = false;
                }
            }
            catch (Exception ex)
            {
                handler.error_message = ex.Message;
                throw new InvalidOperationException(handler.error_message);
            }
        }

        private static void MapSetFlash(CameraHandler handler, CameraPreview preview)
        {
            try
            {
                if (handler._error_off) throw new InvalidOperationException("Operation map set flash \"Camera\" handler failed!");

                if (preview.SetFlash != Flash.Unknown)
                {
                    handler.FlashCamera(preview.SetFlash);
                    preview.SetFlash = Flash.Unknown;
                }
            }
            catch (Exception ex)
            {
                handler.error_message = ex.Message;
                throw new InvalidOperationException(handler.error_message);
            }
        }

        private static void MapSetRotate(CameraHandler handler, CameraPreview preview)
        {
            try
            {
                if (handler._error_off) throw new InvalidOperationException("Operation map set rotate \"Camera\" handler failed!");

                if ((preview.SetRotate != Rotate.Unknown))
                {
                    handler.RotateCamera(preview.SetRotate);
                    preview.SetRotate = Rotate.Unknown;
                }
            }
            catch (Exception ex)
            {
                handler.error_message = ex.Message;
                throw new InvalidOperationException(handler.error_message);
            }
        }

        private string _output = string.Empty;

        private static void MapSetPath(CameraHandler handler, CameraPreview preview)
        {
            try
            {
                if (handler._error_off) throw new InvalidOperationException("Operation map set path \"Camera\" handler failed!");

                if (preview.SetPath != string.Empty)
                {
                    handler._output = preview.SetPath;
                    preview.SetPath = string.Empty;
                }
            }
            catch (Exception ex)
            {
                handler.error_message = ex.Message;
                throw new InvalidOperationException(handler.error_message);
            }
        }

        private void RotateCamera(Rotate rotate)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation rotate camera \"Camera\" handler failed!");

                this._cameraService?.RotateCamera(rotate);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void FlashCamera(Flash flash)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation flash camera \"Camera\" handler failed!");

                this._cameraService?.FlashCamera(flash);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private async Task<byte[]> CapturePhotoAsync()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture photo \"Camera\" handler failed!");

                return await this._cameraService.CaptureCamera();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void RecordCamera(string file_path)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation record camera \"Camera\" handler failed!");

                this._cameraService?.StartRecord(file_path);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void StopRecord()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop record \"Camera\" handler failed!");

                this._cameraService?.StopRecord();
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
