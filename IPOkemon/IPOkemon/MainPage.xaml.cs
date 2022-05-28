using PokemonUWP;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace IPOkemon
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<Pokemon> pokemons = new List<Pokemon>();

        
        public MainPage()
        {
            this.InitializeComponent();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(320, 320));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;

            this.Loaded += MainPage_Loaded;

        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Pokemon azumarill = new Pokemon("Azumarill", 40, 90.0, "Agua", false, "Azumarill tiene unas orejas enormes, indispensables" +
            " para hacer de sensores. Al aguzar el oído, este Pokémon puede identificar qué tipo de presa tiene cerca. Puede " +
            "detectarlo hasta en ríos de fuertes y rápidas corrientes.", "ms-appx:///Assets/azumarill.png");

            Pokemon articuno = new Pokemon("Articuno", 56, 42.0, "Hielo", false, "Articuno es un Pokémon pájaro legendario que puede " +
                "controlar el hielo. El batir de sus alas congela el aire. Dicen que consigue hacer que nieve cuando vuela.", "ms-appx:///Assets/articuno.png");

            Pokemon snorlax = new Pokemon("Snorlax", 38, 79.5, "Normal", false, "Un día cualquiera en la vida de Snorlax consiste en comer " +
                "y dormir. Es un Pokémon tan dócil que es fácil ver niños usando la gran panza que tiene como lugar de juegos", "ms-appx:///Assets/snorlax.png");

            pokemons.Add(azumarill);
            pokemons.Add(articuno);
            pokemons.Add(snorlax);

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
                    this.frame.Navigate(typeof(MainPage));
                    break;
                case "mapa":
                    this.frame.Navigate(typeof(MapPage), this);
                    break;
                case "pokedex":
                    break;
                case "configuracion":
                    break;
                case "capturar":
                    this.frame.Navigate(typeof(CapturarPage), args);
                    break;
            }
        }

        private void btnInicio_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            navegarAPagina("inicio");
        }

        private void btnCapturar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            navegarAPagina("mapa");
        }
    }
}
