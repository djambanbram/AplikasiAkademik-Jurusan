﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class MataKuliah
    {
        public static List<KategoriMK> listKategoriMK;
        public static List<SifatMK> listSifatMK;
        public static List<DataMataKuliah> listDataMataKuliah;
    }

    public class KategoriMK
    {
        public string Kategori { get; set; }
    }

    public class SifatMK
    {
        public string KodeSifat { get; set; }
        public string NamaSifat { get; set; }
    }
    
    public class DataMataKuliah
    {
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public string MataKuliahEn { get; set; }
        public string Alias { get; set; }
        public string SingkatanKelas { get; set; }
        public int Sks { get; set; }
        public int SksPraktikum { get; set; }
        public int SemesterDitawarkan { get; set; }
        public string KategoriMk { get; set; }
        public string SifatMK { get; set; }
        public string KodeSifatMK { get; set; }
        public int TahunMulai { get; set; }
        public string UidProdi { get; set; }
    }
}
