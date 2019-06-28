using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonversiAlihJalur
{
    public interface IMataKuliah
    {
        void TambahMataKuliah(string kode, string mataKuliah, int sks, string nilai, int rowIndex);
    }
}
