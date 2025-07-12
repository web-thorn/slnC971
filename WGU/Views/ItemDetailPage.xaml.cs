using System.ComponentModel;
using WGU.ViewModels;
using Xamarin.Forms;

namespace WGU.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}