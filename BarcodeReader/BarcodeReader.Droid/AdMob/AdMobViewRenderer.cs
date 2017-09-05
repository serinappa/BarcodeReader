using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BarcodeReader.Droid.AdMob;
using Android.Gms.Ads;
using BarcodeReader.AdMob;

[assembly: ExportRenderer(typeof(AdMobBanner), typeof(AdMobViewRenderer))]

namespace BarcodeReader.Droid.AdMob
{
    public class AdMobViewRenderer : ViewRenderer<AdMobBanner, AdView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<AdMobBanner> e)
        {
            const string adUnitID = "ca-app-pub-4659577113559344/6086159102";

            base.OnElementChanged(e);

            if (Control == null)
            {
                var adMobBanner = new AdView(Forms.Context);
                adMobBanner.AdSize = AdSize.Banner;
                adMobBanner.AdUnitId = adUnitID;

                var requestbuilder = new AdRequest.Builder();
                adMobBanner.LoadAd(requestbuilder.Build());

                SetNativeControl(adMobBanner);
            }
        }
    }
}