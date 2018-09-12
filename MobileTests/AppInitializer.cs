using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Microsoft.AppCenter;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Distribute;

namespace MobileTests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform, string pathToApp)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.ApkFile(pathToApp).StartApp();
            }
            else
            {
                
                AppCenter.Start("{Your Xamarin iOS App Secret}", typeof(Distribute));
                return ConfigureApp.iOS.StartApp();
            }
           
        }
    }
}