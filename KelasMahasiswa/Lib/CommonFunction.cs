using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KelasMahasiswa.Lib
{
    public class CommonFunction
    {
        public static void FormLoading(Control parentControl, ProgressBar pb, bool onLoading)
        {
            if(onLoading)
            {
                parentControl.Enabled = false;
                pb.Visible = true;
            }
            else
            {
                parentControl.Enabled = true;
                pb.Visible = false;
            }
        }
    }
}
