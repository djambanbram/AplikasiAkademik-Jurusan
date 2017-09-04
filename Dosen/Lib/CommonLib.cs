using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dosen.Lib
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

        public static string NumberToRoman(int number)
        {


            if (number < 0 || number > 3999)
            {
                throw new ArgumentException("Value must be in the range 0 – 3,999.");
            }
            if (number == 0) return "N";

            int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] numerals = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder result = new StringBuilder();

            // Loop through each of the values to diminish the number
            for (int i = 0; i < 13; i++)
            {

                // If the number being converted is less than the test value, append
                // the corresponding numeral or numeral pair to the resultant string
                while (number >= values[i])
                {
                    number -= values[i];
                    result.Append(numerals[i]);
                }

            }

            return result.ToString();

        }
    }
}
