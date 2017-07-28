using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KelasMahasiswa.DataBinging
{
    class KelasMhsBinding
    {
        private List<ClassModel.KelasMhs> listKelasMhs;

        public KelasMhsBinding(List<dynamic> listSerializable)
        {
            listKelasMhs = new List<ClassModel.KelasMhs>();
            foreach(var item in listSerializable)
            {
                ClassModel.KelasMhs k = new ClassModel.KelasMhs();
                k.Tha = item.Tha;
                k.Jumlahkelas = item.JumlahKelas;
                k.Aktif = item.Aktif;
                listKelasMhs.Add(k);
            }
            ClassModel.Kelas.listKelasMhs = listKelasMhs;
        }
    }

    class KelasAktifBinding
    {
        private List<ClassModel.KelasAktif> listKelasAktif;

        public KelasAktifBinding(List<dynamic> listSerializable)
        {
            listKelasAktif = new List<ClassModel.KelasAktif>();
            foreach (var item in listSerializable)
            {
                ClassModel.KelasAktif k = new ClassModel.KelasAktif();
                k.NamaKelas = item.NamaKelas;
                k.Angkatan = item.Angkatan;
                k.SemesterDitawarkan = item.SemesterDitawarkan;
                k.JumlahMHS = item.JumlahMHS;
                listKelasAktif.Add(k);
            }
            ClassModel.Kelas.listKelasAktif = listKelasAktif;
        }
    }
}
