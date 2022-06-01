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
    public sealed partial class ucArticuno : UserControl
    {
        public ucArticuno()
        {
            this.InitializeComponent();
        }

        public double MyVida
        {
            get { return pbVida.Value; }
            set { pbVida.Value = value; }
        }

        public double MyEscudo
        {
            get { return pbEscudo.Value; }
            set { pbEscudo.Value = value; }
        }


        private void usarPocion(object sender, PointerRoutedEventArgs e)
        {
            if (pbVida.Value != 100)
            {
                Storyboard sbUsarPocion = (Storyboard)this.Resources["UsarPocion"];
                sbUsarPocion.Begin();
                imPocion.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Debilitar(object sender, RoutedEventArgs e)
        {
            if (pbEscudo.Value == 100)
            {
                Storyboard sbPerderEscudo = (Storyboard)this.Resources["PerderEscudo"];
                sbPerderEscudo.Begin();
            }
            else if (pbVida.Value > 10)
            {
                Storyboard sbPerderVida10 = (Storyboard)this.Resources["PerderVida10"];
                sbPerderVida10.Begin();
            }
            else
            {
                Storyboard sbDerrotado = (Storyboard)this.Resources["Derrotado"];
                sbDerrotado.Begin();
            }
        }

        private void Button_Mover(object sender, RoutedEventArgs e)
        {
            Storyboard sbVolar = (Storyboard)this.Resources["Volar"];
            sbVolar.Begin();
        }

        private void Button_Incrementar(object sender, RoutedEventArgs e)
        {
            Storyboard sbIncrementar = (Storyboard)this.Resources["IncrementarPotencia"];
            sbIncrementar.Begin();
        }

        private void Button_Atacar(object sender, RoutedEventArgs e)
        {
            Storyboard sbAtacar = (Storyboard)this.Resources["AtaqueRayoHielo"];
            sbAtacar.Begin();
        }
    }
}
