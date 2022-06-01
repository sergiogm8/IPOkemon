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
using IPOkemon;
using Microsoft.Toolkit.Uwp.Notifications;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace IPOkemon
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CapturarPage : Page
    {
        Pokemon targetPokemon;
        MainPage padre;

        public CapturarPage()
        {
            this.InitializeComponent();
            this.Loaded += CapturarPage_Loaded;
        }

        private void CapturarPage_Loaded(object sender, RoutedEventArgs e)
        {
            switch (targetPokemon.nombre.ToLower())
            {
                case "azumarill":
                    ucAzumarillCapturar ucAzumarill = new ucAzumarillCapturar();
                    ucAzumarill.VerticalAlignment = VerticalAlignment.Center;
                    ucAzumarill.HorizontalAlignment = HorizontalAlignment.Center;
                    this.grid.Children.Add(ucAzumarill);
                    break;

                case "articuno":
                    ucArticunoCapturar ucArticuno = new ucArticunoCapturar();
                    ucArticuno.VerticalAlignment = VerticalAlignment.Center;
                    ucArticuno.HorizontalAlignment = HorizontalAlignment.Center;
                    this.grid.Children.Add(ucArticuno);
                    break;

                case "snorlax":
                    ucSnorlaxCapturar ucSnorlax = new ucSnorlaxCapturar();
                    ucSnorlax.VerticalAlignment = VerticalAlignment.Center;
                    ucSnorlax.HorizontalAlignment = HorizontalAlignment.Center;
                    this.grid.Children.Add(ucSnorlax);
                    break;

                case "aipom":
                    ucAipomCapturar ucAipom = new ucAipomCapturar();
                    ucAipom.VerticalAlignment = VerticalAlignment.Center;
                    ucAipom.HorizontalAlignment = HorizontalAlignment.Center;
                    this.grid.Children.Add(ucAipom);
                    break;
            }
        }

        public async void comprobarCapturado()
        {
            int numCaptura = generarNum();

            if (numCaptura == 3) // el numero 3 es el ganador de la captura
            {
                padre.numPokeballs--;
                padre.actualizarNumPokeballs();
                targetPokemon.capturado = true;
                ContentDialog contentDialog = new ContentDialog
                {
                    Title = "¡" + targetPokemon.nombre + " salvaje capturado!",
                    Content = "Se ha añadido a " + targetPokemon.nombre + " a la PokeDex",
                    PrimaryButtonText = "Continuar",
                    RequestedTheme = (ElementTheme)0,
                    DefaultButton = ContentDialogButton.Primary,
                };
                var dialogResult = await contentDialog.ShowAsync();

                if (dialogResult == ContentDialogResult.Primary) {
                    padre.navegarAPagina("mapa"); 
                }

            }
            else
            {
                switch (targetPokemon.nombre.ToLower())
                {
                    case "azumarill":
                        foreach (ucAzumarillCapturar uc in this.grid.Children) { uc.volverACapturar(); }
                        break;

                    case "articuno":
                        foreach (ucArticunoCapturar uc in this.grid.Children) { uc.volverACapturar(); }
                        break;

                    case "snorlax":
                        foreach (ucSnorlaxCapturar uc in this.grid.Children) { uc.volverACapturar(); }
                        break;

                    case "aipom":
                        foreach(ucAipomCapturar uc in this.grid.Children) { uc.volverACapturar(); }
                        break;
                }
            }
        }


        private int generarNum()
        {
            Random rand = new Random();
            return rand.Next(1, 4); //aleatorio entre 1 y 3, el 4 no se incluye
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var args = (List<object>)e.Parameter;
            targetPokemon = (Pokemon)args[0];
            padre = (MainPage)args[1];
        }

    }
}
