using Android.App;
using Android.Content.Res;
using Android.Runtime;
using Microsoft.Maui.Handlers;

namespace Letter
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp()
        {
            EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
            {
                handler.PlatformView.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.Transparent);
            });

            return MauiProgram.CreateMauiApp();
        } 
    }
}
