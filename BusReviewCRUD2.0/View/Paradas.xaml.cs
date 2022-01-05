using BusReviewCRUD2._0.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
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
    public sealed partial class Paradas : Page
    {
        public Paradas()
        {
            this.InitializeComponent();
        }

        private async void SaveParadas(Parada parada)
        {
            var json = JsonConvert.SerializeObject(parada);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            await httpClient.PostAsync("https://localhost:44380/api/paradas", content);
        }

        private async void UpdateParadas(Parada parada)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(parada);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"https://localhost:44380/api/paradas/{parada.ParadaId}", content);
        }
        private async void DeleteParadas(Parada parada)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(parada);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await client.DeleteAsync($"https://localhost:44380/api/paradas/{parada.ParadaId}");
        }
        private void GuardarParada_Click(object sender, RoutedEventArgs e)
        {
            var parada = new Parada()
            {
                ParadaId = Convert.ToInt32(txtId.Text),
                Nombre = txtNombre.Text,
                Sector = txtSector.Text,
                Callep = txtCallePrin.Text,
                Calles = txtCalleSecun.Text,
                Costo = Convert.ToDecimal(txtCosto.Text),


            };

            if (parada.ParadaId == 0)
            {
                SaveParadas(parada);
            }
            else
            {
                UpdateParadas(parada);
            }
            txtId.Text = 0.ToString();
            txtNombre.Text = "";
            txtSector.Text = "";
            txtCallePrin.Text = "";
            txtCalleSecun.Text = "";
            txtCosto.Text = 0.ToString();
        }

        private async void CargarParada_Click(object sender, RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44380/api/paradas");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Parada>>(content);
            Lista.ItemsSource = resultado;
        }

        private void Parada_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Parada parada = ((FrameworkElement)sender).DataContext as Parada;
            txtId.Text = parada.ParadaId.ToString();
            txtNombre.Text = parada.Nombre;
            txtSector.Text = parada.Sector;
            txtCallePrin.Text = parada.Callep;
            txtCalleSecun.Text = parada.Calles;
            txtCosto.Text = parada.Costo.ToString();

        }

        private void EliminarParada_Click(object sender, RoutedEventArgs e)
        {
            Parada parada = (Parada)Lista.SelectedItem;
            DeleteParadas(parada);
            txtId.Text = 0.ToString();
            txtNombre.Text = "";
            txtSector.Text = "";
            txtCallePrin.Text = "";
            txtCalleSecun.Text = "";
            txtCosto.Text = 0.ToString();
            txtId.Text = 0.ToString();

        }

        private void NuevaParada_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = 0.ToString();
            txtNombre.Text = "";
            txtSector.Text = "";
            txtCallePrin.Text = "";
            txtCalleSecun.Text = "";
            txtCosto.Text = 0.ToString();
            txtId.Text = 0.ToString();
        }
    }
}
