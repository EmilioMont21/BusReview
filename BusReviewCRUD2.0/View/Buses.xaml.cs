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
    public sealed partial class Buses : Page
    {
        public Buses()
        {
            this.InitializeComponent();
        }

        private async void SaveBus(Bus buses)
        {
            var json = JsonConvert.SerializeObject(buses);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            await httpClient.PostAsync("https://localhost:44380/api/buses", content);
        }

        private async void UpdateBus(Bus buses)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(buses);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"https://localhost:44380/api/buses/{buses.BusId}", content);
        }
        private async void DeleteBus(Bus buses)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(buses);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await client.DeleteAsync($"https://localhost:44380/api/buses/{buses.BusId}");
        }
        private async void CargarBuses_Click(object sender, RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44380/api/buses");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Bus>>(content);
            Lista.ItemsSource = resultado;
        }

        private void NuevoBus_Click(object sender, RoutedEventArgs e)
        {
            txtBusId.Text = 0.ToString();
            txtPlaca.Text = "";
            txtMarca.Text = "";
            txtNombreC.Text = "";
            txtCedulaC.Text = "";
            txtNombreA.Text = "";
            txtCedulaA.Text = "";
            txtCooperativa.Text = "";
            txtSector.Text = "";
            cbWifi.IsChecked = default;
            cbTv.IsChecked = default;
            cbBano.IsChecked = default;
            cbAsientos.IsChecked = default;
        }

        private void GuardarBus_Click(object sender, RoutedEventArgs e)
        {
            var buses = new Bus()
            {
                BusId = Convert.ToInt32(txtBusId.Text),
                Placa = txtPlaca.Text,
                Marca = txtMarca.Text,
                Nombres_Chofer = txtNombreC.Text,
                Cedula_Chofer = txtCedulaC.Text,
                Nombres_Asistente = txtNombreA.Text,
                Cedula_Asistente = txtCedulaA.Text,
                Cooperativa = txtCooperativa.Text,
                Sector = txtSector.Text,
                Wifi = cbWifi.IsEnabled.Equals(true),
                TV = cbTv.IsEnabled.Equals(true),
                Baño = cbBano.IsEnabled.Equals(true),
                Asientos_discapacitados = cbAsientos.IsEnabled.Equals(true)
            };

            if (buses.BusId == 0)
            {
                SaveBus(buses);
            }
            else
            {
                UpdateBus(buses);
            }
            txtBusId.Text = 0.ToString();
            txtPlaca.Text = "";
            txtMarca.Text = "";
            txtNombreC.Text = "";
            txtCedulaC.Text = "";
            txtNombreA.Text = "";
            txtCedulaA.Text = "";
            txtCooperativa.Text = "";
            txtSector.Text = "";
            cbWifi.IsChecked = default;
            cbTv.IsChecked = default;
            cbBano.IsChecked = default;
            cbAsientos.IsChecked = default;
        }

        private void EliminarBus_Click(object sender, RoutedEventArgs e)
        {
            Bus buses = (Bus)Lista.SelectedItem;
            DeleteBus(buses);
            txtBusId.Text = 0.ToString();
            txtPlaca.Text = "";
            txtMarca.Text = "";
            txtNombreC.Text = "";
            txtCedulaC.Text = "";
            txtNombreA.Text = "";
            txtCedulaA.Text = "";
            txtCooperativa.Text = "";
            txtSector.Text = "";
            cbWifi.IsChecked = default;
            cbTv.IsChecked = default;
            cbBano.IsChecked = default;
            cbAsientos.IsChecked = default;
        }

        private void Bus_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Bus buses = ((FrameworkElement)sender).DataContext as Bus;
            txtBusId.Text = buses.BusId.ToString();
            txtPlaca.Text = buses.Placa;
            txtMarca.Text = buses.Marca;
            txtNombreC.Text = buses.Nombres_Chofer;
            txtCedulaC.Text = buses.Cedula_Chofer;
            txtNombreA.Text = buses.Nombres_Asistente;
            txtCedulaA.Text = buses.Cedula_Asistente;
            txtCooperativa.Text = buses.Cooperativa;
            txtSector.Text = buses.Sector;
            cbWifi.IsChecked = buses.Wifi;
            cbTv.IsChecked = buses.TV;
            cbBano.IsChecked = buses.Baño;
            cbAsientos.IsChecked = buses.Asientos_discapacitados;
        }
    }
}
