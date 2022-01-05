using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD2._0.Models
{
    class Bus
    {
        public int BusId { get; set; }
        public string Placa { get; set; }
        public string Nombres_Chofer { get; set; }
        public string Nombres_Asistente { get; set; }
        public string Cedula_Chofer { get; set; }
        public string Cedula_Asistente { get; set; }
        public string Marca { get; set; }
        public string Sector { get; set; }
        public string Cooperativa { get; set; }
        public bool Wifi { get; set; }
        public bool TV { get; set; }
        public bool Baño { get; set; }
        public bool Asientos_discapacitados { get; set; }
    }
}
