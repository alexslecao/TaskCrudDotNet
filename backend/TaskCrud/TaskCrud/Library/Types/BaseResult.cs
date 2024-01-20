using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TaskCrud.Library.Types
{
    public class BaseResult
    {
        public string Type { get; set; }

        public string Message { get; set; }

        public DataTable Table { get; set; }


    }
}
