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
        List<Pokemon> pokemons = new List<Pokemon>();

        
        public MainPage()
        {
            this.InitializeComponent();

            Pokemon azumarill = new Pokemon("Azumarill", 40, 90.0, "Agua", true, "Azumarill tiene unas orejas enormes, indispensables" +
            " para hacer de sensores. Al aguzar el oído, este Pokémon puede identificar qué tipo de presa tiene cerca. Puede " +
            "detectarlo hasta en ríos de fuertes y rápidas corrientes.", new Uri("ms-appx:///Assets/azumarill.png"));

            Pokemon articuno = new Pokemon("Articuno", 56, 42.0, "Hielo", false, "Articuno es un Pokémon pájaro legendario que puede " +
                "controlar el hielo. El batir de sus alas congela el aire. Dicen que consigue hacer que nieve cuando vuela.", new Uri("ms-appx:///Assets/articuno.png"));

            pokemons.Add(azumarill);
            pokemons.Add(articuno);

            this.frame.Navigate(typeof(MapPage), this);
        }

        public List<Pokemon> GetPokemons()
        {
            return pokemons;
        }

    }
}
