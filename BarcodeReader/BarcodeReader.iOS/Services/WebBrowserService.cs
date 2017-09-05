using System;
using BarcodeReader.iOS.Service;
using Xamarin.Forms;
using BarcodeReader.Services;
using UIKit;

[assembly: Dependency(typeof(WebBrowserService))]

namespace BarcodeReader.iOS.Service
{
    public class WebBrowserService : IWebBrowserService
    {
        public void Open(Uri uri)
        {
            UIApplication.SharedApplication.OpenUrl(uri);
        }
    }
}