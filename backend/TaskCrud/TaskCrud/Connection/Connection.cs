using TaskCrud.Library.Param;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TaskCrud.Library.Types;

namespace TaskCrud.Connection
{
    public class Connection
    {
        private const string _StringConnection = @"Data Source=G1033;Initial Catalog=AXS;User ID=sa;Password=sta";

        private const int _TimeoutDefault = 60; //-Seconds

        private readonly SqlConnection _Connection;

        private SqlTransaction _CurrentTransaction;

        public Connection() 
        {
            _Connection = new SqlConnection(_StringConnection);
        }

        private SqlConnection OpenConnection() 
        {
            if (_Connection.State == ConnectionState.Closed) 
            {
                _Connection.Open();
            }

            return _Connection;
        }

        private SqlConnection CloseConnection()
        {
            if (_Connection.State == ConnectionState.Open)
            {
                _Connection.Close();
            }

            return _Connection;
        }

        private SqlTransaction BeginTransaction() 
        {
            if (_Connection.State == ConnectionState.Open)
            {
                _CurrentTransaction = _Connection.BeginTransaction();
                return _CurrentTransaction;
            }
            else
                throw new Exception("Erro ao tentar iniciar Transação com Banco de Dados");
        }

        public void SetCommit()
        {
            _CurrentTransaction.Commit();
        }

        public void SetAbort() 
        {
            _CurrentTransaction.Rollback();
        }

        public BaseResult ExecReadCommand(SqlCommand Command) 
        {
            BaseResult Result = new();

            try
            {
                //Open Conncection
                Command.Connection = OpenConnection();

                //-Set command type
                Command.CommandType = CommandType.StoredProcedure;

                //-Set Timeout
                Command.CommandTimeout = _TimeoutDefault;

                //-Exec command
                SqlDataAdapter Adapter = new(Command);

                //-Result Table
                DataTable TbResult = new();

                //-Save Result
                Adapter.Fill(TbResult);

                //-Checks if the value is different from null
                if (TbResult == null)
                {
                    throw new Exception("A tabela de retorno do comando é nula");
                }
                else if (TbResult.Rows.Count == 0)
                {
                    throw new Exception("A tabela não retornou registros");
                }
                else
                {
                    string Type = UtilityDatabase.CaptureTextFild(TbResult, "Type");
                    string Message = UtilityDatabase.CaptureTextFild(TbResult, "Message");

                    if (String.IsNullOrEmpty(Type) && String.IsNullOrEmpty(Type))
                    {
                        Result.Type = MessageType.Success;
                        Result.Message = "";
                        Result.Table = TbResult;
                    }
                    else 
                    {
                        Result.Type = Type;
                        Result.Message = Message;
                        Result.Table = TbResult;
                    }
                }
            }
            catch (SqlException ex)
            {
                //#aqui deve gravar mensagem de erro
                Result.Type = MessageType.Error;
                Result.Message = ex.Message;
            }
            finally
            {
                CloseConnection();
            }

            return Result;
        }

        public BaseResult ExecModifyCommand(SqlCommand Command)
        {
            BaseResult Result = new();

            try
            {
                //Abre Conexao com banco
                Command.Connection = OpenConnection();

                //Defino que vai usar stored procedures
                Command.CommandType = CommandType.StoredProcedure;

                //Tempo maximo para execucao do comando no banco de 1 minuto
                Command.CommandTimeout = _TimeoutDefault;

                //Cria uma transacao e atribui
                Command.Transaction = BeginTransaction();

                //Manda executar o comando no banco de dados
                SqlDataAdapter Adapter = new(Command);

                //Tabela para guardar o retorno do banco
                DataTable TbResult = new();

                //Coloca os campos do retorno na tabela
                Adapter.Fill(TbResult);

                if (TbResult == null)
                {
                    throw new Exception("O parametro tabela é nullo");
                }
                else if (TbResult.Rows.Count == 0)
                {
                    throw new Exception("A tabela não retornou registros");
                }
                else
                {
                    string Type = UtilityDatabase.CaptureTextFild(TbResult, "Type");
                    string Message = UtilityDatabase.CaptureTextFild(TbResult, "Message");

                    if (String.IsNullOrEmpty(Type))
                        throw new Exception("Não foi possível obter o campo Type da Procedure");

                    Result.Type = Type;
                    Result.Message = Message;
                    Result.Table = TbResult;
                }

                //Se o o banco retornou sucesso salva as alterações do banco
                if (Result.Type == MessageType.Success)
                    SetCommit();
                else
                    SetAbort();
            }
            catch (SqlException ex)
            {
                SetAbort();
                Result.Type = MessageType.Error;
                Result.Message = ex.Message;
            }
            finally
            {
                CloseConnection();
            }

            return Result;
        }
    }
}
