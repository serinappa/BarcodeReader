using Android.Content;
using BarcodeReader.Droid.Services;
using Xamarin.Forms;
using BarcodeReader.Services;

[assembly: Dependency(typeof(ClipBoard_Droid))]

namespace BarcodeReader.Droid.Services
{

    public class ClipBoard_Droid : IClipBoardService
    {
        //ペースト用メソッド
        public string GetTextFromClipBoard()
        {
            //クリップボードからテキストを取得
            var clipboardmanager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            var item = clipboardmanager.PrimaryClip.GetItemAt(0);
            var text = item.Text;
            return text;
        }
        //コピー用メソッド
        public bool SetTextToClipBoard(string text)
        {
            //引数のテキストをクリップボードに格納
            var clipboardManager = (ClipboardManager)Forms.Context.GetSystemService(Context.ClipboardService);
            ClipData clip = ClipData.NewPlainText("", text);
            clipboardManager.PrimaryClip = clip;

            return true;
        }
    }
}