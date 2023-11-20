using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminAuto.DAL;
using AdminAuto.BLL;


namespace AdminAuto.PL
{
    public partial class frmAuto : Form
    {
        AutosDAL autosDAL;
        public frmAuto()
        {
            autosDAL = new AutosDAL(); 
            InitializeComponent();
            LlenarGrid();
            LimpiarEntradas();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

           if( string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text) || string.IsNullOrEmpty(txtPlaca.Text) || string.IsNullOrEmpty(txtAsientos.Text) || string.IsNullOrEmpty(txtAnio.Text))
           {
                MessageBox.Show("Complete todos los datos");
           }else
            {
                //Agregar las acciones de Agregar
                bool response = autosDAL.Agregar(RecuperarInformacion());
                if (response == true)
                {
                    MessageBox.Show("Auto Registrado");
                }
                else
                {
                    MessageBox.Show("Placa Ya Existente");
                }
                LlenarGrid();
                LimpiarEntradas();
            }
            

            
        }

        private AutosBLL RecuperarInformacion()
        {

            AutosBLL autosBLL = new AutosBLL();
            int ID = 0; int.TryParse(txtId.Text, out ID);
            int Asnt = 0; int.TryParse(txtAsientos.Text, out Asnt);
            int An = 0; int.TryParse(txtAnio.Text, out An);
            int ofi = 0; int.TryParse(cbxOficina.SelectedValue.ToString(), out ofi);
            autosBLL.ID = ID;
            autosBLL.Placa = txtPlaca.Text;
            autosBLL.Marca = txtMarca.Text;
            autosBLL.Modelo = txtModelo.Text;
            autosBLL.Num_asientos = Asnt;
            autosBLL.Anio = An;
            autosBLL.Oficina = ofi;

            return autosBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            txtId.Text = dvgAutos.Rows[indice].Cells[0].Value.ToString();
            txtPlaca.Text = dvgAutos.Rows[indice].Cells[1].Value.ToString();
            txtMarca.Text = dvgAutos.Rows[indice].Cells[2].Value.ToString();
            txtModelo.Text = dvgAutos.Rows[indice].Cells[3].Value.ToString();
            txtAsientos.Text = dvgAutos.Rows[indice].Cells[4].Value.ToString();
            txtAnio.Text = dvgAutos.Rows[indice].Cells[5].Value.ToString();
            cbxOficina.SelectedValue = dvgAutos.Rows[indice].Cells[7].Value.ToString(); //cbx

            btnAgregar.Enabled = false;
            btnModificar.Enabled = true;
            btnBorrar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            autosDAL.Eliminar(RecuperarInformacion());
            MessageBox.Show("Auto Eliminado");
            LlenarGrid();
            LimpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            autosDAL.Modificar(RecuperarInformacion());
            MessageBox.Show("Auto Modificado");
            LlenarGrid();
            LimpiarEntradas();
        }

        public void LimpiarEntradas()
        {
            txtId.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtAsientos.Text = "";
            txtAnio.Text = "";
            txtPlaca.Text = "";
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnBorrar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        public void LlenarGrid()
        {
            dvgAutos.DataSource = autosDAL.MostrarAutos().Tables[0];
            dvgAutos.Columns[7].Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }

        private void frmAuto_Load(object sender, EventArgs e)
        {
            OficinaDAL oficinaDAL = new OficinaDAL();
            cbxOficina.DataSource = oficinaDAL.MostrarOficinas().Tables[0];
            cbxOficina.DisplayMember = "Ciudad";
            cbxOficina.ValueMember = "ID_Oficina";

            cbxTipo.Items.Add("Marca");
            cbxTipo.Items.Add("Año_Fabricación");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tip = cbxTipo.Text;
            string var = txtValor.Text;

            if(tip == "" || var == "")
            {
                MessageBox.Show("Complete los datos para la busqueda");
            }else
            {
                dvgAutos.DataSource = autosDAL.BuscarAuto(tip, var).Tables[0];
            }
            

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dvgAutos.DataSource = autosDAL.MostrarAutos().Tables[0];
            cbxTipo.SelectedIndex = -1;
            txtValor.Text = "";
        }
    }
}
