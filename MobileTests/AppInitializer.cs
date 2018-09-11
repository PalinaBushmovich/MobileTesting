using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

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
                return ConfigureApp.iOS.StartApp();
            }
           
        }
    }
}