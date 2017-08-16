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
}
