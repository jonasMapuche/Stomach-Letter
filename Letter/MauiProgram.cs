using CommunityToolkit.Maui;
using Letter.Services;
using Letter.ViewModels;
using Letter.Views;
using Letter.Data;
using Microsoft.Extensions.Logging;
using Letter.Bots;
using Letter.Views.Templates;
using Letter.Interfaces;
using Letter.Controls;

using Letter.Platforms.Android.Handlers;
using Plugin.Firebase.Bundled.Shared;
using Plugin.Firebase.Auth;

using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Bundled.Platforms.Android;



#if ANDROID
using Letter.Platforms.Android.Services;
#endif


namespace Letter
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCamera()
                .RegisterFirebaseServices()
                .ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler(typeof(CameraPreview), typeof(CameraHandler));
#endif
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if ANDROID
            builder.Services.AddTransient<IAudioService, AudioService>();
            builder.Services.AddTransient<IRecordService, RecordService>();
            builder.Services.AddTransient<ITextSpeakService, TextSpeakService>();
            builder.Services.AddTransient<ISMSService, SMSService>();
            builder.Services.AddTransient<IBluetoothService, BluetoothService>();
            builder.Services.AddTransient<IWiFiService, WiFiService>();
            builder.Services.AddTransient<IVPNClientService, VPNClientService>();
            builder.Services.AddTransient<IPhoneService, PhoneService>();
            builder.Services.AddSingleton<ICameraService, CameraService>();
#endif

            builder.Services.AddSingleton<AlgarismoContext>();
            builder.Services.AddSingleton<AssistenteContext>();
            builder.Services.AddSingleton<CircunstanciaContext>();
            builder.Services.AddSingleton<ElocucaoContext>();
            builder.Services.AddSingleton<EstoutroContext>();
            builder.Services.AddSingleton<JuncaoContext>();
            builder.Services.AddSingleton<LigacaoContext>();
            builder.Services.AddSingleton<MaterialContext>();
            builder.Services.AddSingleton<PreceitoContext>();
            builder.Services.AddSingleton<SentencaContext>();
            builder.Services.AddSingleton<MongoDBService>();

            builder.Services.AddSingleton<HttpService>();
            builder.Services.AddSingleton<ModelService>();

            builder.Services.AddSingleton<SQLiteContext>();
            builder.Services.AddSingleton<SQLiteService>();

            builder.Services.AddSingleton<SettingService>();
            builder.Services.AddSingleton<MessageService>();

            builder.Services.AddSingleton<WordEmbeddingService>();
            builder.Services.AddSingleton<TextToSpeakService>();

            builder.Services.AddTransient<SettingViewModel>();
            builder.Services.AddTransient<SettingView>();

            builder.Services.AddSingleton<CameraBot>();
            builder.Services.AddSingleton<RecordBot>();
            builder.Services.AddSingleton<ShareBot>();
            builder.Services.AddSingleton<BotService>();
            builder.Services.AddTransient<PerceptionService>();

            builder.Services.AddTransient<BotViewModel>();
            builder.Services.AddTransient<BotView>();

            builder.Services.AddSingleton<MorphologyService>();
            builder.Services.AddSingleton<SyntaxService>();
            builder.Services.AddSingleton<GrammarService>();

            builder.Services.AddSingleton<HomeItemTemplate>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<HomeView>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
        {
            builder.ConfigureLifecycleEvents(events => {
#if ANDROID
                events.AddAndroid(android => android.OnCreate((activity, bundle) =>
                    CrossFirebase.Initialize(activity, () => Platform.CurrentActivity, CreateCrossFirebaseSettings())));
#endif
            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            return builder;
        }

        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(
                isAuthEnabled: true,
                isCloudMessagingEnabled: true);
        }
    }
}
