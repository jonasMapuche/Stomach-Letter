using Android.Content;
using Android.Graphics;
using Android.Hardware.Camera2;
using Android.Hardware.Camera2.Params;
using Android.Media;
using Android.OS;
using Android.Views;
using Java.Lang;
using Letter.Enums;
using Letter.Interfaces;
using Letter.Platforms.Android.Sessions;
using Letter.Platforms.Android.States;
using Exception = System.Exception;
using RecordState = Letter.Platforms.Android.States.RecordState;

namespace Letter.Platforms.Android.Services
{
    public class CameraService : Java.Lang.Object, TextureView.ISurfaceTextureListener, ICameraService
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

        public event EventHandler<string>? OnError;
        #endregion

        #region VARIABLE
        private Context _context;
        private TaskCompletionSource<byte[]>? _photo;
        private readonly TextureView _textureView;

        private CameraDevice _cameraDevice;
        private MediaRecorder _mediaRecorder;
        private string[] _list_camera;
        private string _camera_id;
        private Flash _flash;

        private const bool EMULATOR = true;

        public CameraCaptureSession CameraSession;

        private string _output;
        private global::Android.Util.Size? _size;
        #endregion

        #region CONSTRUCTOR
        public CameraService(Context context, TextureView textureView)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation constructor \"Camera\" service failed!");
                else this.error_message = string.Empty;

                this._context = context;
                this._textureView = textureView;
                this._flash = Flash.Off;
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
        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on surface texture available \"Camera\" service failed!");

                StartPreview(width, height);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on surface texture destroyed \"Camera\" service failed!");

                StopPreview();
                return true;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height) 
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on surface texture size changed \"Camera\" service failed!");
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation on surface texture updated \"Camera\" service failed!");
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        #endregion

        #region FUNCTION
        public Task<byte[]> CaptureCamera()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture camera \"Camera\" service failed!");

                this._photo = new TaskCompletionSource<byte[]>();
                StopPreview();
                ListenCamera();
                return this._photo.Task;
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void ListenCamera()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation listen camera \"Camera\" service failed!");

                CameraManager? manager = (CameraManager)this._context.GetSystemService(Context.CameraService);
                if (manager == null) return;
                if ((this._flash != Flash.Auto) && (!EMULATOR))
                    manager.SetTorchMode(this._camera_id, this._flash == Flash.Off ? false : true);
                HandlerThread thread = new HandlerThread("CameraBackground");
                thread.Start();
                Handler handler = new Handler(thread.Looper);
                manager.OpenCamera(this._camera_id, new CaptureState(this), handler);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void CaptureSession(CameraDevice cameraDevice)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation capture session \"Camera\" service failed!");

                //ImageReader imageReader = ImageReader.NewInstance(1920, 1080, ImageFormatType.Jpeg, 1);
                if (this._size == null) return;
                ImageReader imageReader = ImageReader.NewInstance(this._size.Width, this._size.Height, ImageFormatType.Jpeg, 1);
                imageReader.SetOnImageAvailableListener(new ImageState(this._photo), null);
                Surface surface_image = imageReader.Surface;
                if (surface_image == null) return;
                SurfaceTexture texture = this._textureView.SurfaceTexture;
                texture?.SetDefaultBufferSize(this._size.Width, this._size.Height);
                Surface surface_texture = new Surface(texture);
                CaptureRequest.Builder builder = cameraDevice.CreateCaptureRequest(CameraTemplate.StillCapture);
                builder.AddTarget(surface_image);
                if (CaptureRequest.JpegOrientation == null) return;
                builder.Set(CaptureRequest.JpegOrientation, 90);
                if (this._flash == Flash.Auto) 
                {
                    if (CaptureRequest.ControlAeMode == null) return;
                    builder.Set(CaptureRequest.ControlAeMode, (int)ControlAEMode.OnAutoFlash);
                }
                if (this._flash != Flash.Auto)
                {
                    if (CaptureRequest.FlashMode == null) return;
                    if (CaptureRequest.ControlAeMode == null) return;
                    builder.Set(CaptureRequest.FlashMode, this._flash == Flash.Off ? (int)FlashMode.Off : (int)FlashMode.Single);
                    builder.Set(CaptureRequest.ControlAeMode, this._flash == Flash.Off ? (int)ControlAEMode.Off : (int)ControlAEMode.On);
                }
                List<Surface> surfaces = new System.Collections.Generic.List<Surface> { surface_texture, surface_image };
                cameraDevice.CreateCaptureSession(surfaces, new CaptureSession(cameraDevice, builder), null);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public int ListCamera()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation list camera \"Camera\" service failed!");

                int quantity = 0; 
                CameraManager? manager = (CameraManager)this._context.GetSystemService(Context.CameraService);
                if (manager == null) return quantity;
                this._list_camera = manager.GetCameraIdList();
                if (this._list_camera.Count() == 0) return quantity;
                this._camera_id = manager.GetCameraIdList()[0];
                return this._list_camera.Count();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }


        public void StartPreview(int width, int height)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start preview \"Camera\" service failed!");
                
                int quantity = 0;
                quantity = ListCamera();
                if (quantity == 0) return;
                ListenPreview();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void ListenPreview()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation listen preview \"Camera\" service failed!");

                CameraManager? manager = (CameraManager)this._context.GetSystemService(Context.CameraService);
                if (manager == null) return;
                if ((this._flash != Flash.Auto) && (!EMULATOR))
                    manager.SetTorchMode(this._camera_id, this._flash == Flash.Off ? false : true);
                CameraCharacteristics characteristics = manager.GetCameraCharacteristics(this._camera_id);
                StreamConfigurationMap? map = (StreamConfigurationMap)characteristics.Get(CameraCharacteristics.ScalerStreamConfigurationMap);
                global::Android.Util.Size[]? sizes = map?.GetOutputSizes(Class.FromType(typeof(SurfaceTexture)));
                if (sizes != null && sizes.Length > 0) 
                    this._size = sizes[0];
                HandlerThread thread = new HandlerThread("PreviewBackground");
                thread.Start();
                Handler handler = new Handler(thread.Looper);
                manager.OpenCamera(this._camera_id, new PreviewState(this), handler);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void PreviewSession(CameraDevice cameraDevice)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation preview session \"Camera\" service failed!");

                SurfaceTexture? texture = this._textureView.SurfaceTexture;
                if (this._size == null) return;
                texture?.SetDefaultBufferSize(this._size.Width, this._size.Height);
                Surface surface = new Surface(texture);
                CaptureRequest.Builder builder = cameraDevice.CreateCaptureRequest(CameraTemplate.Preview);
                builder.AddTarget(surface);
                this._cameraDevice = cameraDevice;
                cameraDevice.CreateCaptureSession(new[] { surface }, new PreviewSession(this, cameraDevice, builder), null);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void StartRecord(string output)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation start record \"Camera\" service failed!");

                this._output = output;
                StopPreview();
                ListenRecord();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void ListenRecord()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation listen record \"Camera\" service failed!");

                CameraManager manager = (CameraManager)this._context.GetSystemService(Context.CameraService);
                if (manager == null) return;
                if ((this._flash != Flash.Auto) && (!EMULATOR))
                    manager.SetTorchMode(this._camera_id, this._flash == Flash.Off ? false : true);
                HandlerThread thread = new HandlerThread("RecordBackground");
                thread.Start();
                Handler handler = new Handler(thread.Looper);
                manager.OpenCamera(this._camera_id, new RecordState(this), handler);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void RecordSession(CameraDevice cameraDevice)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation record session \"Camera\" service failed!");

                MediaRecorder mediaRecorder = SetupRecord(this._output);
                Surface surface = mediaRecorder.Surface;
                if (surface == null) return;
                CaptureRequest.Builder builder = cameraDevice.CreateCaptureRequest(CameraTemplate.Record);
                builder.AddTarget(surface);
                this._cameraDevice = cameraDevice;
                this._mediaRecorder = mediaRecorder;
                List<Surface> surfaces = new System.Collections.Generic.List<Surface> { surface };
                cameraDevice.CreateCaptureSession(surfaces, new RecordSession(cameraDevice, builder, mediaRecorder), null);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void StopPreview()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop preview \"Camera\" service failed!");

                if (this.CameraSession != null)
                {
                    this.CameraSession?.StopRepeating();
                    this.CameraSession?.AbortCaptures();
                    this.CameraSession?.Close();
                    this.CameraSession?.Dispose();
                    this.CameraSession = null;
                }
                if (this._cameraDevice != null)
                {
                    this._cameraDevice?.Close();
                    this._cameraDevice?.Dispose();
                    this._cameraDevice = null;
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void StopRecord()
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation stop record \"Camera\" service failed!");

                this._mediaRecorder?.Stop();
                this._mediaRecorder?.Release();
                StopPreview();
                ListenPreview();
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }
        
        public void RotateCamera(Rotate rotate)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation rotate camera \"Camera\" service failed!");

                int quantity = 0;
                quantity = ListCamera();
                if (quantity == 1) return;
                if (rotate == Rotate.Front) 
                {
                    if (quantity > 1)
                    {
                        StopPreview();
                        this._camera_id = this._list_camera[1];
                        ListenPreview();
                        return;
                    }
                    if ((quantity > 0) && (this._camera_id != this._list_camera[0]))
                    {
                        StopPreview();
                        this._camera_id = this._list_camera[0];
                        ListenPreview();
                        return;
                    }
                }
                if (rotate == Rotate.Rear)
                {
                    if ((quantity > 0) && (this._camera_id != this._list_camera[0]))
                    {
                        StopPreview();
                        this._camera_id = this._list_camera[0];
                        ListenPreview();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        public void FlashCamera(Flash flash)
        {
            try
            {
                int quantity = 0;
                quantity = ListCamera();
                if (quantity > 0)
                {
                    if (this._camera_id != this._list_camera[0]) return;
                    if (flash == this._flash) return;
                    StopPreview();
                    this._flash = flash;
                    ListenPreview();
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private MediaRecorder SetupRecord(string output)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation setup record \"Camera\" service failed!");

                MediaRecorder mediaRecorder = new MediaRecorder();
                mediaRecorder.SetAudioSource(AudioSource.Mic);
                mediaRecorder.SetVideoSource(VideoSource.Surface);
                mediaRecorder.SetOutputFormat(OutputFormat.Mpeg4);
                mediaRecorder.SetOutputFile(output);
                mediaRecorder.SetVideoEncoder(VideoEncoder.H264);
                mediaRecorder.SetAudioEncoder(AudioEncoder.Aac);
                mediaRecorder.SetVideoSize(640, 480);
                mediaRecorder.SetVideoFrameRate(30);
                DisplayRotation rotation = DeviceDisplay.Current.MainDisplayInfo.Rotation;
                if (rotation != DisplayRotation.Rotation90) mediaRecorder.SetOrientationHint(90);
                mediaRecorder.Prepare();
                return mediaRecorder;
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
