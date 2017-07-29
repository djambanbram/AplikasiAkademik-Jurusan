using ClassModel;
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
        private List<KelasAktif> listKelasAktif;

        public KelasAktifBinding(List<dynamic> listSerializable)
        {
            listKelasAktif = new List<ClassModel.KelasAktif>();
            foreach (var item in listSerializable)
            {
                KelasAktif k = new KelasAktif();
                k.NamaKelas = item.NamaKelas;
                k.Angkatan = item.Angkatan;
                k.SemesterDitawarkan = item.SemesterDitawarkan;
                k.JumlahMHS = item.JumlahMHS;
                listKelasAktif.Add(k);
            }
            Kelas.listKelasAktif = listKelasAktif;
        }
    }

    class KelasCampuranAktifBinding
    {
        private List<KelasCampuranAktif> listKelasCampuranAktif;

        public KelasCampuranAktifBinding(List<dynamic> listSerializable)
        {
            listKelasCampuranAktif = new List<ClassModel.KelasCampuranAktif>();
            foreach (var item in listSerializable)
            {
                KelasCampuranAktif k = new KelasCampuranAktif();
                k.IdKelas = item.IdKelas;
                k.Kode = item.Kode;
                k.MataKuliah = item.MataKuliah;
                k.NamaKelas = item.NamaKelas;
                k.Angkatan = item.Angkatan;
                k.SemesterDitawarkan = item.Semester;
                listKelasCampuranAktif.Add(k);
            }
            Kelas.listKelasCampuranAktif = listKelasCampuranAktif;
        }
    }

    class MataKuliahCampuranBinding
    {
        private List<DataMataKuliahCampuran> listMKCampuran;

        public MataKuliahCampuranBinding(List<dynamic> listSerializable)
        {
            listMKCampuran = new List<DataMataKuliahCampuran>();
            foreach(var item in listSerializable)
            {
                DataMataKuliahCampuran m = new DataMataKuliahCampuran();
                m.Kode = item.Kode;
                m.MataKuliah = item.MataKuliah;
                m.MataKuliahEn = item.MataKuliahEn;
                m.SingkatanMK = item.Alias;
                m.SingkatanKelas = item.SingkatanKelas;
                m.Sks = item.Sks;
                m.SksPraktikum = item.SksPraktikum;
                m.SemesterDitawarkan = item.SemesterDitawarkan;
                m.KategoriMK = item.KategoriMK;
                m.KodeSifatMK = item.KodeSifatMK;
                m.SifatMK = item.SifatMK;
                m.JenisMK = item.JenisMK;
                m.JumlahKelas = item.JumlahKelas;
                listMKCampuran.Add(m);
            }
            MataKuliah.listDataMataKuliahCampuran = listMKCampuran;
        }
    }
}
