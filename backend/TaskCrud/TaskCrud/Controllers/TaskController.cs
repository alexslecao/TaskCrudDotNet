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
        public string Insert([FromBody] SortedList BodyParam) 
        {
            string Result;
            try 
            {
                SortedList Params = new();

                Params["NM_TASK"] = UtilityParam.CaptureTextField(BodyParam, "name");
                Params["DS_TASK"] = UtilityParam.CaptureTextField(BodyParam, "description");

                TaskBLL InsertTask = new();
                BaseResult ResultAux = InsertTask.Insert(Params);

                Result = ResultJson(ResultAux, true);
            }
            catch (Exception Erro)
            {
                throw new Exception("Erro ao Processar pedido. Erro: " + Erro.Message);
            }

            return Result;
        }

        [HttpPut("{id}")]
        public string Update(string Id, [FromBody] SortedList BodyParam)
        {
            string Result;
            try
            {
                SortedList Params = new();

                Params["SQ_TASK"] = Id;
                Params["NM_TASK"] = UtilityParam.CaptureTextField(BodyParam, "name");
                Params["DS_TASK"] = UtilityParam.CaptureTextField(BodyParam, "description");

                TaskBLL UpdateTaskBLL = new();
                BaseResult ResultAux = UpdateTaskBLL.Update(Params);

                Result = ResultJson(ResultAux);
            }
            catch (Exception Erro)
            {
                throw new Exception("Erro ao Processar pedido. Erro: " + Erro.Message);
            }

            return Result;
        }

        [HttpDelete("{id}")]
        public string Delete(string Id)
        {
            string Result;
            try
            {
                SortedList Params = new();

                Params["SQ_TASK"] = Id;

                TaskBLL DeleteTaskBLL = new();
                BaseResult ResultAux = DeleteTaskBLL.Delete(Params);

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