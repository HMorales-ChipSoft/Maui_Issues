﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using ReproMauiIssue.Platforms.Android;

namespace ReproMauiIssue
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public MainActivity()
        {
            App.Sheet = new SheetService(this);
        }
    }
}
