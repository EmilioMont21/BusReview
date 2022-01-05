using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD2._0.Models
{
    class Resena
    {
        public int ResenaId { get; set; }
        public string Usuario { get; set; }
        public string Placa { get; set; }
        public int? Calificacion { get; set; }
        public string Nota { get; set; }
    }
}
