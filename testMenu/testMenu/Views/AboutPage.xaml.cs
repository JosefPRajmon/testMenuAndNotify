using Plugin.FirebasePushNotification;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace testMenu.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            // Tento příklad kódu ukazuje, jak číst trasy GPS ze souboru GPX
            // Načtěte soubor GPX
           
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                try
                {

                DisplayAlert("notification",$"Dat: {p.Data["mydata"]}","ok");
                }
                catch (Exception)
                {

                }
            };

        }
    }
}