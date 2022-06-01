using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
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
    public sealed partial class ConfiguracionPage : Page
    {
        MainPage padre;
        bool idioma= false;


        public ConfiguracionPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            padre = (MainPage)e.Parameter;
        }


        private async void dialogoReiniciar()
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = "Reiniciar la aplicación",
                Content = "Los cambios se efectuarán cuando se reinicie la aplicación",
                PrimaryButtonText = "Reiniciar ahora",
                SecondaryButtonText = "Reiniciar más tarde",
                RequestedTheme = (ElementTheme)0,
                DefaultButton = ContentDialogButton.Primary,
            };
            var dialogResult = await contentDialog.ShowAsync();
            if (dialogResult == ContentDialogResult.Primary)
            {
                reiniciar();
            }
        }

        private async void reiniciar()
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

        private void switchTema_Loaded(object sender, RoutedEventArgs e)
        {
            ((ToggleSwitch)sender).IsOn = App.Current.RequestedTheme == ApplicationTheme.Light;
        }

        private void switchTema_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["themeSetting"] =
                                                     ((ToggleSwitch)sender).IsOn ? 0 : 1;

        }

        private void switchTema_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dialogoReiniciar();
        }

        private void cbIdioma_Loaded(object sender, RoutedEventArgs e)
        {
            var idioma = Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride;

            switch (idioma)
            {
                case "es-ES":
                    cbIdioma.SelectedIndex = 0;
                    break;

                case "en-US":
                    cbIdioma.SelectedIndex = 1;
                    break;
            }
        }

        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbIdioma.SelectedIndex)
            {
                case 0:
                    Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "es-ES";
                    if (idioma)
                    {
                        dialogoReiniciar();
                    }
                    idioma = true;
                    break;

                case 1:
                    Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = "en-US";
                    if (idioma)
                    {
                        dialogoReiniciar();
                    }
                    idioma = true;
                    break;
            }
            
        }

        private void cbiEsp_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dialogoReiniciar();
        }

        private void cbiIng_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            dialogoReiniciar();
        }

        private void btnPersonaje1_Checked(object sender, RoutedEventArgs e)
        {
            btnPersonaje2.IsChecked = false;
            btnPersonaje3.IsChecked = false;

            padre.personaje = imgP1.Source;
        }

        private void btnPersonaje2_Checked(object sender, RoutedEventArgs e)
        {
            btnPersonaje1.IsChecked = false;
            btnPersonaje3.IsChecked = false;

            padre.personaje = imgP2.Source;
        }

        private void btnPersonaje3_Checked(object sender, RoutedEventArgs e)
        {
            btnPersonaje1.IsChecked = false;
            btnPersonaje2.IsChecked = false;

            padre.personaje = imgP3.Source;
        }
    }
}
