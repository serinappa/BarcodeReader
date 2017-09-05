using BarcodeReader.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BarcodeReader.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private string _title = "バーコードを読み取ってクリップボードにコピーします！" +
            "※URLを検知したら、ブラウザが開きます。";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string _toScanPageTitle = "バーコード読み取り";
        public string ToScanPageTitle
        {
            get { return _toScanPageTitle;  }
        }

        private DelegateCommand _toCustomScanPage = null;
        public DelegateCommand ToCustomScanPage {
            get { return _toCustomScanPage; }
        }

        public MainPageViewModel(
            INavigationService navigationService
            )
        {

             _toCustomScanPage = new DelegateCommand(() => { navigationService.NavigateAsync("CustomScanPage",null,false,false); });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }
    }
}
