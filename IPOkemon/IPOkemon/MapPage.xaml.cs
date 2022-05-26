using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Storage.Streams;
using Windows.Storage;
using Windows.Graphics.Imaging;
using Windows.System;
using Windows.UI.Popups;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IPOkemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MapPage : Page
    {
        List<MapElement> pokeparadas = new List<MapElement>();

        public MapPage()
        {
            this.InitializeComponent();
            startMap();
        }

        private void startMap()
        {    
            //Localizacion inicial en Ciudad Real
            BasicGeoposition userGeoPosition = new BasicGeoposition()
            {
                Latitude = 38.9861,
                Longitude = -3.92726
            };
            Geopoint userLocation = new Geopoint(userGeoPosition);
            this.MyMap.Center = userLocation;
            this.MyMap.ZoomLevel = 21;
            this.MyMap.TryTiltAsync(65);

            inicializarPokeParadas();
            mostrarPersonaje();
        }

        private void mostrarPersonaje()
        {
            var personaje = new MapIcon()
            {
                Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/personaje.png")),
                ZIndex = 0,
                
            };

            this.MyMap.MapElements.Add(personaje);
        }
        

        private void inicializarPokeParadas()
        {
            generarPokeparada(38.98566113922951, -3.930388779990896, "100 Montaditos");
            generarPokeparada(38.986236115082946, -3.9303103460259514, "Plaza del Prado");

            var PokeparadasLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = pokeparadas
            };

            this.MyMap.Layers.Add(PokeparadasLayer);

        }

        private void generarPokeparada (double latitud, double longitud, string titulo)
        {
            var imagenPokeparada = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pokestop.png"));
            BasicGeoposition position = new BasicGeoposition { Latitude = latitud, Longitude = longitud};
            Geopoint geopoint = new Geopoint(position);

            var pokeparada = new MapIcon
            {
                Location = geopoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Image = imagenPokeparada,
                Title = titulo
            };

            pokeparadas.Add(pokeparada);
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            BasicGeoposition pos;
            switch (e.Key)
            {
                case VirtualKey.W:
                    pos = this.MyMap.Center.Position;
                    pos.Latitude += 0.00002;
                    this.MyMap.Center = new Geopoint(pos);
                    break;

                case VirtualKey.S:
                    pos = this.MyMap.Center.Position;
                    pos.Latitude -= 0.00002;
                    this.MyMap.Center = new Geopoint(pos);
                    break;

                case VirtualKey.D:
                    pos = this.MyMap.Center.Position;
                    pos.Longitude += 0.00002;
                    this.MyMap.Center = new Geopoint(pos);
                    break;

                case VirtualKey.A:
                    pos = this.MyMap.Center.Position;
                    pos.Longitude -= 0.00002;
                    this.MyMap.Center = new Geopoint(pos);
                    break;
            }
        }

        private void MyMap_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            if (estaCerca(args.Location.Position.Latitude, args.Location.Position.Longitude))
            {
                var dialog = new MessageDialog("Hi!");
                dialog.ShowAsync();

            }
        }

        private bool estaCerca(double latParada, double lonParada)
        {
            bool estaCerca = false;
            var lat = this.MyMap.Center.Position.Latitude;
            var lon = this.MyMap.Center.Position.Longitude;

            var difLat = Math.Abs(latParada - lat);
            var difLon = Math.Abs(lonParada - lon);

            var distancia = Math.Sqrt(Math.Pow(lat,2) + Math.Pow(lon,2));

            if (distancia <= 0.0005)
            {
                estaCerca = true;
            }

            return estaCerca;
        }
    }
}
