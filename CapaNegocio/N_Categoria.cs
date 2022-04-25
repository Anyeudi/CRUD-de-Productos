using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CapaEntidad;
using CapaDatos;


namespace CapaNegocio
{
    public class N_Categoria
    {
        D_Categoria objDato = new D_Categoria();
        public List<E_Categoria> ListarCategoria (string buscar)
        {
            return objDato.ListarCategorias(buscar);
        }

        public void InsertandoCategoria(E_Categoria Categoria)
        {
            objDato.InsertarCategoria(Categoria);
        }
        public void EditandoCategoria(E_Categoria Categoria)
        {
            objDato.EditarCategoria(Categoria);
        }
        
        public void EliminandoCategoria (E_Categoria categoria)
        {
            objDato.EliminarCategoria(categoria);
        }
    }
}