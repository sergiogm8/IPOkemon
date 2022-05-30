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
    public sealed partial class ucEntrenar : UserControl
    {
        public ucEntrenar(Pokemon pokemon)
        {
            this.InitializeComponent();
            DataContext = pokemon;
            txtNivel.Text = "Lv. " + pokemon.nivel.ToString();
            txtExpRestante.Text = (100.0 - pokemon.exp).ToString() + " XP restante";
        }

    }
}
