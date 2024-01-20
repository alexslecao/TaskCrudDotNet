using TaskCrud.DAL;
using TaskCrud.Library.Param;
using System;
using System.Collections;
using TaskCrud.Library.Types;

namespace TaskCrud.BLL
{
    public class TaskBLL
    {
        public BaseResult Read(SortedList Param)
        {
            BaseResult Result = new();

            try
            {
                string Message = "";

                //Validar Nome do Usuario
                string TaskName = UtilityParam.CaptureTextField(Param, "NM_TASK");

                if (!string.IsNullOrEmpty(TaskName))
                {
                    if (TaskName.Length > 200)
                        Message += "#O campo Nome do filtro só pode ter no maximo 100 letras";
                }

                if (string.IsNullOrEmpty(Message))
                {
                    TaskDAL ReadTaskDAL = new();
                    Result = ReadTaskDAL.Read(Param);
                }
                else
                {
                    Result.Type = MessageType.Warning;
                    Result.Message = Message;
                }

            }
            catch (Exception Erro)
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Erro.Message;
            }

            return Result;
        }

        public BaseResult ReadById(SortedList Param)
        {
            BaseResult Result = new();

            try
            {
                string Message = "";

                //Validar Nome do Usuario
                string TaskId = UtilityParam.CaptureTextField(Param, "SQ_TASK");

                if (string.IsNullOrEmpty(TaskId))
                {
                    Message += "#O campo Id da Atividade é obrigatório";
                }

                if (string.IsNullOrEmpty(Message))
                {
                    TaskDAL ReadByIdTaskDAL = new();
                    Result = ReadByIdTaskDAL.ReadById(Param);
                }
                else
                {
                    Result.Type = MessageType.Warning;
                    Result.Message = Message;
                }

            }
            catch (Exception Erro)
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Erro.Message;
            }

            return Result;
        }

        public BaseResult Post(SortedList Param) 
        {
            BaseResult Result = new();

            try
            {
                string Message = "";

                //Validar Nome do Usuario
                string TaskName = UtilityParam.CaptureTextField(Param, "NM_TASK");

                if (!string.IsNullOrEmpty(TaskName))
                {
                    if (TaskName.Length > 200)
                        Message += "#O campo Nome do filtro só pode ter no maximo 200 letras";
                }
                else 
                {
                    Message += "#O campo Nome da Atividade é obrigatório";
                }

                if (string.IsNullOrEmpty(Message))
                {
                    TaskDAL PostTaskDAL = new();
                    Result = PostTaskDAL.Post(Param);
                }
                else
                {
                    Result.Type = MessageType.Warning;
                    Result.Message = Message;
                }

            }
            catch (Exception Erro)
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Erro.Message;
            }

            return Result;
        }

        public BaseResult Put(SortedList Param)
        {
            BaseResult Result = new();

            try
            {
                string Message = "";

                //Validar Nome do Usuario
                string TaskId = UtilityParam.CaptureTextField(Param, "SQ_TASK");
                string TaskName = UtilityParam.CaptureTextField(Param, "NM_TASK");

                if (string.IsNullOrEmpty(TaskId))
                    Message += "#O campo Id da Atividade é obrigatório";

                if (!string.IsNullOrEmpty(TaskName))
                {
                    if (TaskName.Length > 200)
                        Message += "#O campo Nome do filtro só pode ter no maximo 200 letras";
                }
                else
                {
                    Message += "#O campo Nome da Atividade é obrigatório";
                }

                if (string.IsNullOrEmpty(Message))
                {
                    TaskDAL PostTaskDAL = new();
                    Result = PostTaskDAL.Put(Param);
                }
                else
                {
                    Result.Type = MessageType.Warning;
                    Result.Message = Message;
                }

            }
            catch (Exception Erro)
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Erro.Message;
            }

            return Result;
        }
    }
}
