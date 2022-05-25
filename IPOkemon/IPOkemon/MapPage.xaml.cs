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
            this.MyMap.ZoomLevel = 19;

            inicializarPokeParadas();
        }

        private void inicializarPokeParadas()
        {
            generarPokeparada(38.98566113922951, -3.930388779990896);
            generarPokeparada(38.986236115082946, -3.9303103460259514);

            var LandmarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = pokeparadas
            };

            this.MyMap.Layers.Add(LandmarksLayer);

        }

        private void generarPokeparada (double latitud, double longitud)
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
            };

            pokeparadas.Add(pokeparada);
        }

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            //switch (e.Key)
            //{
            //    case VirtualKey.W:
            //        var pos = MyMap.Center.Position;
            //        pos.Altitude += 0.0000002;
            //        pos.Longitude += 0.000002;
            //        MyMap.Center = new Geopoint(new BasicGeoposition() { Altitude = pos.Altitude, Longitude = pos.Longitude });
            //        break;
            //}
        }
    }
}
