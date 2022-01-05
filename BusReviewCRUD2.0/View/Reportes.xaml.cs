using BusReviewCRUD2._0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace BusReviewCRUD2._0.View
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Reportes : Page
    {
        public Reportes()
        {
            this.InitializeComponent();
        }

        private async void SaveReportes(Reporte reporte)
        {
            var json = JsonConvert.SerializeObject(reporte);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            await httpClient.PostAsync("https://localhost:44380/api/reportes", content);
        }

        private async void UpdateReportes(Reporte reporte)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(reporte);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"https://localhost:44380/api/reportes/{reporte.ReporteId}", content);
        }
        private async void DeleteReportes(Reporte reporte)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(reporte);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await client.DeleteAsync($"https://localhost:44380/api/reportes/{reporte.ReporteId}");
        }
        private void GuardarReporte_Click(object sender, RoutedEventArgs e)
        {
            var reporte = new Reporte()
            {
                ReporteId = Convert.ToInt32(txtId.Text),
                Usuario = txtUsuario.Text,
                Placa = txtPlaca.Text,
                Acoso = cbAcoso.IsEnabled.Equals(true),
                Mala_Conduccion = cbMalaCon.IsEnabled.Equals(true),
                Nota = txtNota.Text

            };

            if (reporte.ReporteId == 0)
            {
                SaveReportes(reporte);
            }
            else
            {
                UpdateReportes(reporte);
            }
            txtId.Text = 0.ToString();
            txtUsuario.Text = "";
            txtPlaca.Text = "";
            cbAcoso.IsChecked = default;
            cbMalaCon.IsChecked = default;
            txtNota.Text = "";


        }

        private async void CargarReportes_Click(object sender, RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44380/api/reportes");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Reporte>>(content);
            Lista.ItemsSource = resultado;
        }

        private void Reporte_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Reporte reporte = ((FrameworkElement)sender).DataContext as Reporte;
            txtId.Text = reporte.ReporteId.ToString();
            txtUsuario.Text = reporte.Usuario;
            txtPlaca.Text = reporte.Placa;
            cbAcoso.IsChecked = reporte.Acoso;
            cbMalaCon.IsChecked = reporte.Mala_Conduccion;
            txtNota.Text = reporte.Nota;

        }

        private void EliminarReporte_Click(object sender, RoutedEventArgs e)
        {
            Reporte reporte = (Reporte)Lista.SelectedItem;
            DeleteReportes(reporte);
            txtId.Text = 0.ToString();
            txtUsuario.Text = "";
            txtPlaca.Text = "";
            cbAcoso.IsChecked = default;
            cbMalaCon.IsChecked = default;
            txtNota.Text = "";
        }

        private void NuevoReporte_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = 0.ToString();
            txtUsuario.Text = "";
            txtPlaca.Text = "";
            cbAcoso.IsChecked = default;
            cbMalaCon.IsChecked = default;
            txtNota.Text = "";
        }
    }
}
