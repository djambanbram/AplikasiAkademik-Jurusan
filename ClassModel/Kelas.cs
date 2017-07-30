﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Kelas
    {
        public static List<KelasMhs> listKelasMhs;
        public static List<KelasAktif> listKelasAktif;
        public static List<KelasCampuranAktif> listKelasCampuranAktif;
    }

    public class KelasMhs
    {
        public int Tha { get; set; }
        public int Jumlahkelas { get; set; }
        public bool Aktif { get; set; }
    }

    public class KelasAktif
    {
        public string IdKelas { get; set; }
        public string NamaKelas { get; set; }
        public int Angkatan { get; set; }
        public int SemesterDitawarkan { get; set; }
        public int JumlahMHS { get; set; }
    }

    public class KelasCampuranAktif : KelasAktif
    {
        public string Kode { get; set; }
        public string MataKuliah { get; set; }
    }
}