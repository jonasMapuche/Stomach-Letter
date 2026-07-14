using Android.Views;
using Letter.Controls;
using Microsoft.Maui.Handlers;

namespace Letter.Platforms.Android.Handlers
{
    public class CameraHandler : ViewHandler<CameraPreview, TextureView>
    {
        public CameraHandler(IPropertyMapper mapper, CommandMapper? commandMapper = null) : base(mapper, commandMapper)
        {
        }

        protected override TextureView CreatePlatformView()
        {
            throw new NotImplementedException();
        }
    }
}
