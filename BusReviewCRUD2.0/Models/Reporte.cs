using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReviewCRUD2._0.Models
{
    class Reporte
    {
        public int ReporteId { get; set; }
        public string Usuario { get; set; }
        public string Placa { get; set; }
        public bool Mala_Conduccion { get; set; }
        public bool Acoso { get; set; }
        public string Nota { get; set; }
    }
}
