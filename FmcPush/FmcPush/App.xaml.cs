﻿using Plugin.FirebasePushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FmcPush
{
    public partial class App : Application
    {
        private MainPage page;
        public App()
        {
            InitializeComponent();

            page = new MainPage();
            MainPage = page;

            page.LogMessage("starting");

            CrossFirebasePushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN : {p.Token}");
                page.LogMessage($"TOKEN : {p.Token}");
            };

            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {

                System.Diagnostics.Debug.WriteLine("Received");
                page.LogMessage("Received");
            };

            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                page.LogMessage("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }
            };

            CrossFirebasePushNotification.Current.OnNotificationAction += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Action");
                page.LogMessage("Action");

                if (!string.IsNullOrEmpty(p.Identifier))
                {
                    System.Diagnostics.Debug.WriteLine($"ActionId: {p.Identifier}");
                    foreach (var data in p.Data)
                    {
                        System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                    }
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            page.LogMessage("OnStart");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            page.LogMessage("OnSleep");
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            page.LogMessage("OnResume");
        }
    }
}
