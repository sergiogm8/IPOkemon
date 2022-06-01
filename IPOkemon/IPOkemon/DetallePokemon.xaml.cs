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
    public sealed partial class DetallePokemon : Page
    {
        public Pokemon pokemon = PokedexPage.selectedPokemon;

        public DetallePokemon()
        {
            this.InitializeComponent();
            this.Loaded += DetallePokemon_Loaded;
        }

        private void DetallePokemon_Loaded(object sender, RoutedEventArgs e)
        {
            txtExp.Text = pokemon.exp.ToString();
            var nombrePok = pokemon.nombre.ToLower();

            switch (nombrePok)
            {
                case "azumarill":
                    ucAzumarill uc = new ucAzumarill();
                    bordeUC.Children.Add(uc);

                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PokedexPage.frame.Visibility = Visibility.Collapsed;
            Grid.SetColumnSpan(PokedexPage.gv, 4);
        }
    }
}
