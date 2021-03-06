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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemon
{
    public sealed partial class ucAzumarill : UserControl
    {
        DispatcherTimer dtVida;
        DispatcherTimer dtEscudo;
        DispatcherTimer dt;

        Storyboard sbCurar;
        Storyboard sbSaltar;
        Storyboard sbMovimiento;
        Storyboard sbMoverBrazos;
        Storyboard sbMoverOrejaIzq;
        Storyboard sbMoverCola;
        Storyboard sbCurarEscudo;
        Storyboard sbMovBrazosLento;
        Storyboard sbMovColaLento;
        Storyboard sbMovLento;
        Storyboard sbMovOrejaIzqLento;
        Storyboard sbflashingVida;
        Storyboard sbDerrotado;
        Storyboard sbRayoBurbuja;
        Storyboard sbRayoBurbujaFuerza;
        Storyboard sbFuria;
        Storyboard sbIniciarFuria;
        Storyboard sbSimularAtaque;

        public bool IsVisibleFalse = false;
        public bool IsVisibleTrue = true;

        bool bajoVida = false;
        bool tieneFuerza = false;
        bool cansado = false;

        public ucAzumarill()
        {
            this.InitializeComponent();
            Storyboard auxCurar = (Storyboard)this.Resources["sbCurar"];
            Storyboard auxSaltar = (Storyboard)this.Resources["sbSaltar"];
            Storyboard auxMovimiento = (Storyboard)this.Resources["sbMovimiento"];
            Storyboard auxMoverBrazos = (Storyboard)this.Resources["sbMoverBrazos"];
            Storyboard auxMoverOrejaIzq = (Storyboard)this.Resources["sbMoverOrejaIzq"];
            Storyboard auxMoverCola = (Storyboard)this.Resources["sbMoverCola"];
            Storyboard auxCurarEscudo = (Storyboard)this.Resources["sbCurarEscudo"];
            Storyboard auxMovBrazosLento = (Storyboard)this.Resources["sbMovBrazosLento"];
            Storyboard auxMovColaLento = (Storyboard)this.Resources["sbMovColaLento"];
            Storyboard auxMovLento = (Storyboard)this.Resources["sbMovLento"];
            Storyboard auxMovOrejaIzqLento = (Storyboard)this.Resources["sbMovOrejaIzqLento"];
            Storyboard auxFlashingVida = (Storyboard)this.Resources["sbFlashingVida"];
            Storyboard auxDerrotado = (Storyboard)this.Resources["sbDerrotado"];
            Storyboard auxRBurbuja = (Storyboard)this.Resources["sbRayoBurbuja"];
            Storyboard auxRBurbujaF = (Storyboard)this.Resources["sbRayoBurbujaFuerza"];
            Storyboard auxFuria = (Storyboard)this.Resources["sbFuria"];
            Storyboard auxIFuria = (Storyboard)this.Resources["sbIniciarFuria"];
            Storyboard auxSimularAt = (Storyboard)this.Resources["sbSimularAtaque"];

            this.sbCurar = auxCurar;
            this.sbSaltar = auxSaltar;
            this.sbMovimiento = auxMovimiento;
            this.sbMoverBrazos = auxMoverBrazos;
            this.sbMoverOrejaIzq = auxMoverOrejaIzq;
            this.sbMoverCola = auxMoverCola;
            this.sbCurarEscudo = auxCurarEscudo;
            this.sbMovBrazosLento = auxMovBrazosLento;
            this.sbMovColaLento = auxMovColaLento;
            this.sbMovLento = auxMovLento;
            this.sbMovOrejaIzqLento = auxMovOrejaIzqLento;
            this.sbflashingVida = auxFlashingVida;
            this.sbDerrotado = auxDerrotado;
            this.sbRayoBurbuja = auxRBurbuja;
            this.sbRayoBurbujaFuerza = auxRBurbujaF;
            this.sbFuria = auxFuria;
            this.sbIniciarFuria = auxIFuria;
            this.sbSimularAtaque = auxSimularAt;

            startSaltar();
            reir();
        }
        private void startFlashingVida()
        {
            this.sbflashingVida.Begin();
        }

        private void stopFlashingVida()
        {
            this.sbflashingVida.Stop();
        }


        private void startCurar()
        {
            this.sbCurar.Begin();
        }


        private void stopCurar()
        {
            this.sbCurar.Stop();
        }

        private void startCurarEscudo()
        {
            this.sbCurarEscudo.Begin();
        }


        private void stopCurarEscudo()
        {
            this.sbCurarEscudo.Stop();
        }

        private void startSaltar()
        {
            this.sbSaltar.Begin();
        }

        private void stopSaltar()
        {
            this.sbSaltar.Stop();
        }

        private void startMovimiento()
        {
            this.sbMovimiento.Begin();
        }

        private void stopMovimiento()
        {
            this.sbMovimiento.Stop();
        }

        private void startMoverBrazos()
        {
            this.sbMoverBrazos.Begin();
        }

        private void stopMoverBrazos()
        {
            this.sbMoverBrazos.Stop();
        }

        private void startMoverOrejaIzq()
        {
            this.sbMoverOrejaIzq.Begin();
        }

        private void stopMoverOrejaIzq()
        {
            this.sbMoverOrejaIzq.Stop();
        }

        private void startMoverCola()
        {
            this.sbMoverCola.Begin();
        }

        private void endMoverCola()
        {
            this.sbMoverCola.Stop();
        }

        private void startRayoBurbuja()
        {
            this.sbRayoBurbuja.Begin();
        }

        private void startRayoBurbujaFuerza()
        {
            this.sbRayoBurbujaFuerza.Begin();
        }

        private void startFuria()
        {
            this.sbFuria.Begin();
        }

        private void startIniciarFuria()
        {
            this.sbIniciarFuria.Begin();
        }

        private void startSimularAt()
        {
            this.sbSimularAtaque.Begin();
        }

        private void reir()
        {
            DoubleAnimation reirBoca = new DoubleAnimation();
            reirBoca.From = gBoca.Height;
            reirBoca.To = 20;
            reirBoca.AutoReverse = true;
            reirBoca.Duration = new Duration(TimeSpan.FromSeconds(1));
            reirBoca.RepeatBehavior = RepeatBehavior.Forever;

            Storyboard sb2 = new Storyboard();
            Storyboard.SetTargetProperty(reirBoca, "Height");
            Storyboard.SetTarget(reirBoca, this.gBoca);
            sb2.Begin();
        }


        private void sbSaltar_Completed(object sender, object e)
        {
            startMovimiento();
            startMoverBrazos();
            startMoverOrejaIzq();
            startMoverCola();
        }

        private void startSlowMo()
        {
            this.sbMovBrazosLento.Begin();
            this.sbMovColaLento.Begin();
            this.sbMovLento.Begin();
            this.sbMovOrejaIzqLento.Begin();
        }

        private void stopSlowMo()
        {
            this.sbMovBrazosLento.Stop();
            this.sbMovColaLento.Stop();
            this.sbMovLento.Stop();
            this.sbMovOrejaIzqLento.Stop();
        }

        private void startMovNormal()
        {
            this.sbMoverBrazos.Begin();
            this.sbMoverCola.Begin();
            this.sbMovimiento.Begin();
            this.sbMoverOrejaIzq.Begin();
        }

        private void stopMovNormal()
        {
            this.sbMoverBrazos.Stop();
            this.sbMoverCola.Stop();
            this.sbMovimiento.Stop();
            this.sbMoverOrejaIzq.Stop();
        }

        private async void startDerrotado()
        {
            this.sbDerrotado.Begin();
            var messageDialog = new MessageDialog("Azumarill ha sido derrotado! ¿Deseas salir?", "Derrotado");
            messageDialog.Commands.Add(new UICommand("Sí", new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand("No"));
            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;

            await messageDialog.ShowAsync();

        }

        private void CommandInvokedHandler(IUICommand command)
        {
            if (command.Label.Equals("Sí")){
                Application.Current.Exit();
            }
        }


        private void rayoBurbuja_Click(object sender, RoutedEventArgs e)
        {
            if (tieneFuerza)
                startRayoBurbujaFuerza();
            else
                startRayoBurbuja();
        }

        private void btnFuria_Click(object sender, RoutedEventArgs e)
        {
            this.tieneFuerza = true;
            startIniciarFuria();
        }


        private void sbIniciarFuria_Completed(object sender, object e)
        {
            startFuria();
        }


        private void btnSimularAt_Click(object sender, RoutedEventArgs e)
        {
            startSimularAt();
        }

        private SolidColorBrush GetSolidColorBrush(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            byte a = (byte)(Convert.ToUInt32(hex.Substring(0, 2), 16));
            byte r = (byte)(Convert.ToUInt32(hex.Substring(2, 2), 16));
            byte g = (byte)(Convert.ToUInt32(hex.Substring(4, 2), 16));
            byte b = (byte)(Convert.ToUInt32(hex.Substring(6, 2), 16));
            SolidColorBrush myBrush = new SolidColorBrush(Windows.UI.Color.FromArgb(a, r, g, b));
            return myBrush;
        }

        public bool TieneFuerza
        {
            get { return tieneFuerza; }
            set { tieneFuerza = value; }
        }

        public bool Cansado
        {
            get { return cansado; }
            set { cansado = value; }
        }

    }
}
