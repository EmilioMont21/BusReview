using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD2._0.Models
{
    class Parada
    {
        public int ParadaId { get; set; }
        public string Nombre { get; set; }
        public string Sector { get; set; }
        public string Callep { get; set; }
        public string Calles { get; set; }
        public decimal? Costo { get; set; }
    }
}
