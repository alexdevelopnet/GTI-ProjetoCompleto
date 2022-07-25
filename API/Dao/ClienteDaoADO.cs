using API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace API.Dao
{
    public class ClienteDaoADO
    {
        public List<Cliente> Listar()
        {
            SqlConnection con = null;
            List<Cliente> lstCliente = null;

            try
            {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;


                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_L_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader radClientes = cmd.ExecuteReader();
                lstCliente = new List<Cliente>();


                while (radClientes.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = Convert.ToInt32(radClientes["Id"]),
                        Nome = (string)radClientes["Nome"],

                        DataNascimento = Convert.ToDateTime(radClientes["DataNascimento"]),
                        Email = (string)(radClientes["Email"]),
                    };


                    lstCliente.Add(cliente);
                }

            }
            finally
            {
                if (con != null)
                    con.Close();
            }

            return lstCliente;
        }

        public Cliente Obter(int id)
        {
            SqlConnection con = null;
            Cliente cliente = null;

            try
            {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_O_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);

                SqlDataReader radClientes = cmd.ExecuteReader();


                if (radClientes.Read())
                {
                    cliente = new Cliente();

                    cliente.Id = Convert.ToInt32(radClientes["Id"]);
                    cliente.Nome = (string)radClientes["Nome"];
                    cliente.DataNascimento = Convert.ToDateTime(radClientes["DataNascimento"]);
                    cliente.Email = (string)(radClientes["Email"]);
                }

            }
            finally
            {
                if (con != null)
                    con.Close();
            }

            return cliente;
        }

        public int Inserir(Cliente cliente)
        {
            int id;
            SqlConnection con = null;

            try
            {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();


                SqlCommand cmd = new SqlCommand("USP_I_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", Convert.ToDateTime(cliente.DataNascimento));

                cmd.Parameters.AddWithValue("@Email", cliente.Email);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
            return id;
        }

        public void Atualizar(Cliente cliente)
        {
            SqlConnection con = null;

            try
            {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_U_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", cliente.Id);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);

                cmd.Parameters.AddWithValue("@Email", cliente.Email);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }

        public void Excluir(int id)
        {
            SqlConnection con = null;

            try
            {
                string strConexao = ConfigurationManager.ConnectionStrings["conAlex"].ConnectionString;
                con = new SqlConnection(strConexao);
                con.Open();

                SqlCommand cmd = new SqlCommand("USP_D_CLIENTE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (con != null)
                    con.Close();
            }
        }
    }
}