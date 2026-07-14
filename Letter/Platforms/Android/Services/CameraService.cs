using Android.Graphics;
using Android.Views;
using Letter.Interfaces;

namespace Letter.Platforms.Android.Services
{
    public class CameraService : Java.Lang.Object, TextureView.ISurfaceTextureListener, ICameraService
    {
        public void OnSurfaceTextureAvailable(SurfaceTexture surface, int width, int height)
        {
            throw new NotImplementedException();
        }

        public bool OnSurfaceTextureDestroyed(SurfaceTexture surface)
        {
            throw new NotImplementedException();
        }

        public void OnSurfaceTextureSizeChanged(SurfaceTexture surface, int width, int height)
        {
            throw new NotImplementedException();
        }

        public void OnSurfaceTextureUpdated(SurfaceTexture surface)
        {
            throw new NotImplementedException();
        }

        public void StartPreview()
        {
            throw new NotImplementedException();
        }

        public void StartRecord(string output)
        {
            throw new NotImplementedException();
        }

        public void StopPreview()
        {
            throw new NotImplementedException();
        }

        public string StopRecord()
        {
            throw new NotImplementedException();
        }
    }
}
