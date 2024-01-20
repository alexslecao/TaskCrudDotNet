using TaskCrud.Library.Param;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TaskCrud.Library.Types;

namespace TaskCrud.Controllers
{
    [EnableCors("PoliticaSitesPermitidos")]
    [Route("[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string ResultJson(BaseResult Result, bool HideTable = false)
        {
            if (!HideTable)
                HideTable = Result.Type != MessageType.Success;

            DataTable Table = new DataTable();

            if (!HideTable && Result.Table != null)
                Table = Result.Table;

            var JsonResult = new
            {
                Result.Type,
                Result.Message,
                Table
            };

            return JsonConvert.SerializeObject(JsonResult);
        }
    }
}