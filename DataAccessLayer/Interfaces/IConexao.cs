using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

namespace DataAccessLayer.Interfaces
{
    public interface IConexao
    {
        void AdicionaParametro(string NomeParametro, int Valor);
        void AdicionaParametro(string NomeParametro, int? Valor);
        void AdicionaParametro(string NomeParametro, string Valor);
        void AdicionaParametro(string NomeParametro, bool Valor);
        void AdicionaParametro(string NomeParametro, bool? Valor);
        SqlDataReader ExecuteDataReader(string NomeProcedure);
        int ExecuteNonQuery(string NomeProcedure);
        object ExecuteScalar(string NomeProcedure);
    }
}
