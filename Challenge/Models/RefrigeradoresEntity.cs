using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Models
{
    public class RefrigeradoresEntity
    {
        public int Id { get; set; }
        public string Temperatura { get; set; }
        public string EspacioInterno { get; set; }
        public string ConsumoInterno { get; set; }
        public string EstadoLuces { get; set; }
    }
}
