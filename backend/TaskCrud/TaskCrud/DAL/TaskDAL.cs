using TaskCrud.Library.Param;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TaskCrud.Library.Types;

namespace TaskCrud.DAL
{
    public class TaskDAL : Connection.Connection
    {
        public BaseResult Read(SortedList Param) 
        {
            BaseResult Result = new();

            try
            {
                SqlCommand Command = new("STP_TASK_READ");

                Command.Parameters.Add(UtilityParam.CaptureParamSql(Param, "NM_TASK", false));

                Result = ExecReadCommand(Command);
            }
            catch (SqlException Error) 
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Error.Message;
            }

            return Result;
        }

        public BaseResult ReadById(SortedList Param)
        {
            BaseResult Result = new();

            try
            {
                SqlCommand Command = new("STP_TASK_READ_BY_ID");

                Command.Parameters.Add(UtilityParam.CaptureParamSql(Param, "SQ_TASK", true));

                Result = ExecReadCommand(Command);
            }
            catch (SqlException Error)
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Error.Message;
            }

            return Result;
        }

        public BaseResult Post(SortedList Param) 
        {
            BaseResult Result = new();

            try
            {
                SqlCommand Command = new("STP_TASK_POST");

                Command.Parameters.Add(UtilityParam.CaptureParamSql(Param, "NM_TASK", false));
                Command.Parameters.Add(UtilityParam.CaptureParamSql(Param, "DS_TASK", false));

                Result = ExecModifyCommand(Command);
            }
            catch (SqlException Error)
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Error.Message;
            }

            return Result;
        }

        public BaseResult Put(SortedList Param)
        {
            BaseResult Result = new();

            try
            {
                SqlCommand Command = new("STP_TASK_PUT");

                Command.Parameters.Add(UtilityParam.CaptureParamSql(Param, "SQ_TASK", true));
                Command.Parameters.Add(UtilityParam.CaptureParamSql(Param, "NM_TASK", false));
                Command.Parameters.Add(UtilityParam.CaptureParamSql(Param, "DS_TASK", false));

                Result = ExecModifyCommand(Command);
            }
            catch (SqlException Error)
            {
                Result.Type = MessageType.Error;
                Result.Message = "Erro encontrado: " + Error.Message;
            }

            return Result;
        }
    }
}
