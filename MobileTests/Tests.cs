using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MobileTests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp _app;
        Platform platform;

        private string _searchText = "пылесос";
        private string _scrollDownToText = "Робот для уборки пола Xiaomi Mi Robot(белый)";

        private string _path = @"C:\MobileTests\test.apk";

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(platform, _path);
        }

        [Test]
        public void PerformSearch_VerifyThatSearchResultsAreDisplayed()
        {        
            _app.Tap(c => c.Id("nextView"));
            _app.Tap(c => c.Id("nextView"));
            _app.Tap(c => c.Id("nextView"));
            _app.Tap(c => c.Id("nextView"));
            _app.Tap(c => c.Id("nextView"));
            _app.EnterText(c => c.Id("menu_search"), _searchText);
            _app.PressEnter();
            _app.DismissKeyboard();
             _app.ScrollDown();
            
            AppResult[] results = _app.WaitForElement(c => c.Marked(_scrollDownToText));

             _app.Screenshot("Screen from onliner.");

            Assert.IsTrue(results.Length > 0, $"Search text '{_scrollDownToText}' is not found");
        }
    }
}
