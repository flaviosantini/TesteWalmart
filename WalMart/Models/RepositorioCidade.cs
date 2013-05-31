using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Walmart.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using System.Data.SqlClient;
using System.Data;

namespace Walmart.Models
{
    public class RepositorioCidade : IRepository<Cidade>
    {
        private readonly IConexao conexao;

        public RepositorioCidade(string connString)
        {
            conexao = new Conexao(connString);
        }

        public bool Adiciona(Cidade entity)
        {
            AdicionaParametros(entity);
            return conexao.ExecuteNonQuery("CIDADE_INSERE") == 1 ? true : false;
        }

        public bool Atualiza(Cidade entity)
        {
            AdicionaParametros(entity);
            return conexao.ExecuteNonQuery("CIDADE_ATUALIZA") == 1 ? true : false;
        }

        public bool Deleta(int Id)
        {
            conexao.AdicionaParametro("COD_CIDADE", Id);
            return conexao.ExecuteNonQuery("CIDADE_DELETA") == 1 ? true : false;
        }

        public Cidade Seleciona(Cidade entity)
        {
            conexao.AdicionaParametro("COD_CIDADE", entity.CodCidade);
            SqlDataReader reader = conexao.ExecuteDataReader("CIDADE_SELECIONA");

            if (reader.Read())
            {
                entity.CodCidade = Convert.ToInt32(reader["COD_CIDADE"].ToString());
                entity.CodEstado = Convert.ToInt32(reader["COD_ESTADO"].ToString());
                entity.Nome = reader["NOME"].ToString();
                entity.Capital = Convert.ToBoolean(reader["IC_CAPITAL"]);
            }
            return entity;
        }

        public List<Cidade> Lista()
        {
            SqlDataReader reader = conexao.ExecuteDataReader("CIDADE_LISTA");
            List<Cidade> retorno = new List<Cidade>();

            while (reader.Read())
            {
                Cidade entidade = new Cidade();
                entidade.CodCidade = Convert.ToInt32(reader["COD_CIDADE"].ToString());
                entidade.CodEstado = Convert.ToInt32(reader["COD_ESTADO"].ToString());
                entidade.Nome = reader["NOME"].ToString();
                entidade.Capital = Convert.ToBoolean(reader["IC_CAPITAL"]);
                retorno.Add(entidade);
            }

            return retorno;
        }

        private void AdicionaParametros(Cidade entity)
        {
            conexao.AdicionaParametro("COD_CIDADE", entity.CodCidade);
            conexao.AdicionaParametro("COD_ESTADO", entity.CodEstado);
            conexao.AdicionaParametro("NOME", entity.Nome);
            conexao.AdicionaParametro("IC_CAPITAL", entity.Capital);
        }

    }
}