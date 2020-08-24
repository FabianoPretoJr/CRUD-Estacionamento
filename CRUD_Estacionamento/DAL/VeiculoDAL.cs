using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_Estacionamento.DAL
{
    public class VeiculoDAL
    {
        Conexao con = new Conexao();

        public void Cadastrar(BLL.Veiculo ve)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();

            cmd.CommandText = @"INSERT INTO TBVeiculo(Placa, Fabricante, Modelo) VALUES (@placa, @fabricante, @modelo)";
            cmd.Parameters.AddWithValue("@placa", ve.Placa);
            cmd.Parameters.AddWithValue("@fabricante", ve.Fabricante);
            cmd.Parameters.AddWithValue("@modelo", ve.Modelo);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id, Placa, Fabricante, Modelo FROM TBVeiculo";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public DataTable Listar(BLL.Veiculo ve)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id, Placa, Fabricante, Modelo FROM TBVeiculo WHERE Placa LIKE @placa";

            cmd.Parameters.AddWithValue("@placa", "%" + ve.Placa + "%");

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Desconectar();
            return dt;
        }

        public void Excluir(BLL.Veiculo ve)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"DELETE FROM TBVeiculo WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", ve.Id);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Veiculo PreencherPeliID(BLL.Veiculo ve)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT Id, Placa, Fabricante, Modelo FROM TBVeiculo WHERE  Id = @id";
            cmd.Parameters.AddWithValue("@id", ve.Id);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                dr.Read();
                ve.Id = Convert.ToInt32(dr["Id"]);
                ve.Placa = dr["Placa"].ToString();
                ve.Fabricante = dr["fabricante"].ToString();
                ve.Modelo = dr["Modelo"].ToString();
                dr.Close();
            }
            else
            {
                ve.Id = 0;
            }

            con.Desconectar();
            return ve;
        }

        public void Atualizar(BLL.Veiculo ve)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE TBVeiculo SET Placa = @placa, Fabricante = @fabricante, Modelo = @modelo WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", ve.Id);
            cmd.Parameters.AddWithValue("@placa", ve.Placa);
            cmd.Parameters.AddWithValue("@fabricante", ve.Fabricante);
            cmd.Parameters.AddWithValue("@modelo", ve.Modelo);

            cmd.ExecuteNonQuery();
            con.Desconectar();
        }
    }
}