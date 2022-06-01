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
    public sealed partial class ucAipom : UserControl
    {
        DispatcherTimer dtReloj;
        private DispatcherTimer dtRelojBajar;

        public ucAipom()
        {
            this.InitializeComponent();

            
            Storyboard sbMoverCola = (Storyboard)this.Resources["sbMoverCola"];
            sbMoverCola.Begin();

            bajarVida();
        }


        /***************************************************
         * METODO: SUBIR VIDA
         * Sube la barra de la vida del pokemon
         **************************************************/
        void subirVida(object sender, object e)
        {
            pbVida.Value += 0.2;

            if (pbVida.Value == 100)
            {
                dtReloj.Stop();
                imgPocima.Visibility = Visibility.Collapsed;
            }
        }


        /***************************************************
         * METODO: USAR POCIMA
         **************************************************/
        void usarPocima(object sender, object e)
        {
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(100);
            dtReloj.Tick += subirVida;
            dtReloj.Start();
            dtRelojBajar.Stop();
            imgPocima.Opacity = 0.5;

            pbVida.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            reir();
            ojosActivo();

        }


        /***************************************************
         * METODO: BAJAR VIDA
         * Lanza un reloj para reducir la barra de vida
         **************************************************/
        void bajarVida()
        {
            dtRelojBajar = new DispatcherTimer();
            dtRelojBajar.Interval = TimeSpan.FromMilliseconds(100);
            dtRelojBajar.Tick += reducirBarra;
            dtRelojBajar.Start();

            imgPocima.Visibility = Visibility.Visible;
        }


        /***************************************************
         * METODO: REDUCIR BARRA DE LA VIDA
         * Si la barra esta por debajo de 25, se pone 
         * de color rojo. Ademas el pokemon pondra 
         * los ojos cansados
         **************************************************/
        void reducirBarra(object sender, object e)
        {
            pbVida.Value -= 0.1;

            if (pbVida.Value == 0)
            {
                dtRelojBajar.Stop();
            }
            if (pbVida.Value < 25)
            {
                pbVida.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                ojosCansado();
            }

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


        /***************************************************
         * METODO: SALTAR
         **************************************************/
        private void imgSalto_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbSaltar = (Storyboard)this.Resources["sbSaltar"];
            sbSaltar.Begin();
            sbSaltar.Completed += finMovimiento;
        }


        /***************************************************
         * METODO: ATACAR
         **************************************************/
        private void imgAtacar_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Storyboard sbAtacar = (Storyboard)this.Resources["sbAtacar"];
            sbAtacar.Begin();

            sbAtacar.Completed += finMovimiento;
        }


        /***************************************************
         * METODO: MyVida
         **************************************************/
        public double MyVida
        {
            get { return pbVida.Value; }
            set { pbVida.Value = value; }
        }

        
    }
}
