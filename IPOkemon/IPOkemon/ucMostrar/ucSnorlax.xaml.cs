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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace IPOkemon
{
    public sealed partial class ucSnorlax : UserControl
    {
        DispatcherTimer dtReloj;

        public ucSnorlax()
        {
            this.InitializeComponent();
            saludar();
        }

        private void eventoMoverse(object sender, object e)
        {
            Movimiento.Begin();
        }

        private void saludar()
        {
            Saludar.Begin();
        }

        private void derrotado()
        {
            noLive.Begin();
        }

        private void pEscudo_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (this.pbEscudo.Value < 100)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += rellenarEscudo;
                dtReloj.Start();
            }
        }

        private void rellenarEscudo(object sender, object e)
        {
            this.pbEscudo.Value += 1;
            if (this.pbEscudo.Value >= 100)
            {
                dtReloj.Stop();
            }
        }

        private void imgPocion_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (this.pbVida.Value < 100)
            {
                dtReloj = new DispatcherTimer();
                dtReloj.Interval = TimeSpan.FromMilliseconds(100);
                dtReloj.Tick += rellenarVida;
                dtReloj.Start();
            }
        }

        private void rellenarVida(object sender, object e)
        {
            this.pbVida.Value += 1;
            if (this.pbVida.Value >= 100)
            {
                dtReloj.Stop();
            }

        }

        private void piedraUsable_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Hit.Begin();
            if (this.pbEscudo.Value > 0)
            {
                this.pbEscudo.Value -= 50;
            }
            else
            {
                this.pbVida.Value -= 25;
                verSiDerrotado(this.pbVida.Value);
            }
        }

        private void verSiDerrotado(double valor)
        {
            if (valor <= 0)
            {
                derrotado();
            }
        }
    }
}
