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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemon
{
    public sealed partial class ucAipomCapturar : UserControl
    {

        public ucAipomCapturar()
        {
            this.InitializeComponent();

            Storyboard sbMoverCola = (Storyboard)this.Resources["sbMoverCola"];
            sbMoverCola.Begin();

        }


        /***************************************************
         * METODO: OJOS CANSADOS
         **************************************************/
        void ojosCansado()
        {
            OjoDer.Visibility = Visibility.Collapsed;
            OjoIzq.Visibility = Visibility.Collapsed;
            OjoDerCansado.Visibility = Visibility.Visible;
            OjoIzqCansado.Visibility = Visibility.Visible;
        }


        /***************************************************
         * METODO: OJOS ACTIVOS
         **************************************************/
        void ojosActivo()
        {
            OjoDer.Visibility = Visibility.Visible;
            OjoIzq.Visibility = Visibility.Visible;
            OjoDerCansado.Visibility = Visibility.Collapsed;
            OjoIzqCansado.Visibility = Visibility.Collapsed;
        }


        /***************************************************
         * METODO: MOVER COLA
         **************************************************/
        void eventoMoverCola()
        {
            Storyboard sbMoverCola = (Storyboard)this.Resources["sbMoverCola"];
            sbMoverCola.Begin();

        }


        /***************************************************
         * METODO: REIR
         **************************************************/
        void reir()
        {
            reirBoca.Begin();
        }


        /***************************************************
         * METODO: FIN DEL MOVIMIENTO
         * Termina una de las acciones especiales y 
         * el movimiento de la cola
         **************************************************/
        void finMovimiento(object sender, object e)
        {
            eventoMoverCola();
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
            sbCapturar.Begin();
        }

    }
}
