using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net.Interop;

[assembly: Dependency(typeof(XamarinApp.Droid.Config)) ]
namespace XamarinApp.Droid
{
    public class Config : IConfig
    {
        string IConfig.PathSQLite => System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        ISQLitePlatform IConfig.Plataforma => new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
    }
}