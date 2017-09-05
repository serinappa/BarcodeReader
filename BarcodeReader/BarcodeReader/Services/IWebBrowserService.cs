using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Services
{
    public interface IWebBrowserService
    {
        void Open(Uri uri);
    }
}
