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
    public sealed partial class Usuarios : Page
    {
        public Usuarios()
        {
            this.InitializeComponent();
        }

        private async void SaveUsuarios(Usuario usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            HttpClient httpClient = new HttpClient();
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            await httpClient.PostAsync("https://localhost:44380/api/usuarios", content);
        }

        private async void UpdateUsuarios(Usuario usuario)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"https://localhost:44380/api/usuarios/{usuario.UsuarioId}", content);
        }
        private async void DeleteUsuarios(Usuario usuario)
        {
            var httpHandler = new HttpClientHandler();
            var client = new HttpClient(httpHandler);
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            await client.DeleteAsync($"https://localhost:44380/api/usuarios/{usuario.UsuarioId}");
        }
        private void GuardarUsuario_Click(object sender, RoutedEventArgs e)
        {
            var usuario = new Usuario()
            {
                UsuarioId = Convert.ToInt32(txtId.Text),
                Nombre = txtName.Text,
                Apellido = txtApellido.Text,
                Correo = txtCorreo.Text,
                Contrasena = txtContrasenia.Text,
                Fecha_Nacimiento = dpFecha.Date.DateTime,
                Administrador = cbAdmin.IsEnabled.Equals(true)

            };

            if (usuario.UsuarioId == 0)
            {
                SaveUsuarios(usuario);
            }
            else
            {
                UpdateUsuarios(usuario);
            }
            txtId.Text = 0.ToString();
            txtName.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            dpFecha.SelectedDate = default;
            txtContrasenia.Text = "";
            cbAdmin.IsChecked = default;
        }

        private async void CargarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            var httpHandler = new HttpClientHandler();
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://localhost:44380/api/usuarios");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            var client = new HttpClient(httpHandler);

            HttpResponseMessage response = await client.SendAsync(request);

            string content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Usuario>>(content);
            Lista.ItemsSource = resultado;
        }

        private void Usuario_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Usuario usuario = ((FrameworkElement)sender).DataContext as Usuario;
            txtId.Text = usuario.UsuarioId.ToString();
            txtName.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtCorreo.Text = usuario.Correo;
            dpFecha.SelectedDate = usuario.Fecha_Nacimiento;
            txtContrasenia.Text = usuario.Contrasena;
            cbAdmin.IsChecked = usuario.Administrador;
        }

        private void EliminarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = (Usuario)Lista.SelectedItem;
            DeleteUsuarios(usuario);
            txtId.Text = 0.ToString();
            txtName.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            dpFecha.SelectedDate = default;
            txtContrasenia.Text = "";
            cbAdmin.IsChecked = default;
        }

        private void NuevoUsuario_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = 0.ToString();
            txtName.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            dpFecha.SelectedDate = default;
            txtContrasenia.Text = "";
            cbAdmin.IsChecked = default;
        }
    }
}
