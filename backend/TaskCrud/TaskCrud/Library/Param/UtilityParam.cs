using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCrud.Library.Param
{
    public static class UtilityParam
    {
        public static SqlParameter CaptureParamSql(SortedList List, string Key, bool DefaultNull)
        {
            string Value = CaptureTextField(List, Key);

            if (String.IsNullOrEmpty(Value) && DefaultNull)
                return new SqlParameter("@" + Key, System.DBNull.Value);
            else
                return new SqlParameter("@" + Key, Value);
        }

        public static string CaptureTextField(SortedList List, string Key)
        {
            string Value = String.Empty;

            if (List != null)
            {
                if (List.ContainsKey(Key))
                    Value = Convert.ToString(List[Key]);
            }

            return Value;
        }

        public static DataTable CaptureTableField(SortedList List, String Key)
        {
            //--A lista tiver vazia cria um objeto vazio    
            DataTable Result;

            if (List == null)
            {
                Result = new DataTable();
            }
            else if (!List.ContainsKey(Key))
            {
                Result = new DataTable();
            }
            else
            {
                var Table = List[Key];

                Result = Table is DataTable TableAux ? TableAux : new DataTable();
            }

            return Result;
        }
    }
}
