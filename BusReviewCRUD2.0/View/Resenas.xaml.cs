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
    public sealed partial class Resenas : Page
    {
        public Resenas()
        {
            this.InitializeComponent();
        }

        private async void SaveResenas(Resena resena)
        {
            var json = JsonConvert.SerializeObject(resena);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            await httpClient.PostAsync("https://localhost:44380/api/resenas", content);
        }

        private async void UpdateResenas(Resena resena)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(resena);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"https://localhost:44380/api/resenas/{resena.ResenaId}", content);
        }
        private async void DeleteResenas(Resena resena)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(resena);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await client.DeleteAsync($"https://localhost:44380/api/resenas/{resena.ResenaId}");
        }
        private void GuardarResena_Click(object sender, RoutedEventArgs e)
        {
            var resena = new Resena()
            {
                ResenaId = Convert.ToInt32(txtId.Text),
                Usuario = txtUsuario.Text,
                Placa = txtPlaca.Text,
                Calificacion = Convert.ToInt32(txtCalificacion.Text),
                Nota = txtNota.Text,

            };

            if (resena.ResenaId == 0)
            {
                SaveResenas(resena);
            }
            else
            {
                UpdateResenas(resena);
            }
            txtId.Text = 0.ToString();
            txtUsuario.Text = "";
            txtPlaca.Text = "";
            txtNota.Text = "";
            txtCalificacion.Text = "";

        }

        private async void CargarResenas_Click(object sender, RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44380/api/resenas");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Resena>>(content);
            Lista.ItemsSource = resultado;
        }

        private void Resena_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Resena resena = ((FrameworkElement)sender).DataContext as Resena;
            txtId.Text = resena.ResenaId.ToString();
            txtUsuario.Text = resena.Usuario;
            txtPlaca.Text = resena.Placa;
            txtCalificacion.Text = resena.Calificacion.ToString();
            txtNota.Text = resena.Nota.ToString();

        }

        private void EliminarResena_Click(object sender, RoutedEventArgs e)
        {
            Resena resena = (Resena)Lista.SelectedItem;
            DeleteResenas(resena);
            txtId.Text = 0.ToString();
            txtUsuario.Text = "";
            txtPlaca.Text = "";
            txtCalificacion.Text = 0.ToString();
            txtNota.Text = "";

        }

        private void NuevaResena_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = 0.ToString();
            txtUsuario.Text = "";
            txtPlaca.Text = "";
            txtCalificacion.Text = 0.ToString();
            txtNota.Text = "";

        }
    }
}

