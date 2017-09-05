using BarcodeReader.Services;
using Prism.Navigation;
using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarcodeReader.Views
{
    public partial class CustomScanPage
        : ContentPage
    {
        ZXingScannerView zxing;
        IWebBrowserService webBrowser;
        IClipBoardService _clip;
        Label resultLabl = new Label() { HorizontalOptions = LayoutOptions.CenterAndExpand};
        string prevSearchText = "";
        public CustomScanPage(
          //  INavigationService navigationService
            ) : base()
        {

            _clip = Xamarin.Forms.DependencyService.Get<IClipBoardService>(); ;
            webBrowser = Xamarin.Forms.DependencyService.Get<IWebBrowserService>();
            InitializeComponent();
            SizeChanged += (t,w) =>
            {
                var MIN_WIDTH = 160;
                var MIN_HEIGHT = 40;
                var _width = Width * 0.5;
                var _height = Height * 0.2;
                if (zxing!=null)
                {
                    
                    zxing.WidthRequest = _width < MIN_WIDTH ? MIN_WIDTH : _width;
                    zxing.HeightRequest = _height < MIN_HEIGHT ? MIN_HEIGHT : _height;
                    return;
                }

                zxing = new ZXingScannerView
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    WidthRequest = _width,
                    HeightRequest = _height
                };
                zxing.OnScanResult += (result) => {
                    // 前回と同じ読み込みなら何もしない
                    if (result.Text == prevSearchText) return;
                    prevSearchText = result.Text;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        // Stop analysis until we navigate away so we don't keep reading barcodes
                        zxing.IsAnalyzing = false;
                        // Show an alert
                        // await DisplayAlert("クリップボードにコピーしました", result.Text, "OK");
                        _clip.SetTextToClipBoard(result.Text);
                        // ラベルのテキストを更新
                        resultLabl.Text = "クリップボードに【" + result.Text + "】をコピーしました。";
                        // await navigationService.GoBackAsync();
                        OpenBrawser(result.Text);
                    });
                 };
                var grid = new Grid
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };
                grid.Children.Add(zxing);
                // grid.Children.Add(overlay);

                // The root page of your application
                MainBoard.Children.Add(grid);
                MainBoard.Children.Add(resultLabl);
            };
        }


        protected void OpenBrawser(string text)
        {
            try
            {
                Uri url = new Uri(text);
                Device.OpenUri(url);
            }catch(Exception e)
            {

            }
            finally
            {

            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}
