using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonversiAlihJalur.Models
{
    class PendaftarAlihJalur
    {
        public string Nodaf { get; set; }
        public string NpmLama { get; set; }
        public string Nama { get; set; }
        public string Pilihan1 { get; set; }
        public int Approve { get; set; }
    }

    class DetailNilaiPendaftarAlihJalur
    {
        public string KodeD3 { get; set; }
        public string MataKuliahD3 { get; set; }
        public int SksD3 { get; set; }
        public string KodeS1 { get; set; }
        public string MataKuliahS1 { get; set; }
        public int SksS1 { get; set; }
        public string Nilai { get; set; }
        public bool Approve { get; set; }
    }
    
    public class HistoryKonversiNilai
    {
        public string Npm { get; set; }
        public string KodeD3 { get; set; }
        public string MataKuliahD3 { get; set; }
        public int SksD3 { get; set; }
        public string KodeS1 { get; set; }
        public string Nilai { get; set; }
        public bool Approve { get; set; }
    }
}
