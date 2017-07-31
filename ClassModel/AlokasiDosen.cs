using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class AlokasiDosenMengajar
    {
        public int IdKuliah { get; set; }
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public int IdKelas { get; set; }
        public string NamaKelas { get; set; }
        public int SemesterDitawarkan { get; set; }
        public string NIK { get; set; }
        public string NamaDosen { get; set; }
        public string JenisMataKuliah { get; set; }
        public int Sks { get; set; }

    }

    public class DataDosen
    {
        public string Nik { get; set; }
        public string NamaDosen { get; set; }
        public int Sks { get; set; }
    }
}
