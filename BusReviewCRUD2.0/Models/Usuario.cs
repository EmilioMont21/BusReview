using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD2._0.Models
{
    class Usuario
    {
        public int UsuarioId { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }
        public DateTime? Fecha_Nacimiento { get; set; }
        public bool Administrador { get; set; }
    }
}
