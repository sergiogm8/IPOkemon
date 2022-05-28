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
    public sealed partial class ucArticunoCapturar : UserControl
    {
        public ucArticunoCapturar()
        {
            this.InitializeComponent();
            Storyboard sbVolar = (Storyboard)this.Resources["Volar"];
            sbVolar.Begin();
        }
    

        private void imgPokeball_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            sbCapturar.Begin();
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

    }
}
