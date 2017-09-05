using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Services
{
    public interface IClipBoardService
    {
        //ペースト用メソッド
        String GetTextFromClipBoard();
        //コピー用メソッド
        bool SetTextToClipBoard(string text);
    }
}
