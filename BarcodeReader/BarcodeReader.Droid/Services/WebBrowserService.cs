using System;
using Android.Content;
using BarcodeReader.Android.Services;
using Xamarin.Forms;
using BarcodeReader.Services;

[assembly: Dependency(typeof(WebBrowserService))]

namespace BarcodeReader.Android.Services
{
    public class WebBrowserService : IWebBrowserService
    {
        public void Open(Uri uri)
        {
            Forms.Context.StartActivity(
                new Intent(Intent.ActionView,
                    global::Android.Net.Uri.Parse(uri.AbsoluteUri)));
        }
    }
}