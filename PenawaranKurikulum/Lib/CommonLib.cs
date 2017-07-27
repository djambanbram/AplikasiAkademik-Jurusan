using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PenawaranKurikulum.Lib
{
    class CommonLib
    {
        public static Tuple<bool, string> IsValidControlValidation(params Control[] control)
        {
            foreach(Control c in control)
            {
                if (c.Tag.ToString() == "tb")
                {
                    if (string.IsNullOrEmpty(c.Text))
                    {
                        return new Tuple<bool, string>(false, "Data yang bertanda * wajib diisi");
                    }
                }
                else if (c.Tag.ToString() == "cb")
                {
                    ComboBoxAdv cb = (ComboBoxAdv)c;
                    if (cb.SelectedIndex == 0)
                    {
                        return new Tuple<bool, string>(false, "Data yang bertanda * wajib diisi");
                    }
                }
            }
            return new Tuple<bool, string>(true, string.Empty);
        }
    }
}
