using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Interfaces;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace DataAccessLayer
{
    public class Conexao : IConexao 
    {
        private readonly string connectionString;
        private SqlCommand command;
        private List<SqlParameter> sqlParameters;
        private SqlConnection sqlConnection;

        public Conexao(string ConnectionString)
        {
            connectionString = ConnectionString;
            sqlParameters = new List<SqlParameter>();
            sqlConnection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.Connection = sqlConnection;
        }

        public void AdicionaParametro(string NomeParametro, int? Valor)
        {
            var parameter = new SqlParameter()
            {
                DbType = DbType.Int32,
                Value = Valor,
                ParameterName = NomeParametro
            };

            sqlParameters.Add(parameter);
        }

        public void AdicionaParametro(string NomeParametro, int Valor)
        {
            var parameter = new SqlParameter()
            {
                DbType = DbType.Int32,
                Value = Valor,
                ParameterName = NomeParametro
            };

            sqlParameters.Add(parameter);
        }

        public void AdicionaParametro(string NomeParametro, string Valor)
        {
            var parameter = new SqlParameter()
            {
                DbType = DbType.String,
                Value = Valor,
                ParameterName = NomeParametro
            };

            sqlParameters.Add(parameter);
        }

        public void AdicionaParametro(string NomeParametro, bool Valor)
        {
            var parameter = new SqlParameter()
            {
                DbType = DbType.Boolean,
                Value = Valor,
                ParameterName = NomeParametro
            };

            sqlParameters.Add(parameter);
        }

        public void AdicionaParametro(string NomeParametro, bool? Valor)
        {
            var parameter = new SqlParameter()
            {
                DbType = DbType.Boolean,
                Value = Valor,
                ParameterName = NomeParametro
            };

            sqlParameters.Add(parameter);
        }

        public SqlDataReader ExecuteDataReader(string NomeProcedure)
        {
            try
            {
                command.CommandText = NomeProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlParameters.ToArray());
                command.Connection.Open();
                return command.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlParameters.Clear();
            }
        }

        public int ExecuteNonQuery(string NomeProcedure)
        {

            try
            {
                command.CommandText = NomeProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlParameters.ToArray());
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlParameters.Clear();
            }

        }

        public object ExecuteScalar(string NomeProcedure)
        {
            try
            {
                command.CommandText = NomeProcedure;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddRange(sqlParameters.ToArray());
                command.Connection.Open();
                return command.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlParameters.Clear();
            }
        }
    }
}
