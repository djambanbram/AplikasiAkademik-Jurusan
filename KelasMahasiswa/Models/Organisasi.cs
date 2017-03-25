using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelasMahasiswa.Models
{
    public class Fakultas
    {
        public Guid IdFakultas { get; set; }
        public string KodeFakultas { get; set; }
        public string NamaFakultas { get; set; }
    }

    public class ProgramStudi
    {
        public Guid Id { get; set; }
        public string IdProdi { get; set; }
        public string NamaProdi { get; set; }
        public string Jenjang { get; set; }
    }

    public class ProgramProdi
    {
        public string KodeProgram { get; set; }
        public string NamaProgram { get; set; }
        public Guid IdProdi { get; set; }
        public string NamaProdi { get; set; }
    }
}
