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
    public sealed partial class PokeparadaPage : Page
    {
        MainPage padre;

        public PokeparadaPage()
        {
            this.InitializeComponent();
            this.Loaded += PokeparadaPage_Loaded;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            padre = (MainPage)e.Parameter;
        }

        private void PokeparadaPage_Loaded(object sender, RoutedEventArgs e)
        {
            sbIconoClick.Begin();
        }

        private void imParada_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            int numPokeballs = generarNumPokeballs();
            this.imMano.Visibility = Visibility.Collapsed;
            this.imParada.IsHitTestVisible = false;

            switch (numPokeballs)
            {
                case 1:
                    sb1Pokeball.Begin();
                    break;

                case 2:
                    sb2Pokeball.Begin();
                    break;

                case 3:
                    sb3Pokeball.Begin();
                    break;
            }
        }

        private int generarNumPokeballs()
        {
            Random rand = new Random();
            return rand.Next(1, 4);
        }

        private void burbuja1_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.burbuja1.Visibility = Visibility.Collapsed;
            padre.numPokeballs += 1;
            padre.actualizarNumPokeballs();
        }

        private void burbuja2_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.burbuja2.Visibility = Visibility.Collapsed;
            padre.numPokeballs += 1;
            padre.actualizarNumPokeballs();
        }

        private void burbuja3_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.burbuja3.Visibility = Visibility.Collapsed;
            padre.numPokeballs += 1;
            padre.actualizarNumPokeballs();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            padre.navegarAPagina("mapa");
        }
    }
}
