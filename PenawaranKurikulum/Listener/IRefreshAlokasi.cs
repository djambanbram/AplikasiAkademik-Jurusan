using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenawaranKurikulum.Listener
{
    public interface IRefreshAlokasiDosen
    {
        void saveMultiKelas(List<int> listIdKelas);
    }

    public interface IRefreshAlokasiRuang
    {
        void saveJumlahKelas(string ruang, int jumlahKelas, string kode);
        void updateJumlahKelas(string ruang, int jumlahKelas, string kode);
    }

    public interface IRefreshKurikulum
    {
        void RefreshKurikulum(string kodeProgram);
    }
}
