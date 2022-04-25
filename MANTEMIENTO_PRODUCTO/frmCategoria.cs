using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaEntidad;


namespace MANTEMIENTO_PRODUCTO
{
    public partial class frmCategoria : Form
    {
        private string idcategoria;
        private bool Editarse = false;

        E_Categoria objEntidad = new E_Categoria();
        N_Categoria objNegocio = new N_Categoria();
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
            accionesTabla();
        }
        public void accionesTabla()
        {
            tablaCategoria.Columns[0].Visible = false;
            tablaCategoria.Columns[1].Width = 60;
            tablaCategoria.Columns[2].Width = 170;

            tablaCategoria.ClearSelection();

        }

        public void mostrarBuscarTabla(string buscar)
        {
            N_Categoria objNegocio = new N_Categoria();
            tablaCategoria.DataSource = objNegocio.ListarCategoria(buscar);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void limpiarCaja()
        {
            Editarse = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCaja();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(tablaCategoria.SelectedRows.Count > 0)
            {
                Editarse = true;
                idcategoria = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione la fila que desea editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(Editarse == false)
            {
                try
                {
                    objEntidad.Nombre = txtNombre.Text.ToUpper();
                    objEntidad.Descripcion = txtDescripcion.Text.ToUpper();

                    objNegocio.InsertandoCategoria(objEntidad);

                    MessageBox.Show("El registro se ha guardado satisfactoriamente");
                    mostrarBuscarTabla("");
                    limpiarCaja();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el registro" + ex);
                }
            }
            if (Editarse == true)
            {
                try
                {
                    objEntidad.IdCategoria = Convert.ToInt32(idcategoria);
                    objEntidad.Nombre = txtNombre.Text.ToUpper();
                    objEntidad.Descripcion = txtDescripcion.Text.ToUpper();

                    objNegocio.InsertandoCategoria(objEntidad);

                    MessageBox.Show("El registro se ha editado satisfactoriamente");
                    mostrarBuscarTabla("");
                    limpiarCaja();
                    Editarse = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar el registro" + ex);
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(tablaCategoria.SelectedRows.Count > 0)
            {
                objEntidad.IdCategoria = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocio.EliminandoCategoria(objEntidad);

                MessageBox.Show("El registro se ha eliminado satisfactoriamente");
                mostrarBuscarTabla("");
            }else
            {
                MessageBox.Show("Selecciona la fila que deseas eliminar");
            }
        }

        private void tablaCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void topFormulario_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbnDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
