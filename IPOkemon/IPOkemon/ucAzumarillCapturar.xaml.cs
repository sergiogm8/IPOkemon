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
using Windows.ApplicationModel.DataTransfer;
using IPOkemon;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemon
{
    public sealed partial class ucAzumarillCapturar : UserControl
    {

        Storyboard sbSaltar;
        Storyboard sbMovimiento;
        Storyboard sbMoverBrazos;
        Storyboard sbMoverOrejaIzq;
        Storyboard sbMoverCola;
        Storyboard sbMovBrazosLento;
        Storyboard sbMovColaLento;
        Storyboard sbMovLento;
        Storyboard sbMovOrejaIzqLento;


        public ucAzumarillCapturar()
        {
            this.InitializeComponent();
            Storyboard auxSaltar = (Storyboard)this.Resources["sbSaltar"];
            Storyboard auxMovimiento = (Storyboard)this.Resources["sbMovimiento"];
            Storyboard auxMoverBrazos = (Storyboard)this.Resources["sbMoverBrazos"];
            Storyboard auxMoverOrejaIzq = (Storyboard)this.Resources["sbMoverOrejaIzq"];
            Storyboard auxMoverCola = (Storyboard)this.Resources["sbMoverCola"];
            Storyboard auxMovBrazosLento = (Storyboard)this.Resources["sbMovBrazosLento"];
            Storyboard auxMovColaLento = (Storyboard)this.Resources["sbMovColaLento"];
            Storyboard auxMovLento = (Storyboard)this.Resources["sbMovLento"];
            Storyboard auxMovOrejaIzqLento = (Storyboard)this.Resources["sbMovOrejaIzqLento"];

            this.sbSaltar = auxSaltar;
            this.sbMovimiento = auxMovimiento;
            this.sbMoverBrazos = auxMoverBrazos;
            this.sbMoverOrejaIzq = auxMoverOrejaIzq;
            this.sbMoverCola = auxMoverCola;
            this.sbMovBrazosLento = auxMovBrazosLento;
            this.sbMovColaLento = auxMovColaLento;
            this.sbMovLento = auxMovLento;
            this.sbMovOrejaIzqLento = auxMovOrejaIzqLento;

            startSaltar();
            reir();
        }

        private void startCapturar()
        {
            this.sbCapturar.Begin();
        }

        private void endCapturar()
        {
            this.sbCapturar.Stop();
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

        private void sbCapturar_Completed(object sender, object e)
        {
            Grid parentGrid = (Grid)this.Parent;
            CapturarPage paginaPadre = (CapturarPage)parentGrid.Parent;
            paginaPadre.comprobarCapturado();
        }

        public void volverACapturar()
        {
            sbRestaurar.Begin();   
        }

        private void imgPokeball_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            startCapturar();
        }
    }
}
