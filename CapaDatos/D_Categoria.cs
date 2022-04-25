using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class D_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Categoria> ListarCategorias(string buscar)
        {
            SqlDataReader leerFilas;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leerFilas = cmd.ExecuteReader();

            List<E_Categoria> Listar = new List<E_Categoria>();
            while(leerFilas.Read())
            {
                Listar.Add(new E_Categoria
                {
                IdCategoria = leerFilas.GetInt32(0),
                CodigoCategoria = leerFilas.GetString(1),
                Nombre = leerFilas.GetString(2),
                Descripcion = leerFilas.GetString(3)
            }); 
            }
            conexion.Close();
            leerFilas.Close();
            return Listar;
        }

        public void InsertarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", categoria.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void EditarCategoria(E_Categoria categoria) {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCategoria);
            cmd.Parameters.AddWithValue("@NOMBRE", categoria.Nombre);
            cmd.Parameters.AddWithValue("@DESCRIPCION", categoria.Descripcion);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public void EliminarCategoria(E_Categoria categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", categoria.IdCategoria);
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

    }
}
