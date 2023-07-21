using Plugin.FirebasePushNotification;
using System;
using testMenu.Services;
using testMenu.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMenu
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            CrossFirebasePushNotification.Current.Subscribe("Praha11");
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"Data: {p.Data["myData"]}");
            };

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
