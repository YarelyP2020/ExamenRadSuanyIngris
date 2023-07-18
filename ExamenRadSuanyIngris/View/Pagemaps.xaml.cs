using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Geolocator.Abstractions;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using static Xamarin.Essentials.Permissions;

namespace ExamenRadSuanyIngris.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Pagemaps : ContentPage
	{
		public Pagemaps ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // esta es para obtener si tenemos conexion a internet
            var conectividad = Connectivity.NetworkAccess;

            // obtener la geolacalizacion del gps del telefono
            var loc = CrossGeolocator.Current;

            if (conectividad == NetworkAccess.Internet)
            {
                if (loc != null)
                {
                    if (!loc.IsListening)
                    {
                        await loc.StartListeningAsync(TimeSpan.FromSeconds(10), 100);
                    }
                }

                var posicion = await loc.GetPositionAsync();
                var mapcenter = new Xamarin.Forms.Maps.Position(posicion.Latitude, posicion.Longitude);
                var acercamiento = Distance.FromMeters(100);
                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(mapcenter, acercamiento));

                var Mappin = new Pin
                {
                    Position = new Xamarin.Forms.Maps.Position(posicion.Latitude, posicion.Longitude),
                    Label = "Ubicacion",
                    Type = PinType.Place
                };
            }
            else
            {
                var posicion = await loc.GetLastKnownLocationAsync();
                var mapcenter = new Xamarin.Forms.Maps.Position(posicion.Latitude, posicion.Longitude);
                var acercamiento = Distance.FromMeters(100);
                mapa.MoveToRegion(MapSpan.FromCenterAndRadius(mapcenter, acercamiento));
                var Mappin = new Pin
                {
                    Position = new Xamarin.Forms.Maps.Position(posicion.Latitude, posicion.Longitude),
                    Label = "Ubicacion",
                    Type = PinType.Place
                };
                mapa.Pins.Add(Mappin);
            }
        }

    }
}