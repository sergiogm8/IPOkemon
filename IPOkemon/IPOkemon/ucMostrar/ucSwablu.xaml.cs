using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class ucSwablu : UserControl
    {
        DispatcherTimer dt1;
        Storyboard volar;
        Storyboard comer;
        Storyboard shiny;
        Storyboard atacado;
        Storyboard ataque;
        Storyboard sinEnergia;
        Storyboard sinVida;

        public ucSwablu()
        {
            this.InitializeComponent();

            //Activar componentes
            this.imgPocima.IsHitTestVisible = true;
            this.imgComida.IsHitTestVisible = true;
            this.imgAtaque.IsHitTestVisible = true;
            this.imgShiny.IsHitTestVisible = true;
            this.Swablu.IsHitTestVisible = true;

            //Asociar los storyboards
            this.volar = (Storyboard)this.Resources["volar"];
            this.comer = (Storyboard)this.Resources["comer"];
            this.shiny = (Storyboard)this.Resources["shiny"];
            this.atacado = (Storyboard)this.Resources["atacado"];
            this.ataque = (Storyboard)this.Resources["ataque"];
            this.sinEnergia = (Storyboard)this.Resources["sinEnergia"];
            this.sinVida = (Storyboard)this.Resources["sinVida"];

            //Comenzar reloj
            this.volar.Begin();
            dt1 = new DispatcherTimer();
            dt1.Interval = TimeSpan.FromSeconds(2);
            dt1.Tick += reloj;
            dt1.Start();
        }

        void reloj(object sender, object e)
        {
            if (this.pbVida.Value == 0)
            {
                finAsync();
            }
            else
            {
                if (pbComida.Value != 0)
                {
                    this.pbComida.Value -= 2;
                }

                this.pbVida.Value -= 2;

                if (this.pbVida.Value <= 30)
                {
                    energiaBaja();
                }
                else
                {
                    this.sinEnergia.Stop();
                }

                if (this.pbFuerza.Value != 0)
                {
                    this.pbFuerza.Value -= 2;
                }
                else if (this.pbFuerza.Value == 0 || this.pbComida.Value == 0)
                {
                    this.pbVida.Value -= 5;
                }
            }
        }

        //RECARGAR VIDA Y FUERZA
        private void imgPocima_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.pbVida.Value += 10;
            this.pbFuerza.Value += 10;
        }

        //COMER
        private void imgComida_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.comer.Completed += finComer;

            this.comer.Stop();
            this.volar.Stop();
            this.atacado.Stop();
            this.ataque.Stop();
            this.comer.Begin();

            this.pbComida.Value += 10;
        }

        private void finComer(object sender, object e)
        {
            this.comer.Stop();
            this.volar.Stop();
            this.atacado.Stop();
            this.ataque.Stop();
            this.volar.Begin();
        }

        //SHINY
        private async void imgShiny_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (this.pbVida.Value >= 50 && this.pbFuerza.Value >= 50)
            {
                this.shiny.Stop();
                this.comer.Stop();
                this.atacado.Stop();
                this.ataque.Stop();
                this.shiny.Begin();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("No tengo suficiente energía", "ENERGIA BAJA");
                await dialog.ShowAsync();
            }
        }

        //ATACADO
        private void Swablu_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.atacado.Completed += finAtacado;

            this.volar.Stop();
            this.comer.Stop();
            this.shiny.Stop();
            this.ataque.Stop();
            this.atacado.Begin();
        }

        private void finAtacado(object sender, object e)
        {
            this.volar.Begin();
            this.pbFuerza.Value -= 5;
        }

        //ATACAR
        private void imgAtaque_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            this.ataque.Completed += finAtaque;

            this.ataque.Stop();
            this.volar.Stop();
            this.comer.Stop();
            this.atacado.Stop();
            this.ataque.Begin();
        }

        private void finAtaque(object sender, object e)
        {
            this.volar.Begin();
        }

        //QUEDA POCA VIDA
        private void energiaBaja()
        {
            this.comer.Completed += finPocaEnergia;

            this.volar.Stop();
            this.comer.Stop();
            this.shiny.Stop();
            this.atacado.Stop();
            this.ataque.Stop();

            this.sinEnergia.Begin();
        }

        private void finPocaEnergia(object sender, object e)
        {
            this.volar.Begin();
        }

        // SIN VIDA
        private async Task finAsync()
        {
            dt1.Stop();

            this.volar.Stop();
            this.comer.Stop();
            this.shiny.Stop();
            this.atacado.Stop();
            this.ataque.Stop();
            this.sinEnergia.Stop();

            this.sinVida.Begin();

            this.imgPocima.IsHitTestVisible = false;
            this.imgComida.IsHitTestVisible = false;
            this.imgAtaque.IsHitTestVisible = false;
            this.imgShiny.IsHitTestVisible = false;
            this.Swablu.IsHitTestVisible = false;

            MessageDialog dialog = new MessageDialog("Me he quedado sin vida :(", "FIN");
            await dialog.ShowAsync();
        }
    }
}
