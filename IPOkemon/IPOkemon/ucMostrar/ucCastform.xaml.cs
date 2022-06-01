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

    public sealed partial class ucCastform : UserControl
    {
        DispatcherTimer dtReloj;

        public ucCastform()
        {
            this.InitializeComponent();
        }



        private void btnOjos_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.pupila_der.Resources["pupilaRojaDKey"];
            sb.Begin();
            Storyboard sb1 = (Storyboard)this.pupila_izq.Resources["pupilaRojaIKey"];
            sb1.Begin();
        }

        private void btnpbVida1_Click(object sender, RoutedEventArgs e)
        {
            pbVida1.Value -= 30;
            double vida = this.pbVida1.Value;


            if (vida <= 20 && vida > 0)
            {
                cvnTirita.Visibility = Visibility.Visible;
                tirita1.Visibility = Visibility.Visible;

            }
            if (vida == 0)
            {
                cnvCruces.Visibility = Visibility.Visible;
                ojo_izq.Visibility = Visibility.Collapsed;
                Ojo_der.Visibility = Visibility.Collapsed;
                muerte();
            }

        }


        private void btnGiroCuerno_Click(object sender, RoutedEventArgs e)
        {

            Storyboard sb1 = (Storyboard)this.Resources["girarCuerno"];
            sb1.Begin();
            pbEscudo1.Value -= 10;

        }




        private void ActivaCruces(object sender, RoutedEventArgs e)
        {
            if (pbVida1.Value < 1)
            {
                ojo_izq.Visibility = Visibility.Collapsed;
                Ojo_der.Visibility = Visibility.Collapsed;
                cnvCruces.Visibility = Visibility.Visible;
            }
        }

        private void btnPocima_Click(object sender, RoutedEventArgs e)
        {
            if (pbVida1.Value < 100)
            {
                revivir();

            }
        }



        private void btnAtaque2_Click(object sender, RoutedEventArgs e)
        {
            enfado();
            dtReloj = new DispatcherTimer();
            dtReloj.Interval = TimeSpan.FromMilliseconds(7000);
            dtReloj.Tick += desenfado;
            dtReloj.Start();
            Storyboard sb = (Storyboard)this.Resources["ataqueNubes"];
            sb.Begin();
            sb.RepeatBehavior = new RepeatBehavior(1);
        }
        private void enfado()
        {
            gbNubes.Visibility = Visibility.Visible;
            gbRayos.Visibility = Visibility.Visible;
            cejas.Visibility = Visibility.Visible;
            bocaSad.Visibility = Visibility.Visible;
            boca.Visibility = Visibility.Collapsed;
        }

        private void desenfado(object sender, object e)
        {
            gbNubes.Visibility = Visibility.Collapsed;
            gbRayos.Visibility = Visibility.Collapsed;
            cejas.Visibility = Visibility.Collapsed;
            bocaSad.Visibility = Visibility.Collapsed;
            boca.Visibility = Visibility.Visible;
        }



        private void btnStory_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["vuelo"];
            sb.Begin();
        }



        private void muerte()
        {
            RotateTransform rotateTransform2 = new RotateTransform();
            rotateTransform2.Angle = 90;
            rotateTransform2.CenterX = 25;
            rotateTransform2.CenterY = 50;
            cnvPokemon.RenderTransform = rotateTransform2;
        }

        private void revivir()
        {
            RotateTransform rotateTransform2 = new RotateTransform();
            rotateTransform2.Angle = 0;
            rotateTransform2.CenterX = 25;
            rotateTransform2.CenterY = 50;
            cnvPokemon.RenderTransform = rotateTransform2;

            pbVida1.Value += 100 - pbVida1.Value;
            ojo_izq.Visibility = Visibility.Visible;
            Ojo_der.Visibility = Visibility.Visible;
            cnvCruces.Visibility = Visibility.Collapsed;
            cvnTirita.Visibility = Visibility.Collapsed;
        }

        private void btnpbVida1_Click_1(object sender, RoutedEventArgs e)
        {
            pbVida1.Value -= 30;
            double vida = this.pbVida1.Value;


            if (vida <= 20 && vida > 0)
            {
                cvnTirita.Visibility = Visibility.Visible;
                tirita1.Visibility = Visibility.Visible;

            }
            if (vida == 0)
            {
                cnvCruces.Visibility = Visibility.Visible;
                ojo_izq.Visibility = Visibility.Collapsed;
                Ojo_der.Visibility = Visibility.Collapsed;
                muerte();
            }
        }
    }
}

