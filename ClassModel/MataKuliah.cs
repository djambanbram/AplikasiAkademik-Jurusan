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
        public static List<DataMataKuliahPrasyarat> listDataMataKuliahPrasyarat;
        public static List<MataKuliahDitawarkan> listMataKuliahBelumDitawarkan;
        public static List<MataKuliahDitawarkan> listMataKuliahSudahDitawarkan;
        public static List<DataMataKuliahCampuran> listDataMataKuliahCampuran;
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
        public string SingkatanMK { get; set; }
        public string SingkatanKelas { get; set; }
        public int Sks { get; set; }
        public int SksPraktikum { get; set; }
        public int SemesterDitawarkan { get; set; }
        public string KategoriMK { get; set; }
        public string SifatMK { get; set; }
        public string KodeSifatMK { get; set; }
        public int TahunMulai { get; set; }
        public string IdProdi { get; set; }
        public string KodeProgram { get; set; }
        public int Sampai { get; set; }
        public string KodeKesetaraan { get; set; }
    }

    public class DataMataKuliahPrasyarat : DataMataKuliah
    {
        public string KodePrasyarat { get; set; }
        public string MataKuliahPrasyarat { get; set; }
    }

    public class DataMataKuliahCampuran : DataMataKuliah
    {
        public string JenisMK { get; set; }
        public int JumlahKelas { get; set; }

    }

    public class MataKuliahDitawarkan
    {
        public int SemesterDitawarkan { get; set; }
        public int Angkatan { get; set; }
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
        public string KodeSifatMK { get; set; }
        public string SifatMK { get; set; }
        public int SksTeori { get; set; }
        public int SksPraktikum { get; set; }
        public string JenisMK { get; set; }
        public string DaftarKelasMK { get; set; }
    }
}
