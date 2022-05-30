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
        List<MapElement> pokemonsMapa = new List<MapElement>();
        MainPage padre;
        List<Pokemon> pokemons;
        List<string> listaNombresPokemon = new List<string>();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            padre = (MainPage)e.Parameter;
        }


        public MapPage()
        {
            this.InitializeComponent();
            this.Loaded += MapPage_Loaded; 
        }

        private void MapPage_Loaded(object sender, RoutedEventArgs e)
        {
            pokemons = padre.pokemons;
            popularListaNombresPokemon();
            startMap();
        }

        private void popularListaNombresPokemon()
        {
            foreach (var pokemon in pokemons) {
                listaNombresPokemon.Add(pokemon.nombre.ToLower());
            };            
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
            this.MyMap.ZoomLevel = 20;

            inicializarPokeParadas();
            mostrarPersonaje();
            mostrarPokemons();
        }

        private void mostrarPokemons()
        {
            foreach (Pokemon pokemon in pokemons){
                if (!pokemon.capturado)
                {
                    float [] coords = generarCoordenadas();
                    generarPokemonEnMapa(pokemon, coords[0], coords[1]);
                }
            };

            var PokemonsLayer = new MapElementsLayer
            {
                ZIndex = 2,
                MapElements = pokemonsMapa,
            };

            this.MyMap.Layers.Add(PokemonsLayer);
        }

        private float[] generarCoordenadas()
        {
            /// <summary>
            /// Genera coordenadas aleatorias en Ciudad Real
            /// </summary>

            float latitudMin = (float)38.97074;
            float latitudMax = (float)38.99677;

            float longitudMin = (float)-3.93978;
            float longitudMax = (float)-3.91321;

            Random random = new Random();
            double latitud = (random.NextDouble() * (latitudMax - latitudMin) + latitudMin);
            double longitud = (random.NextDouble() * (longitudMax - longitudMin) + longitudMin);

            float[] coords = { (float)latitud, (float)longitud };

            return coords;

        }

        private void generarPokemonEnMapa(Pokemon pokemon, float latitud, float longitud)
        {
            var imagenPokemon = RandomAccessStreamReference.CreateFromUri(new Uri(pokemon.sprite));
            BasicGeoposition position = new BasicGeoposition { Latitude = latitud, Longitude = longitud };
            Geopoint geopoint = new Geopoint(position);

            var pokemonIcon = new MapIcon
            {
                Location = geopoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                ZIndex = 0,
                Image = imagenPokemon,
                Tag = pokemon.nombre.ToLower(),
            };

            pokemonsMapa.Add(pokemonIcon);
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
            generarPokeparada(38.985473359070255, -3.9285764690181963, "Plaza Mayor");
            generarPokeparada(38.98360641578028, -3.928732671997921, "Plaza del Pilar");
            generarPokeparada(38.980653503427895, -3.9344916604708136, "Parque Gasset");
            generarPokeparada(38.99571734821603, -3.9277336289923053, "Puerta de Toledo");
            generarPokeparada(38.99205807085641, -3.931160563038975, "Plaza de toros");
            generarPokeparada(38.986343533956315, -3.9292627158631053, "Museo de Ciudad Real");

            var PokeparadasLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = pokeparadas,
                
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
                Title = titulo,
                Tag = "pokeparada"
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

        private async void MyMap_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            var elementos = args.MapElements;
            string tag = "";
            bool esPokemon = false;
            foreach (var elemento in elementos)
            {
                tag = (string)elemento.Tag;
            }

            if (listaNombresPokemon.Contains(tag)) {esPokemon = true; } //sabemos si el elemento clickado es un pokemon si la lista de pokemons contiene el tag

            if (estaCerca(args.Location.Position.Latitude, args.Location.Position.Longitude))
            {
                if (esPokemon)
                {
                    if (padre.numPokeballs > 0)
                    {
                        int posPokemon = 0;
                        for (int i = 0; i < pokemons.Count(); i++)
                        {
                            if (tag == pokemons[i].nombre.ToLower()) { posPokemon = i; break; }
                        }
                        List<object> argsToPass = new List<object>();
                        argsToPass.Add(pokemons[posPokemon]); //0
                        argsToPass.Add(padre); //1
                        padre.navegarAPagina("capturar", argsToPass);
                    }
                    else
                    {
                        ContentDialog dialog = new ContentDialog
                        {
                            Title = "¡No tienes Pokeballs!",
                            Content = "Ve a alguna pokeparada para coger Pokeballs",
                            RequestedTheme = (ElementTheme)0,
                            PrimaryButtonText = "Aceptar",
                            DefaultButton = ContentDialogButton.Primary
                        };
                    }
                }
                else
                {
                    padre.navegarAPagina("pokeparada");
                }
            }
            else
            {
                if (esPokemon)
                {
                    ContentDialog dialog = new ContentDialog
                    {
                        Title = "Pokemon no alcanzable",
                        Content = "¡El pokemon está demasiado lejos! Acércate más",
                        PrimaryButtonText = "Aceptar",
                        DefaultButton = ContentDialogButton.Primary,
                        RequestedTheme = (ElementTheme)0,
                    };
                    await dialog.ShowAsync();
                }
                else
                {
                    ContentDialog dialog = new ContentDialog
                    {
                        Title = "Pokeparada no alcanzable",
                        Content = "¡Debes estar más cerca!",
                        PrimaryButtonText = "Aceptar",
                        DefaultButton = ContentDialogButton.Primary,
                        RequestedTheme = (ElementTheme)0,
                    };
                    await dialog.ShowAsync();
                }
            }
        }

        private bool estaCerca(double latParada, double lonParada)
        {
            bool estaCerca = false;
            var lat = this.MyMap.Center.Position.Latitude;
            var lon = this.MyMap.Center.Position.Longitude;

            var difLat = Math.Abs(latParada - lat);
            var difLon = Math.Abs(lonParada - lon);

            var distancia = Math.Sqrt(Math.Pow(difLat,2) + Math.Pow(difLon,2));

            if (distancia <= 0.0003)
            {
                estaCerca = true;
            }
            else { 
                estaCerca = false; 
            }

            return estaCerca;
        }

    }
}
