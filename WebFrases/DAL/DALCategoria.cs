using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebFrases.MODELO;

namespace WebFrases.DAL
{
    public class DALCategoria
    {
        private System.Configuration.ConnectionStringSettings connString;

        public DALCategoria()
        {
            System.Configuration.Configuration rootWebConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
           
            connString = rootWebConfig.ConnectionStrings.ConnectionStrings["sisfrases4ConnectionString"];
        }

        public void Inserir(MODELO.Categoria obj)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = this.connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "Insert into CATEGORIA (categoria) values (@categoria);select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@categoria", obj.Nome);
                con.Open();
                obj.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Alterar(MODELO.Categoria obj)
        {
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "update categoria set categoria=@categoria where id = @id;";
                cmd.Parameters.AddWithValue("categoria", obj.Nome);
                cmd.Parameters.AddWithValue("id", obj.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void Excluir(int cod)
        {
            //cria um objeto de conexão
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = con;
                cmd.CommandText = "delete from categoria where id = " + cod.ToString();
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public DataTable Localizar()
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from categoria", connString.ConnectionString);
            try
            {
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public DataTable Localizar(String valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from categoria where categoria like '%" +
                valor + "%'", connString.ConnectionString);
            try
            {
                da.Fill(tabela);
                return tabela;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public MODELO.Categoria GetRegistro(int id)
        {
            MODELO.Categoria obj = new MODELO.Categoria();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connString.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            try
            {
                cmd.CommandText = "select * from categoria where id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader registro = cmd.ExecuteReader();
                if (registro.HasRows)
                {
                    registro.Read();
                    obj.Id = Convert.ToInt32(registro["id"]);
                    obj.Nome = Convert.ToString(registro["categoria"]);
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            return obj;
        }
    }
}
    