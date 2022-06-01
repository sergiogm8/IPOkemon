using IPOkemon;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace IPOkemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Pokemon> pokemons = new List<Pokemon>();
        public int numPokeballs = 5;
        public ImageSource personaje;

        public MainPage()
        {
            this.InitializeComponent();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(900, 700));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += opcionVolver;

            this.Loaded += MainPage_Loaded;
        }

        private void opcionVolver(object sender, BackRequestedEventArgs e)
        {
            if (frame.BackStack.Any())
            {
                frame.GoBack();
            }
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if ((int)ApplicationData.Current.LocalSettings.Values["themeSetting"] == 0)
            {
                String pathPokeball = "ms-appx:///Assets/ic_pokeball_claro.png";
                Uri uriPokeball = new Uri(pathPokeball);
                BitmapImage bitmapPokeball = new BitmapImage(uriPokeball);

                String pathPokedex = "ms-appx:///Assets/ic_pokedex_claro.png";
                Uri uriPokedex = new Uri(pathPokedex);
                BitmapImage bitmapPokedex = new BitmapImage(uriPokedex);

                icoPokedex.Source = bitmapPokedex;
                icoCapturar.Source = bitmapPokeball;
            }
            else if((int)ApplicationData.Current.LocalSettings.Values["themeSetting"] == 1) {
                String pathPokeball = "ms-appx:///Assets/ic_pokeball_oscuro.png";
                Uri uriPokeball = new Uri(pathPokeball);
                BitmapImage bitmapPokeball = new BitmapImage(uriPokeball);

                String pathPokedex = "ms-appx:///Assets/ic_pokedex_oscuro.png";
                Uri uriPokedex = new Uri(pathPokedex);
                BitmapImage bitmapPokedex = new BitmapImage(uriPokedex);

                icoPokedex.Source = bitmapPokedex;
                icoCapturar.Source = bitmapPokeball;
            }

            Pokemon azumarill = new Pokemon("Azumarill", 40, 90, "Agua", false, "Azumarill tiene unas orejas enormes, indispensables" +
            " para hacer de sensores. Al aguzar el oído, este Pokémon puede identificar qué tipo de presa tiene cerca. Puede " +
            "detectarlo hasta en ríos de fuertes y rápidas corrientes.", "ms-appx:///Assets/azumarill.png");

            Pokemon articuno = new Pokemon("Articuno", 56, 83, "Hielo", false, "Articuno es un Pokémon pájaro legendario que puede " +
                "controlar el hielo. El batir de sus alas congela el aire. Dicen que consigue hacer que nieve cuando vuela.", "ms-appx:///Assets/articuno.png");

            Pokemon snorlax = new Pokemon("Snorlax", 38, 80, "Normal", false, "Un día cualquiera en la vida de Snorlax consiste en comer " +
                "y dormir. Es un Pokémon tan dócil que es fácil ver niños usando la gran panza que tiene como lugar de juegos", "ms-appx:///Assets/snorlax.png");

            Pokemon aipom = new Pokemon("Aipom", 29, 76, "Normal", false, "La cola de Aipom termina en una especie de mano a la que, con un poco de cabeza, se" +
                " le puede dar muy buen uso. Pero hay un problema: como se ha acostumbrado a usarla mucho, las de verdad se le han vuelto algo torponas.", "ms-appx:///Assets/aipom.png");

            Pokemon castform = new Pokemon("Castform", 23, 78, "Normal", true, "Castform se vale del poder de la naturaleza para tomar el aspecto del sol, la " +
                "lluvia o nubarrones de nieve. El estado de ánimo de este Pokémon varía según el clima.", "ms-appx:///Assets/castform.png");

            Pokemon swablu = new Pokemon("Swablu", 43, 95, "Volador", true, "Swablu tiene unas alas ligeras y esponjosas que parecen nubes de algodón. A este " +
                "Pokémon no le asusta la gente. De hecho, puede llegar a posarse en la cabeza de alguien y servirle de gorro sedoso.", "ms-appx:///Assets/swablu.png");

            Pokemon togepi = new Pokemon("Togepi", 26, 65, "Hada", false, "Togepi usa los sentimientos positivos de compasión y alegría que desprenden las personas y " +
                "los Pokémon. Este Pokémon almacena sentimientos de felicidad en su interior y después los comparte con otros.", "ms-appx:///Assets/togepi.png");

            Pokemon piplup = new Pokemon("Piplup", 15, 90, "Agua", true, "No se le da bien lo de andar, se cae mucho. Pero su orgullo le hace sacar pecho como si nada"
                , "ms-appx:///Assets/piplup.png");

            Pokemon pikachu = new Pokemon("Pikachu", 34, 54, "Eléctrico", true, "Cada vez que un Pikachu se encuentra con algo nuevo, le lanza una descarga eléctrica." +
                " Cuando se ve alguna baya chamuscada, es muy probable que sea obra de un Pikachu, ya que a veces no controlan la intensidad de la descarga.", "ms-appx:///Assets/pikachu.png");

            Pokemon charmander = new Pokemon("Charmander", 14, 43, "Fuego", true, "La llama que tiene en la punta de la cola arde según sus sentimientos. Llamea levemente " +
                "cuando está alegre y arde vigorosamente cuando está enfadado.", "ms-appx:///Assets/charmander.png");

            Pokemon electrike = new Pokemon("Electrike", 5, 50, "Eléctrico", true, "Electrike genera electricidad usando la fricción de la atmósfera. En estaciones de vientos" +
                " áridos, su cuerpo se inflama y lanza chispas de forma violenta. Suele vivir cerca de centrales eléctricas. Pero si hay algún humano cerca que le dé de comer, " +
                "entonces se ganará su amistad. También es un gran corredor, se escapa al ojo humano.", "ms-appx:///Assets/electrike.png");

            Pokemon gyarados = new Pokemon ("Gyarados", 90, 0, "Agua", true, "Es un Pokémon extremadamente violento.Se han visto bancos de estos Pokémon devorando y devastando " +
                "ciudades enteras.Vive tanto en agua dulce como marina, pero a diferencia de Magikarp, Gyarados es muy territorial y agresivo. No dudará ni un segundo en atacar a " +
                "cualquier Pokémon que entre en su territorio.Cuando Magikarp evoluciona a Gyarados sus células cerebrales sufren un cambio bastante exagerado y se vuelve mucho más agresivo."
                , "ms-appx:///Assets/gyarados.png");

            Pokemon garchomp = new Pokemon("Garchomp", 54, 10, "Dragón", true, "Se dice que, cuando va a velocidad máxima, sus alas crean cuchillas de viento que talan cualquier árbol"
                , "ms-appx:///Assets/garchomp.png");

            Pokemon snivy = new Pokemon("Snivy", 47, 21, "Planta", true, "Su cola, en forma de hoja, es la encargada de realizar la fotosíntesis. Si se queda sin energía, ésta se dobla hacia abajo." +
                " Se dice que cuando son salvajes, también tienen la capacidad de adaptarse mejor al medio que les rodea, siendo esto naturalmente en bosques o selvas muy densas, aunque cuando es entrenado," +
                " se transforma en pedante y altanero. Se dice que si cree que su entrenador no es digno de él, lo abandonará. Los Snivy son muy elegantes, y fuertes, por eso no aguantan perder de ninguna manera.", "ms-appx:///Assets/snivy.png");



            pokemons.Add(azumarill);
            pokemons.Add(articuno);
            pokemons.Add(snorlax);
            pokemons.Add(aipom);
            pokemons.Add(castform);
            pokemons.Add(swablu);
            pokemons.Add(togepi);
            pokemons.Add(piplup);
            pokemons.Add(pikachu);
            pokemons.Add(charmander);
            pokemons.Add(electrike);
            pokemons.Add(gyarados);
            pokemons.Add(garchomp);
            pokemons.Add(snivy);

            navegarAPagina("inicio");
        }

        private void flipMenu(object sender, RoutedEventArgs e)
        {
            this.sView.IsPaneOpen = !this.sView.IsPaneOpen;
        }

        private void MainPage_VisibleBoundsChanged(Windows.UI.ViewManagement.ApplicationView sender, object args)
        {
            var Width =
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBounds.Width;
            if (Width >= 720)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactInline;
                sView.IsPaneOpen = true;
            }
            else if (Width >= 360)
            {
                sView.DisplayMode = SplitViewDisplayMode.CompactOverlay;
                sView.IsPaneOpen = false;
            }
            else
            {
                sView.DisplayMode = SplitViewDisplayMode.Overlay;
                sView.IsPaneOpen = false;
            }
        }

        public void navegarAPagina(string pagina, List<object> args = null)
        {
            switch (pagina)
            {
                case "inicio":
                    ocultarNumPokeballs();
                    this.frame.Navigate(typeof(HomePage), this);
                    break;
                case "mapa":
                    mostrarNumPokeballs();
                    this.frame.Navigate(typeof(MapPage), this);
                    break;
                case "pokeparada":
                    this.frame.Navigate(typeof(PokeparadaPage), this);
                    break;
                case "pokedex":
                    ocultarNumPokeballs();
                    this.frame.Navigate(typeof(PokedexPage), this);
                    break;
                case "configuracion":
                    ocultarNumPokeballs();
                    this.frame.Navigate(typeof(ConfiguracionPage), this);
                    break;
                case "capturar":
                    ocultarNumPokeballs();
                    this.frame.Navigate(typeof(CapturarPage), args);
                    break;
            }
        }


        private void btnCapturar_Click(object sender, RoutedEventArgs e)
        {
            if (this.frame.SourcePageType != typeof(MapPage))
            {
                navegarAPagina("mapa");
                mostrarNumPokeballs();
            }
        }

        public async void reiniciarApp()
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "Reiniciar aplicación",
                Content = "Para aplicar los cambios es necesario reiniciar la aplicación",
                PrimaryButtonText = "Reiniciar",
                RequestedTheme = (ElementTheme)0,
                DefaultButton = ContentDialogButton.Primary,
            };
            var dialogResult = await contentDialog.ShowAsync();

            if (dialogResult == ContentDialogResult.Primary)
            {
                var result = await CoreApplication.RequestRestartAsync("Application Restart Programmatically ");
                if (result == AppRestartFailureReason.NotInForeground ||
                    result == AppRestartFailureReason.RestartPending ||
                    result == AppRestartFailureReason.Other)
                {
                    var msgBox = new MessageDialog("Restart Failed", result.ToString());
                    await msgBox.ShowAsync();
                }
            }
        }

        private void btnInicio_Click(object sender, RoutedEventArgs e)
        {
            if (this.frame.SourcePageType != typeof(HomePage))
            {
                navegarAPagina("inicio");
            }
        }
        
        private void btnPokedex_Click(object sender, RoutedEventArgs e)
        {
            if (this.frame.SourcePageType != typeof(PokedexPage))
            {
                navegarAPagina("pokedex");
            }
        } 
        
        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            if (this.frame.SourcePageType != typeof(ConfiguracionPage))
            {
                navegarAPagina("configuracion");
            }
        }

        public void ocultarNumPokeballs()
        {
            this.txtNumPokeballs.Text = "X" + numPokeballs.ToString();
            this.imgNumPokeballs.Visibility = Visibility.Collapsed;
            this.txtNumPokeballs.Visibility = Visibility.Collapsed;
        }

        public void mostrarNumPokeballs()
        {
            this.imgNumPokeballs.Visibility = Visibility.Visible;
            this.txtNumPokeballs.Visibility = Visibility.Visible;
        }

        public void actualizarNumPokeballs()
        {
            this.txtNumPokeballs.Text = "X" + numPokeballs.ToString();
        } 
    }
}
