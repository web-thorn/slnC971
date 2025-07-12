using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WGU.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WGU.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermsPage : ContentPage
    {
        TermsViewModel _viewModel;
        public TermsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TermsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}