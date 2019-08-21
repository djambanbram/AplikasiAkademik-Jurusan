using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MataKuliah.DataBinding
{
    class MataKuliahBinding
    {
        private List<ClassModel.DataMataKuliah> listMK;
        public MataKuliahBinding(List<dynamic> listSerialized)
        {
            listMK = new List<ClassModel.DataMataKuliah>();
            foreach(var item in listSerialized)
            {
                ClassModel.DataMataKuliah m = new ClassModel.DataMataKuliah();
                m.Kode = item.Kode;
                m.MataKuliah = item.MataKuliah;
                m.MataKuliahEn = item.MataKuliahEn;
                m.SingkatanMK = item.SingkatanMK;
                m.SingkatanKelas = item.SingkatanKelas;
                m.Sks = item.Sks;
                m.SksPraktikum = item.SksPraktikum;
                m.SemesterDitawarkan = item.SemesterDitawarkan;
                m.KategoriMK = item.KategoriMK;
                m.KodeSifatMK = item.KodeSifatMK;
                m.SifatMK = item.SifatMK;
                m.TahunMulai = item.TahunMulai;
                m.IdProdi = item.IdProdi;
                m.IsTugasAkhir = item.IsTugasAkhir;
                listMK.Add(m);
            }
            ClassModel.MataKuliah.listDataMataKuliah = listMK;
        }
    }

    class MataKuliahPrasyaratBinding
    {
        private List<ClassModel.DataMataKuliahPrasyarat> listMK;
        public MataKuliahPrasyaratBinding(List<dynamic> listSerialized)
        {
            listMK = new List<ClassModel.DataMataKuliahPrasyarat>();
            foreach (var item in listSerialized)
            {
                ClassModel.DataMataKuliahPrasyarat m = new ClassModel.DataMataKuliahPrasyarat();
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
                m.TahunMulai = item.TahunMulai;
                m.IdProdi = item.IdProdi;
                m.KodePrasyarat = item.KodePrasyarat;
                m.MataKuliahPrasyarat = item.MataKuliahPrasyarat;
                listMK.Add(m);
            }
            ClassModel.MataKuliah.listDataMataKuliahPrasyarat = listMK;
        }
    }

    //class MKByIdProdi
    //{
    //    public string IdProdi { get; set; }
    //}
}
