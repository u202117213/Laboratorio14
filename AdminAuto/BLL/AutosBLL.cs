using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminAuto.BLL
{
    internal class AutosBLL
    {
        public int ID { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo {  get; set; }
        public int Num_asientos {  get; set; }
        public int Anio { get; set; }
        public int Oficina { get; set; }
    }
}
