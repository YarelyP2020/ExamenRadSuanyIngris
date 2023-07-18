using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExamenRadSuanyIngris.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListContactos : ContentPage
    {
        public PageListContactos()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                listacontacto.ItemsSource = await App.Database.GetAllContacto();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }

        }
        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var page = new View.Page1();
            Navigation.PushAsync(page);
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            var page = new View.Pagemaps();
            Navigation.PushAsync(page);
        }
    }
}