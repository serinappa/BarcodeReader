using Foundation;
using ClipSample.iOS;
using UIKit;
using BarcodeReader.Services;
using BarcodeReader.iOS.Service;

[assembly: Xamarin.Forms.Dependency(typeof(ClipBoard))]

namespace ClipSample.iOS
{
    public class ClipBoard : IClipBoardService
    {
        //ペースト用メソッド
        public string GetTextFromClipBoard()
        {
            //クリップボードからテキストを取得
            var pb = UIPasteboard.General.GetValue("public.utf8-plain-text");
            return pb.ToString();
        }
        //コピー用メソッド
        public bool SetTextToClipBoard(string text)
        {
            //引数のテキストをクリップボードに格納
            UIPasteboard.General.SetValue(new NSString(text), MobileCoreServices.UTType.Text);
            return true;
        }
    }
}