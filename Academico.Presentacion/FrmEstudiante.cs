using Academico.Entidad;
using Academico.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Academico.Presentacion
{
    public partial class FrmEstudiante : Form
    {
        public FrmEstudiante()
        {
            InitializeComponent();
        }

        EstudianteNegocio objNegocio = new EstudianteNegocio();
        Estudiante objEstudiante = new Estudiante();
        private void FrmEstudiante_Load(object sender, EventArgs e)
        {

        }

        void Limpiar()
        {
            foreach (Control c in Controls)
                c.Text = "";
        }
        bool Validar(String p1,string p2, String p3)
        {
            if (p1.Length == 0 || p2.Length == 0 || p3.Length == 0)
                return false;
            else
                return true;
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text == string.Empty)
            {
                dataEstudiante.DataSource = objNegocio.ListarEstudiante();
            }
            else
            {
                dataEstudiante.DataSource = objNegocio.ListarEstudianteXNombre(txtBuscar.Text);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            if(Validar (txtNum_Doc.Text, txtNombres.Text, txtEmail.Text) == true)
            {
                objEstudiante.Num_doc = txtNum_Doc.Text;
                objEstudiante.Nombres = txtNombres.Text;
                objEstudiante.Email = txtEmail.Text;
                objEstudiante.Estado = (this.checkEstado.Checked == true) ? true : false;
                try
                {
                    objNegocio.Agregar(objEstudiante);
                    MessageBox.Show("Se ha registrado un nuevo estudiante");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar los Datos");
            }
        }

        private void dataEstudiante_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataEstudiante.CurrentRow.Cells[0].Value.ToString();
            txtNum_Doc.Text = dataEstudiante.CurrentRow.Cells[1].Value.ToString();
            txtNombres.Text = dataEstudiante.CurrentRow.Cells[2].Value.ToString();
            txtEmail.Text = dataEstudiante.CurrentRow.Cells[3].Value.ToString();
            if (dataEstudiante.CurrentRow.Cells[4].Value is true)
            {
                this.checkEstado.Checked = true;
            }
            else
            {
                this.checkEstado.Checked = false;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            if (Validar(txtNum_Doc.Text, txtNombres.Text, txtEmail.Text) == true)
            {
                objEstudiante = objNegocio.Buscar(Convert.ToInt32(txtId.Text));
                objEstudiante.Num_doc = txtNum_Doc.Text;
                objEstudiante.Nombres = txtNombres.Text;
                objEstudiante.Email = txtEmail.Text;
                objEstudiante.Estado = (this.checkEstado.Checked == true) ? true : false;
                try
                {
                    objNegocio.Actualizar(objEstudiante);
                    MessageBox.Show("Se ha actualizado el Estudiante");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Primero Selecione el registro que desee Actulaizar");
            }
            
        }
        
    }
}
