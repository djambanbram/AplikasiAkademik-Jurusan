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
                m.Alias = item.Alias;
                m.SingkatanKelas = item.SingkatanKelas;
                m.Sks = item.Sks;
                m.SksPraktikum = item.SksPraktikum;
                m.SemesterDitawarkan = item.SemesterDitawarkan;
                m.KategoriMk = item.KategoriMk;
                m.KodeSifatMK = item.KodeSifatMK;
                m.SifatMK = item.SifatMK;
                m.TahunMulai = item.TahunMulai;
                m.UidProdi = item.IdProdi;
                listMK.Add(m);
            }
            ClassModel.MataKuliah.listDataMataKuliah = listMK;
        }
    }

    class MKByIdProdi
    {
        public string IdProdi { get; set; }
    }
}
