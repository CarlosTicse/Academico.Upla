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
    public partial class FrmDocente : Form
    {
        public FrmDocente()
        {
            InitializeComponent();
        }


        DocenteNegocio objNegocio = new DocenteNegocio();
        Docente objDocente = new Docente();

        private void FrmDocente_Load(object sender, EventArgs e)
        {
            // Obtener la fecha y hora actual
            DateTime fechaHoraActual = DateTime.Now;

            // Formatear la fecha y hora en el formato deseado
            string fechaHoraFormateada = fechaHoraActual.ToString("dd-MM-yyyy h:mm tt");

            // Asignar la fecha y hora formateada al TextBox
            txtFechaHora.Text = fechaHoraFormateada;
        }

        void Limpiar(Control control)
        {
            foreach (Control c in control.Controls)
            {
                // Si el control actual es un TextBox, establece su texto en una cadena vacía.
                if (c is TextBox)
                {
                    TextBox textBox = (TextBox)c;
                    textBox.Text = "";
                }
                else if (c is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                // Si el control actual es un panel u otro contenedor, llama recursivamente a Limpiar().
                else if (c.HasChildren)
                {
                    Limpiar(c);
                }
            }
        }
        bool Validar(string p1, string p2, string p3, string p4, string p5, string p6)
        {
            if (p1.Length == 0 || p2.Length == 0 || p3.Length == 0 || p4.Length == 0 || p5.Length == 0 || p6.Length == 0)
                return false;
            else
                return true;
        }
        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            FrmEstudiante formularioE = new FrmEstudiante();
            formularioE.Show();

            this.Hide();
        }

        private void btnListar_Click_1(object sender, EventArgs e)
        {
            if (txtBuscar.Text == string.Empty)
            {
                dataDocente.DataSource = objNegocio.ListarDocente();
            }
            else
            {
                dataDocente.DataSource = objNegocio.ListarDocenteXNombre(txtBuscar.Text);
            }
        }

        private void dataDocente_CellContentDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataDocente.CurrentRow.Cells[0].Value.ToString();
            txtNum_Doc.Text = dataDocente.CurrentRow.Cells[1].Value.ToString();
            txtNombre.Text = dataDocente.CurrentRow.Cells[2].Value.ToString();
            txtApellido.Text = dataDocente.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataDocente.CurrentRow.Cells[4].Value.ToString();
            txtTelefono.Text = dataDocente.CurrentRow.Cells[5].Value.ToString();
            txtFechaHora.Text = dataDocente.CurrentRow.Cells[6].Value.ToString();
            if (dataDocente.CurrentRow.Cells[7].Value is true)
            {
                this.checkEstado.Checked = true;
            }
            else
            {
                this.checkEstado.Checked = false;
            }
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            if (Validar(txtNum_Doc.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text, txtFechaHora.Text) == true)
            {
                objDocente.Num_doc = txtNum_Doc.Text;
                objDocente.Nombre = txtNombre.Text;
                objDocente.Apellido = txtApellido.Text;
                objDocente.Email = txtEmail.Text;
                objDocente.Telefono = txtTelefono.Text;

                DateTime HoraActual = DateTime.Now;

                string FechaActual = HoraActual.ToString("dd/MM/yyyy h:mm tt");

                txtFechaHora.Text = FechaActual;

                objDocente.Fecha_Registro = HoraActual;

                objDocente.Estado = (this.checkEstado.Checked == true) ? true : false;

                try
                {
                    objNegocio.AgregarD(objDocente);
                    MessageBox.Show("Se ha registrado un nuevo Docente");
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
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (Validar(txtNum_Doc.Text, txtNombre.Text, txtApellido.Text, txtEmail.Text, txtTelefono.Text, txtFechaHora.Text) == true)
            {
                objDocente = objNegocio.BuscarD(Convert.ToInt32(txtId.Text));
                objDocente.Num_doc = txtNum_Doc.Text;
                objDocente.Nombre = txtNombre.Text;
                objDocente.Apellido = txtApellido.Text;
                objDocente.Email = txtEmail.Text;
                objDocente.Telefono = txtTelefono.Text;

                DateTime HoraActual = DateTime.Now;

                objDocente.Fecha_Registro = HoraActual;

                objDocente.Estado = (this.checkEstado.Checked == true) ? true : false;
                try
                {
                    objNegocio.ActualizarD(objDocente);
                    MessageBox.Show("Se ha actualizado el Docente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Primero Selecione el registro que desee Actualizar");
            }
        }

        private void FrmDocente_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(this);
        }
    }
}
