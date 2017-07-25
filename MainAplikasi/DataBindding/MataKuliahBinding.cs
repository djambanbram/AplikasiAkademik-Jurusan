using ClassModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAplikasi.DataBindding
{
    public class KategoriMKBinding
    {
        private List<KategoriMK> listKategoriMK;

        public KategoriMKBinding(List<dynamic> listSerialized)
        {
            listKategoriMK = new List<KategoriMK>();
            foreach(var item in listSerialized)
            {
                KategoriMK k = new KategoriMK();
                k.Kategori = item.Jenis;
                listKategoriMK.Add(k);
            }
            ClassModel.MataKuliah.listKategoriMK = listKategoriMK;
        }
    }
    public class SifatMKBinding
    {
        private List<SifatMK> listSifatMK;

        public SifatMKBinding(List<dynamic> listSerialized)
        {
            listSifatMK = new List<SifatMK>();
            foreach (var item in listSerialized)
            {
                SifatMK s = new SifatMK();
                s.KodeSifat= item.Key;
                s.NamaSifat= item.Value;
                listSifatMK.Add(s);
            }
            ClassModel.MataKuliah.listSifatMK = listSifatMK;
        }
    }
}
