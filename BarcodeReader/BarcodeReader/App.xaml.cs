using Autofac;
using Prism.Autofac;
using Prism.Autofac.Forms;
using BarcodeReader.Views;
using Xamarin.Forms;
using System.Reflection;

namespace BarcodeReader
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<CustomScanPage>();



            var containerUpdater = new ContainerBuilder();
            // 登録されてない型もコンテナで作成する
            containerUpdater.RegisterSource(new Autofac.Features.ResolveAnything.AnyConcreteTypeNotAlreadyRegisteredSource());

            var assembly = typeof(App).GetTypeInfo().Assembly;

            // Serviceの登録
            containerUpdater
                .RegisterAssemblyTypes(assembly)
                .Where(
                    x =>
                    x.IsInNamespace("BarcodeReader.Services")
                )
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

        }
    }
}
