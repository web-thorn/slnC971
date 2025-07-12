using System;
using WGU.Models;
using WGU.Services;
using WGU.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WGU
{
    public partial class App : Application
    {
        private readonly ITermDataStore<Term> DataStore;
        public App()
        {
            InitializeComponent();

            DependencyService.Register<TermDataStore>();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();

            DataStore = DependencyService.Get<ITermDataStore<Term>>();
        }

        protected override void OnStart()
        {
            DataStore.InitializeDataStore();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
