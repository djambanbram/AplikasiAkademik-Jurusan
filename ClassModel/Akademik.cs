using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModel
{
    public class Akademik
    {
        public static List<DataSemester> listDataSemester;
    }
    public class DataSemester
    {
        public int Kode { get; set; }
        public string Nama { get; set; }
    }
}
