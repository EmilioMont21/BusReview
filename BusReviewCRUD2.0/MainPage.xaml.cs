using BusReviewCRUD2._0.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace BusReviewCRUD2._0
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            RPMenu.Background = new SolidColorBrush(Colors.Gray);

        }

        private void RPMenu_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            RPMenu.Background = new SolidColorBrush(Colors.Gray);
        }
        private void RPMenu_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            RPMenu.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void RPBuses_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            RPBuses.Background = new SolidColorBrush(Colors.Gray);
        }

        private void RPBuses_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            RPBuses.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void RPParadas_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            RPParadas.Background = new SolidColorBrush(Colors.Gray);
        }

        private void RPParadas_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            RPParadas.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void RPReportes_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            RPReportes.Background = new SolidColorBrush(Colors.Gray);
        }

        private void RPReportes_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            RPReportes.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void RPResenas_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            RPResenas.Background = new SolidColorBrush(Colors.Gray);
        }

        private void RPResenas_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            RPResenas.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void RPUsuario_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            RPUsuario.Background = new SolidColorBrush(Colors.Gray);
        }

        private void RPUsuario_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            RPUsuario.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void RPMenu_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RemoveBk();
            RPMenu.Background = new SolidColorBrush(Colors.DarkGray);
            MyFrame.Navigate(typeof(Menu));
        }

        private void RPBuses_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RemoveBk();
            RPBuses.Background = new SolidColorBrush(Colors.DarkGray);
            MyFrame.Navigate(typeof(Buses));
        }

        private void RPParadas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RemoveBk();
            RPParadas.Background = new SolidColorBrush(Colors.DarkGray);
            MyFrame.Navigate(typeof(Paradas));
        }

        private void RPReportes_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RemoveBk();
            RPReportes.Background = new SolidColorBrush(Colors.DarkGray);
            MyFrame.Navigate(typeof(Reportes));
        }

        private void RPResenas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RemoveBk();
            RPResenas.Background = new SolidColorBrush(Colors.DarkGray);
            MyFrame.Navigate(typeof(Resenas));
        }

        private void RPUsuario_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            RemoveBk();
            RPUsuario.Background = new SolidColorBrush(Colors.DarkGray);
            MyFrame.Navigate(typeof(Usuarios));
        }

        public void RemoveBk()
        {
            RPMenu.Background = null;
            RPBuses.Background = null;
            RPParadas.Background = null;
            RPReportes.Background = null;
            RPResenas.Background = null;
            RPUsuario.Background = null;
        }
    }
}
