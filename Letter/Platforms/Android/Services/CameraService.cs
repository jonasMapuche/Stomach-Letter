using Android.Content;
using Android.Graphics;
using Android.Hardware.Camera2;
using Android.Hardware.Camera2.Params;
using Android.Media;
using Android.OS;
using Android.Views;
using Java.Lang;
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
                string camera_id = manager.GetCameraIdList()[0];

                HandlerThread thread = new HandlerThread("CameraBackground");
                thread.Start();
                Handler handler = new Handler(thread.Looper);

                manager.OpenCamera(camera_id, new CaptureState(this), handler);
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
                ImageReader imageReader = ImageReader.NewInstance(this._size.Width, this._size.Height, ImageFormatType.Jpeg, 1);
                imageReader.SetOnImageAvailableListener(new ImageState(this._photo), null);
                Surface? surface_image = imageReader.Surface;

                SurfaceTexture? texture = this._textureView.SurfaceTexture;
                texture.SetDefaultBufferSize(this._size.Width, this._size.Height);
                Surface surface_texture = new Surface(texture);

                CaptureRequest.Builder builder = cameraDevice.CreateCaptureRequest(CameraTemplate.StillCapture);
                builder.AddTarget(surface_image);
                builder.Set(CaptureRequest.JpegOrientation, 90);

                List<Surface> surfaces = new System.Collections.Generic.List<Surface> { surface_texture, surface_image };
                cameraDevice.CreateCaptureSession(surfaces, new CaptureSession(cameraDevice, builder), null);
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

                ListenPreview(width, height);
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                throw new InvalidOperationException(this.error_message);
            }
        }

        private void ListenPreview(int width, int height)
        {
            try
            {
                if (this._error_off) throw new InvalidOperationException("Operation listen preview \"Camera\" service failed!");

                CameraManager manager = (CameraManager)this._context.GetSystemService(Context.CameraService);
                string camera_id = manager.GetCameraIdList()[0];
                CameraCharacteristics characteristics = manager.GetCameraCharacteristics(camera_id);
                StreamConfigurationMap? map = (StreamConfigurationMap)characteristics.Get(CameraCharacteristics.ScalerStreamConfigurationMap);

                global::Android.Util.Size[]? sizes = map.GetOutputSizes(Class.FromType(typeof(SurfaceTexture)));
                if (sizes != null && sizes.Length > 0)
                {
                    this._size = sizes[0];
                }
                HandlerThread thread = new HandlerThread("PreviewBackground");
                thread.Start();
                Handler handler = new Handler(thread.Looper);

                manager.OpenCamera(camera_id, new PreviewState(this), handler);
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
                texture.SetDefaultBufferSize(this._size.Width, this._size.Height);
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
                string camera_id = manager.GetCameraIdList()[0];

                HandlerThread thread = new HandlerThread("RecordBackground");
                thread.Start();
                Handler handler = new Handler(thread.Looper);

                manager.OpenCamera(camera_id, new RecordState(this), handler);
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
                Surface? surface = mediaRecorder.Surface;

                CaptureRequest.Builder builder = cameraDevice.CreateCaptureRequest(CameraTemplate.Record);
                builder.AddTarget(surface);

                this._mediaRecorder = mediaRecorder;
                this._cameraDevice = cameraDevice;

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
            throw new NotImplementedException();
        }

        public string StopRecord()
        {
            throw new NotImplementedException();
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
