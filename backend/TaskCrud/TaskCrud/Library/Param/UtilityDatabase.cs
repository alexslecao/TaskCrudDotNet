using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCrud.Library.Param
{
    public static class UtilityDatabase
    {
        public static string CaptureTextFild(DataTable Table, string Key)
        {
            string Value = String.Empty;

            if (Table != null)
            {
                if (Table.Rows.Count > 0)
                    Value = CaptureTextFild(Table.Rows[0], Key);
            }

            return Value;
        }

        public static string CaptureTextFild(DataRow Line, string Key)
        {
            string Value = String.Empty;

            if (Line != null)
            {
                if (Line.Table.Columns.Contains(Key))
                {
                    Value = Convert.ToString(Line[Key]);
                }
            }

            return Value;
        }

        public static bool CaptureDateTimeFild(DataTable Table, string Key, ref DateTime resultado)
        {
            bool Success = false;

            if (Table != null)
            {
                if (Table.Rows.Count > 0)
                    Success = CaptureDateTimeFild(Table.Rows[0], Key, ref resultado);
            }

            return Success;
        }

        public static bool CaptureDateTimeFild(DataRow Line, string Key, ref DateTime resultado)
        {
            bool Success = false;

            if (Line != null)
            {
                if (Line.Table.Columns.Contains(Key))
                {
                    string dataTemp = Convert.ToString(Line[Key]);

                    Success = DateTime.TryParse(dataTemp, out resultado);
                }
            }

            return Success;
        }
    }
}
