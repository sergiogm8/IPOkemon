using IPOkemon;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
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
        public int numPokeballs = 5;

        public MainPage()
        {
            this.InitializeComponent();

            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(900, 700));
            Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().VisibleBoundsChanged += MainPage_VisibleBoundsChanged;
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "en-US";
            ResourceContext.GetForViewIndependentUse().Reset();
            ResourceContext.GetForCurrentView();

            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                 new AdaptiveText()
                                 {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                 },
                                 new AdaptiveText()
                                 {
                                    Text = "Un proyecto de IPO2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                 },
                            }
                        }
                    },
                    TileWide = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "Version 1.0",

                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un poryecto de IPO 2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Aplicacion sobre Pokemon hecha con tecnologia UWP",
                                    HintWrap = true,
                                }
                            }
                        }
                    },

                    TileLarge = new TileBinding()
                    {
                        Content = new TileBindingContentAdaptive()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "IPOkemon",
                                    HintStyle = AdaptiveTextStyle.Subtitle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Un Proyecto de IPO2",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                },
                                new AdaptiveText()
                                {
                                    Text = "Una aplicación sobre Pokemon hecha con tecnología UWP",
                                    HintStyle = AdaptiveTextStyle.CaptionSubtle
                                }
                            }
                        }
                    },
                }
            };
            var notification = new TileNotification(content.GetXml());
            notification.ExpirationTime = DateTimeOffset.UtcNow.AddSeconds(30);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(notification);

            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Pokemon azumarill = new Pokemon("Azumarill", 40, 90, "Agua", true, "Azumarill tiene unas orejas enormes, indispensables" +
            " para hacer de sensores. Al aguzar el oído, este Pokémon puede identificar qué tipo de presa tiene cerca. Puede " +
            "detectarlo hasta en ríos de fuertes y rápidas corrientes.", "ms-appx:///Assets/azumarill.png");

            Pokemon articuno = new Pokemon("Articuno", 56, 83, "Hielo", true, "Articuno es un Pokémon pájaro legendario que puede " +
                "controlar el hielo. El batir de sus alas congela el aire. Dicen que consigue hacer que nieve cuando vuela.", "ms-appx:///Assets/articuno.png");

            Pokemon snorlax = new Pokemon("Snorlax", 38, 80, "Normal", true, "Un día cualquiera en la vida de Snorlax consiste en comer " +
                "y dormir. Es un Pokémon tan dócil que es fácil ver niños usando la gran panza que tiene como lugar de juegos", "ms-appx:///Assets/snorlax.png");

            Pokemon aipom = new Pokemon("Aipom", 29, 76, "Normal", false, "La cola de Aipom termina en una especie de mano a la que, con un poco de cabeza, se" +
                " le puede dar muy buen uso. Pero hay un problema: como se ha acostumbrado a usarla mucho, las de verdad se le han vuelto algo torponas.", "ms-appx:///Assets/aipom.png");

            Pokemon castform = new Pokemon("Castform", 23, 78, "Normal", false, "Castform se vale del poder de la naturaleza para tomar el aspecto del sol, la " +
                "lluvia o nubarrones de nieve. El estado de ánimo de este Pokémon varía según el clima.", "ms-appx:///Assets/castform.png");

            Pokemon swablu = new Pokemon("Swablu", 43, 95, "Volador", true, "Swablu tiene unas alas ligeras y esponjosas que parecen nubes de algodón. A este " +
                "Pokémon no le asusta la gente. De hecho, puede llegar a posarse en la cabeza de alguien y servirle de gorro sedoso.", "ms-appx:///Assets/swablu.png");

            pokemons.Add(azumarill);
            pokemons.Add(articuno);
            pokemons.Add(snorlax);
            pokemons.Add(aipom);
            pokemons.Add(castform);
            pokemons.Add(swablu);

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
           // if (this.frame.SourcePageType != typeof(ConfiguracionPage))
            //{
                navegarAPagina("configuracion");
            //}
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.frame.SourcePageType != typeof(HomePage))
            {
                navegarAPagina("inicio");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.frame.SourcePageType != typeof(MapPage))
            {
                navegarAPagina("mapa");
                mostrarNumPokeballs();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.frame.SourcePageType != typeof(PokedexPage))
            {
                navegarAPagina("pokedex");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // if (this.frame.SourcePageType != typeof(ConfiguracionPage))
            //{
            navegarAPagina("configuracion");
            //}
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
