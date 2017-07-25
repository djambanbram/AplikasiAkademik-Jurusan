using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Organisasi
    {
        public static List<Program> listProgram;
        public static List<Prodi> listProdi;
        public static List<Fakultas> listFakultas;
    }

    public class Program
    {
        public string KodeProgram { get; set; }
        public string NamaProgram { get; set; }
        public Prodi Prodi { get; set; }
    }

    public class Prodi
    {
        public string Uid { get; set; }
        public string IdProdi { get; set; }
        public string NamaProdi { get; set; }
        public string Jenjang { get; set; }
        public Fakultas Fakultas { get; set; }
    }

    public class Fakultas
    {
        public string KodeFakultas { get; set; }
        public string NamaFakultas { get; set; }
    }
}
