using System;
using DLToolkit.Forms.Controls;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace slimWallet
{
    public partial class App : Application
    {
        public App()
        {
            // Initialize Live Reload.
#if DEBUG
            LiveReload.Init();
#endif
            InitializeComponent();

            try
            {
                FlowListView.Init(); 
                AppCenter.Start("ios=69599e3a-6844-4cb0-aab2-8e2c5c6e17ee;" + "android=a55b4d71-6b17-4a7a-9e23-f93d0c7b6430", typeof(Analytics), typeof(Crashes));
                MainPage = new NavigationPage(new CardsView());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Crashes.TrackError(e);
                throw;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }


        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
