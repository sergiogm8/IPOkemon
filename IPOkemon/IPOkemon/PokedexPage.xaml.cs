using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
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
        List<Pokemon> pokemons;

        MainPage padre;

        public static Pokemon selectedPokemon;

        public static Frame frame;

        public static GridView gv;

        public PokedexPage()
        {
            this.InitializeComponent();
            this.Loaded += PokedexPage_Loaded;
        }

        private void PokedexPage_Loaded(object sender, RoutedEventArgs e)
        {
            comboTypes.SelectedIndex = 0;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            pokemons = new List<Pokemon>();
            padre = (MainPage)e.Parameter;
            foreach (var pokemon in padre.pokemons)
            {
                if (pokemon.capturado == true)
                {
                    pokemons.Add(pokemon);
                }
            }
        }

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
            var pokemonrecomendado = args.SelectedItem.ToString();
            foreach (var pokemon in pokemons)
            {
                if (pokemon.nombre == pokemonrecomendado)
                {
                    selectedPokemon = pokemon;
                }
            }
            frame = pokeinfo;
            gv = gvPokemons;
            pokeinfo.Visibility = Visibility.Visible;
            pokeinfo.Navigate(typeof(DetallePokemon), this);
            Grid.SetColumnSpan(gvPokemons, 2);
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                var pokemonrecomendado = args.ChosenSuggestion.ToString().ToLower();
                foreach (var pokemon in pokemons)
                {
                    if(pokemon.nombre.ToLower() == pokemonrecomendado)
                    {
                        selectedPokemon = pokemon;
                    }
                }
                frame = pokeinfo;
                gv = gvPokemons;
                pokeinfo.Visibility = Visibility.Visible;
                pokeinfo.Navigate(typeof(DetallePokemon), this);
                Grid.SetColumnSpan(gvPokemons, 2);
            }
        }

        public void Pokemon_Click(Object sender, ItemClickEventArgs e)
        { 
            selectedPokemon = (Pokemon)e.ClickedItem;
            frame = pokeinfo;
            gv = gvPokemons;
            pokeinfo.Visibility = Visibility.Visible;
            pokeinfo.Navigate(typeof(DetallePokemon), this);
            Grid.SetColumnSpan(gvPokemons,2);
        }

        private void comboTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tipo = (sender as ComboBox).SelectedItem as string;
            if ((sender as ComboBox).SelectedIndex != 0)
            {
                List<Pokemon> typespokemon = new List<Pokemon>();

                foreach (var pokemon in padre.pokemons)
                {
                    if((pokemon.tipo.ToLower() == tipo.ToLower()) && pokemon.capturado)
                    {
                        typespokemon.Add(pokemon);
                    }
                }
                pokemons.Clear();
                pokemons = typespokemon;
            }
            else
            {
                pokemons.Clear();
                List<Pokemon> typespokemon = new List<Pokemon>();
                foreach (var pokemon in padre.pokemons)
                {
                    if (pokemon.capturado)
                    {
                        typespokemon.Add(pokemon);
                    }
                }
                pokemons = typespokemon;
            }
            this.Bindings.Update();
        }
    }
}
