using AdminAuto.BLL;
using AdminAuto.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminAuto.PL
{
    public partial class frmOficina : Form
    {

        OficinaDAL oficinaDAL;
        public frmOficina()
        {
            oficinaDAL = new OficinaDAL();
            InitializeComponent();
            LlenarGrid();
        }

        public void LlenarGrid()
        {
            dvgOficinas.DataSource = oficinaDAL.MostrarOficinas().Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAnio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAsientos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbxOficina_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmOficina_Load(object sender, EventArgs e)
        {

        }
    }
}
