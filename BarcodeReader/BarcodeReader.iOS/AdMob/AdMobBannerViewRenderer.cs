using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using BarcodeReader.AdMob;
using BarcodeReader.iOS.AdMob;
using Google.MobileAds;
using CoreGraphics;

[assembly: ExportRenderer(typeof(AdMobBanner), typeof(AdMobBannerRenderer))]
namespace BarcodeReader.iOS.AdMob
{

    public class AdMobBannerRenderer : ViewRenderer
    {
        const string adUnitID = "ca-app-pub-4659577113559344/9450689043";

        BannerView adMobBanner;
        bool viewOnScreen;
        UIViewController viewCtrl = null;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (e.OldElement == null)
            {

                //このforeachブロックを追加します。
                foreach (UIWindow v in UIApplication.SharedApplication.Windows)
                {
                    if (v.RootViewController != null)
                    {
                        viewCtrl = v.RootViewController;
                        break;
                    }
                }
                //またはこれでも取得可能の場合があります。
                if (viewCtrl == null)
                {
                    viewCtrl = UIApplication.SharedApplication.KeyWindow.RootViewController;
                }

                adMobBanner = new BannerView(AdSizeCons.Banner, new CGPoint(-10, 0))
                {
                    AdUnitID = adUnitID,
                    RootViewController = viewCtrl
                };
                adMobBanner.AdReceived += (sender, args) =>
                {
                    if (!viewOnScreen) AddSubview(adMobBanner);
                    viewOnScreen = true;
                };
                var req = Request.GetDefaultRequest();
                string[] s = { "fc396b2d4d0f6290e50ae8020a8ff7f3" };
                //req.TestDevices = s;
                adMobBanner.LoadRequest(req);
                SetNativeControl(adMobBanner);
            }
        }
    }
}