using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskCrud.BLL;
using TaskCrud.Library.Param;
using TaskCrud.Library.Types;

namespace TaskCrud.Controllers
{
    public class TaskController : BaseController
    {
        [HttpGet]
        public string Read()
        {
            string Result;
            try
            {
                TaskBLL ReadTaskBLL = new();
                BaseResult ResultAux = ReadTaskBLL.Read(new SortedList());

                Result = ResultJson(ResultAux);
            }
            catch (Exception Erro)
            {
                throw new Exception("Erro ao Processar pedido. Erro: " + Erro.Message);
            }

            return Result;
        }

        [HttpGet("{id}")]
        public string ReadById(string Id)
        {
            string Result;
            try
            {
                SortedList Params = new();

                Params["SQ_TASK"] = Id;

                TaskBLL ReadByIdTaskBLL = new();
                BaseResult ResultAux = ReadByIdTaskBLL.ReadById(Params);

                Result = ResultJson(ResultAux);
            }
            catch (Exception Erro)
            {
                throw new Exception("Erro ao Processar pedido. Erro: " + Erro.Message);
            }

            return Result;
        }

        [HttpPost]
        public string Post([FromBody] SortedList BodyParam) 
        {
            string Result;
            try 
            {
                SortedList Params = new();

                Params["NM_TASK"] = UtilityParam.CaptureTextField(BodyParam, "name");
                Params["DS_TASK"] = UtilityParam.CaptureTextField(BodyParam, "descripton");

                TaskBLL PostTask = new();
                BaseResult ResultAux = PostTask.Post(Params);

                Result = ResultJson(ResultAux, true);
            }
            catch (Exception Erro)
            {
                throw new Exception("Erro ao Processar pedido. Erro: " + Erro.Message);
            }

            return Result;
        }

        [HttpPut("{id}")]
        public string Put(string Id, [FromBody] SortedList BodyParam)
        {
            string Result;
            try
            {
                SortedList Params = new();

                Params["SQ_TASK"] = Id;
                Params["NM_TASK"] = UtilityParam.CaptureTextField(BodyParam, "name");
                Params["DS_TASK"] = UtilityParam.CaptureTextField(BodyParam, "descripton");

                TaskBLL PutTaskBLL = new();
                BaseResult ResultAux = PutTaskBLL.Put(Params);

                Result = ResultJson(ResultAux);
            }
            catch (Exception Erro)
            {
                throw new Exception("Erro ao Processar pedido. Erro: " + Erro.Message);
            }

            return Result;
        }
    }
}