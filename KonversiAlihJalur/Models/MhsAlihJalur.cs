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
        public string Jenjang { get; set; }
    }

    class DetailNilaiPendaftarAlihJalur
    {
        public string Id { get; set; }
        public string KodeD3 { get; set; }
        public string MataKuliahD3 { get; set; }
        public int SksD3 { get; set; }
        public string NilaiD3 { get; set; }
        public string KodeS1 { get; set; }
        public string MataKuliahS1 { get; set; }
        public int SksS1 { get; set; }
        public string Nilai { get; set; }
        public bool Approve { get; set; }
    }

    class DetailNilaiPendaftarPemutihan
    {
        public string KodeLama { get; set; }
        public string MataKuliahLama { get; set; }
        public int SksLama { get; set; }
        public string KodePemutihan { get; set; }
        public string MataKuliahPemutihan { get; set; }
        public int SksPemutihan { get; set; }
        public string Nilai { get; set; }
        public bool Approve { get; set; }
    }


    public class HistoryKonversiNilai
    {
        public Guid Id { get; set; }
        public string Nodaf { get; set; }
        public string Npm { get; set; }
        public string KodeD3 { get; set; }
        public string MataKuliahD3 { get; set; }
        public int SksD3 { get; set; }
        public string NilaiD3 { get; set; }
        public string KodeS1 { get; set; }
        public string Nilai { get; set; }
        public bool Approve { get; set; }
    }
}
