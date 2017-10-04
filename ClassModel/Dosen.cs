using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class HonorJenjangDosen
    {
        public int IdHonorDosen { get; set; }
        public int IdJenjangPendidikan { get; set; }
        public int IdGolongan { get; set; }
        public string JenjangPendidikan { get; set; }
        public string Golongan { get; set; }
        public decimal HonorFix { get; set; }
        public decimal HonorVariable { get; set; }
        public string TanggalBerlaku { get; set; }
        public string TanggalSelesai { get; set; }
        public decimal Pajak { get; set; }
        public string UserAdd { get; set; }
        public string DateAdd { get; set; }
    }

    public class JenjangPendidikanDosen
    {
        public int IdJenjang { get; set; }
        public string Jenjang { get; set; }
        public string Keterangan { get; set; }
    }

    public class GolonganDosen
    {
        public int IdGolongan { get; set; }
        public string NamaGolongan { get; set; }
        public string Pangkat { get; set; }
    }

    public class TimDosen
    {
        public string NamaTim { get; set; }
        public string Nik { get; set; }
        public string NamaDosen { get; set; }
    }

    public class HonorMengajarDosen
    {
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public string Kelas { get; set; }
        public int SemesterDitawarkan { get; set; }
        public string NIK { get; set; }
        public bool IsPraktikumDosenLain { get; set; }
        public string NamaDosen { get; set; }
        public string JenisMataKuliah { get; set; }
        public int Sks { get; set; }
        public int SksTp { get; set; }
        public int BebanSks { get; set; }
        public int JumlahPertemuan { get; set; }
        public string KodeFakultas { get; set; }
        public string NamaFakultas { get; set; }
        public string IdProdi { get; set; }
        public string NamaProdi { get; set; }
        public string KodeProgram { get; set; }
        public string NamaProgram { get; set; }
        public string JenjangPendidikan { get; set; }
        public string Golongan { get; set; }
        public string Npwp { get; set; }
        public string NoRekeningBank { get; set; }
        public string NamaBank { get; set; }
        public decimal HFix { get; set; }
        public decimal HVar { get; set; }
        public string KategoriDosen { get; set; }
    }
}
