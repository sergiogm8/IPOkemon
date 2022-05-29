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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IPOkemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class PokedexPage : Page
    {

        public List<Pokemon> pokemons = new List<Pokemon>();

        public PokedexPage()
        {
            this.InitializeComponent();

            Pokemon azumarill = new Pokemon("Azumarill", 40, 90.0, "Agua", true, "Azumarill tiene unas orejas enormes, indispensables" +
           " para hacer de sensores. Al aguzar el oído, este Pokémon puede identificar qué tipo de presa tiene cerca. Puede " +
           "detectarlo hasta en ríos de fuertes y rápidas corrientes.", "ms-appx:///Assets/azumarill.png");

            Pokemon articuno = new Pokemon("Articuno", 56, 42.0, "Hielo", false, "Articuno es un Pokémon pájaro legendario que puede " +
                "controlar el hielo. El batir de sus alas congela el aire. Dicen que consigue hacer que nieve cuando vuela.", "ms-appx:///Assets/articuno.png");

            pokemons.Add(azumarill);
            pokemons.Add(articuno);
        }

        //private void comboTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Since selecting an item will also change the text,
            // only listen to changes caused by user entering text.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();
                var splitText = sender.Text.ToLower().Split(" ");
                foreach (var pokemon in pokemons)
                {
                    var found = splitText.All((key) =>
                    {
                        return pokemon.nombre.ToLower().Contains(key);
                    });
                    if (found)
                    {
                        suitableItems.Add(pokemon.nombre);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    suitableItems.Add("No results found");
                }
                sender.ItemsSource = suitableItems;
            }
        }

        // Handle user selecting an item, in our case just output the selected item.
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var pokemon = args.SelectedItem as Pokemon;
            sender.Text = pokemon.nombre;
        }

    }
}
