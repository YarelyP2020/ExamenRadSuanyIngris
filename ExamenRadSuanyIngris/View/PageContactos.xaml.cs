using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Reflection;
using System.Xml;
using Plugin.Media;

namespace ExamenRadSuanyIngris.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        // Variable que guardara la foto 
        Plugin.Media.Abstractions.MediaFile photo = null;
        public Page1()
        {
            InitializeComponent();
        }
        public byte[] GetImageToBytes()
        {
            if (photo != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = photo.GetStream();
                    stream.CopyTo(memory);
                    byte[] bytes = memory.ToArray();

                    return bytes;
                }
            }

            return null;
        }


        private async void btnproceso_Clicked(object sender, EventArgs e)
        {
            if (Nombres.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UN NOMBRE", "OK");
                Nombres.Focus();
            }
            if (Nombres.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UN APELLIDO", "OK");
                Apellidos.Focus();
            }
            else if (Edad.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UN TELEFONO", "OK");
                Edad.Focus();
            }
            else if (Pais.SelectedItem == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UN PAIS", "OK");
                Pais.Focus();
            }
            else if (Nota.Text == null)
            {
                await DisplayAlert("ALERTA", "DEBES ESCRIBIR UNA NOTA", "OK");
                Nota.Focus();
            }

            else
            {


                var contacto = new Model.ClassContactos
                {
                    Nombres = Nombres.Text,
                    Apellidos = Apellidos.Text,
                    Edad = Convert.ToInt32(Edad.Text),
                    Pais = Pais.SelectedItem.ToString(),
                    Nota = Nota.Text,
                    Imagen = GetImageToBytes()
                };

                if (await App.Database.AddContacto(contacto) > 0)
                {
                    await DisplayAlert("Aviso", "Contacto guardado correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Aviso", "No se pudo guardar", "OK");
                    limpiar();
                    var page = new View.PageResultado();
                    //page.BindingContext = result;
                    await Navigation.PushAsync(page);
                }

            }
        }
        private async void btnImagen_Clicked(object sender, EventArgs e)
        {
            photo = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "APP",
                Name = "foto.jpg",
                SaveToAlbum = true
            });

            if (photo != null)
            {
                Imagen.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
        }
        private void limpiar()
        {
            Nombres.Text = "";
            Apellidos.Text = "";
            Edad.Text = "";

            Pais.SelectedIndex = -1; Nota.Text = "";

        }

        private void btnactualizar_Clicked(object sender, EventArgs e)
        {

        }
    }
}