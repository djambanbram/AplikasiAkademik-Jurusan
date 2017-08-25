using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonversiAlihJalur.Lib
{
    static class CommonLib
    {
        public static Tuple<bool, string> IsValidControlValidation(params Control[] control)
        {
            foreach (Control c in control)
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

        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
