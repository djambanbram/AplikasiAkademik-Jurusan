using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenawaranKurikulum.Listener
{
    public interface IRefreshAlokasi
    {
        void saveMultiKelas(List<int> listIdKelas);
    }
}
