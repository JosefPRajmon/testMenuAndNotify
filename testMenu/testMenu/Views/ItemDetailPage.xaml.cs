using System.ComponentModel;
using testMenu.ViewModels;
using Xamarin.Forms;

namespace testMenu.Views
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