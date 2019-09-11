using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class HasilMatrikulasiMhs
    {
        private string _nama;
        public string Idkonversi { get; set; }
        public string NpmLama { get; set; }
        public string Nodaf { get; set; }
        public string Nama { get { return _nama; } set { _nama = CultureInfo.CurrentCulture.TextInfo.ToTitleCase((value as string).ToLower()); } }
        public string Sekolah { get; set; }
        public string KodeD3 { get; set; }
        public string MataKuliahD3 { get; set; }
        public int SksD3 { get; set; }
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public string Sks { get; set; }
        public int SksTotalKonversi { get; set; }
        public string Nilai { get; set; }
        public int Nomor { get; set; }
    }
}
