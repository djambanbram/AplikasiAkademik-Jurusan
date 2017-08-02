using ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenawaranKurikulum.DataBinding
{
    class MataKuliahBelumDitawarkanBinding
    {
        private List<MataKuliahDitawarkan> listMKBelumDitawarkan;
        public MataKuliahBelumDitawarkanBinding(List<dynamic> listSerialized)
        {
            listMKBelumDitawarkan = new List<MataKuliahDitawarkan>();
            foreach (var item in listSerialized)
            {
                MataKuliahDitawarkan m = new MataKuliahDitawarkan();
                m.SemesterDitawarkan = item.Semester == null ? 0 : item.Semester;
                m.Angkatan = item.Angkatan;
                m.Kode = item.Kode;
                m.MataKuliah = item.MataKuliah;
                m.KodeSifatMK = item.KodeSifatMK;
                m.SifatMK = item.SifatMK;
                m.SksTeori = item.SksTeori;
                m.SksPraktikum = item.SksPraktikum;
                m.JenisMK = item.JenisMK;
                m.DaftarKelasMK = item.DaftarKelasMK;
                listMKBelumDitawarkan.Add(m);
            }
            MataKuliah.listMataKuliahBelumDitawarkan = listMKBelumDitawarkan;
        }
    }
    class MataKuliahSudahDitawarkanBinding
    {
        private List<MataKuliahDitawarkan> listMKSudahDitawarkan;
        public MataKuliahSudahDitawarkanBinding(List<dynamic> listSerialized)
        {
            listMKSudahDitawarkan = new List<MataKuliahDitawarkan>();
            foreach (var item in listSerialized)
            {
                MataKuliahDitawarkan m = new MataKuliahDitawarkan();
                m.SemesterDitawarkan = item.Semester;
                m.Angkatan = item.Angkatan;
                m.Kode = item.Kode;
                m.MataKuliah = item.MataKuliah;
                m.KodeSifatMK = item.KodeSifatMK;
                m.SifatMK = item.SifatMK;
                m.SksTeori = item.SksTeori;
                m.SksPraktikum = item.SksPraktikum;
                m.JenisMK = item.JenisMK;
                m.DaftarKelasMK = item.DaftarKelasMK;
                m.JumlahKelas = item.JumlahKelas;
                listMKSudahDitawarkan.Add(m);
            }
            MataKuliah.listMataKuliahSudahDitawarkan = listMKSudahDitawarkan;
        }
    }

    class AlokasiDosenBinding
    {

    }
}
