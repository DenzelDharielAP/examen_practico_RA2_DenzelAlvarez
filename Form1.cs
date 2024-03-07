    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace examen_practico_RA2_DenzelAlvarez
    {

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        public class Estudiante
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public string Seccion { get; set; }
        public string Area { get; set; }
        public string Maestro { get; set; }
    }


            private void btnNuevo_Click(object sender, EventArgs e)
            {
                Nuevo();
            }

            private void btnGuardar_Click(object sender, EventArgs e)
            {
                Guardar();
            }

            private void btnAgregar_Click(object sender, EventArgs e)
            {
                Agregar();
            }

            private void btnSalir_Click(object sender, EventArgs e)
            {
                Salir();
            }

            private void btnEliminar_Click(object sender, EventArgs e)
            {

                Eliminar();
            
            }

            private void Nuevo()
            {
                dgvDatos.Rows.Clear();

                btnGuardar.Enabled = true;
                btnEliminar.Enabled = false;

                txtDireccion.Enabled = true;
                txtEmail.Enabled = true;
                txtMatricula.Enabled = true;
                txtNombre.Enabled = true;
                txtTelefono.Enabled = true;
                txtMaestro.Enabled = true;

                cmbAreaTecnica.Enabled = true;
                cmbCurso.Enabled = true;
                cmbSeccion.Enabled = true;

                dgvDatos.Enabled = true;

                rbtnFemenino.Enabled = true;
                rbtnMasculino.Enabled = true;

                btnNuevo.Enabled = false;

            txtDireccion.Clear();
            txtEmail.Clear();
            txtMaestro.Clear();
            txtMatricula.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();

            cmbAreaTecnica.ResetText();
            cmbCurso.ResetText();
            cmbSeccion.ResetText();

            rbtnFemenino.Checked = false;
            rbtnMasculino.Checked = false;

        }

            private void Guardar()
            {
                btnEliminar.Enabled = true;
                btnNuevo.Enabled = true;
                btnGuardar.Enabled = false;

                string path = @"C:\Users\megator\source\repos\examen_practico_RA2_DenzelAlvarez\archivo.txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (DataGridViewRow row in dgvDatos.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string matricula = row.Cells[0].Value?.ToString() ?? "";
                            string nombre = row.Cells[1].Value?.ToString() ?? "";
                            string curso = row.Cells[6].Value?.ToString() ?? "";
                            string seccion = row.Cells[7].Value?.ToString() ?? "";
                            string areaTecnica = row.Cells[8].Value?.ToString() ?? "";

                            sw.WriteLine($"{matricula}\t{nombre}\t{curso}\t{seccion}\t{areaTecnica}");

                        }
                    }
                }
                
                MessageBox.Show("Datos guardados en archivo.txt");
            }

            private void Agregar()
            {
                btnGuardar.Enabled = true;

                Estudiante estudiante = new Estudiante(); 

                estudiante.Matricula = Convert.ToInt32(txtMatricula.Text);

                estudiante.Nombre = txtNombre.Text;
                estudiante.Direccion = txtDireccion.Text;
                estudiante.Telefono = txtTelefono.Text;
                estudiante.Email = txtEmail.Text;
                estudiante.Maestro = txtMaestro.Text;

                estudiante.Area = cmbAreaTecnica.SelectedItem.ToString();
                estudiante.Curso = cmbCurso.SelectedItem.ToString();
                estudiante.Seccion = cmbSeccion.SelectedItem.ToString();

                if (rbtnFemenino.Checked)
                {
                    estudiante.Genero = rbtnFemenino.Text;
                }

                else
                {
                    estudiante.Genero = rbtnMasculino.Text;
                }



                dgvDatos.Rows.Add(estudiante.Matricula, estudiante.Nombre, estudiante.Direccion, estudiante.Telefono, estudiante.Genero, estudiante.Email, estudiante.Curso, estudiante.Seccion, estudiante.Area, estudiante.Maestro);

                txtDireccion.Clear();
                txtEmail.Clear();
                txtMaestro.Clear();
                txtMatricula.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();

                cmbAreaTecnica.ResetText();
                cmbCurso.ResetText();
                cmbSeccion.ResetText();

                rbtnFemenino.Checked = false;
                rbtnMasculino.Checked = false;

            }

            private void Eliminar()
            {
                DialogResult eliminar = MessageBox.Show("¿Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (eliminar == DialogResult.Yes)
                {
                    int indice = dgvDatos.SelectedRows[0].Index;
                    dgvDatos.Rows.RemoveAt(indice);
                }

            }

        private void Salir()
        {
            DialogResult salir = MessageBox.Show("¿Desea salir de la aplicación?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (salir == DialogResult.Yes)
            {
                Close();
            }
        }

        }

        }

