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
    public sealed partial class HomePage : Page
    {
        MainPage padre;
        List<Pokemon> pokemons;

        public HomePage()
        {
            this.InitializeComponent();
            this.Loaded += HomePage_Loaded;
            
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            pokemons = padre.pokemons;

            foreach (var pokemon in pokemons)
            {
                if (!pokemon.capturado)
                {
                    ucAvistado uc = new ucAvistado(pokemon);
                    spAvistamientos.Children.Add(uc);
                }

                if (pokemon.exp >= 75.0)
                {
                    ucEntrenar uc = new ucEntrenar(pokemon);
                    spEntrenar.Children.Add(uc);
                }
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            padre = (MainPage)e.Parameter;
        }
    }
}
