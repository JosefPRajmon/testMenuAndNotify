
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using testMenu.Services;
using testMenu.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMenu
{
    public partial class App : Application
    {
        string Url { get; set;}
        public App()
        {
            InitializeComponent();
             Url = "https://172.18.32.1:7040";
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();        

#if __ANDROID__
            CrossFirebasePushNotification.Current.Subscribe("Praha11");
#elif __IOS__
#endif
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                //System.Diagnostics.Debug.WriteLine($"Data: {p.Data["myData"]}");
            };

            CrossFirebasePushNotification.Current.OnTokenRefresh += async (s, p) =>
            {
                //



                HttpClient client = new HttpClient();

                string send = "{\"apk\":\"" + "Praha11" + "\",\"token\":\"" + p.Token + "\"}";
                var json = send;
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var completUrl = Url + "/api/Message/NewUser";

                var result = await client.PostAsync(completUrl, data);



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
