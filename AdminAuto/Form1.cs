using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminAuto.PL;

namespace AdminAuto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAuto formularioAuto = new frmAuto();
            formularioAuto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOficina formularioOfi = new frmOficina();
            formularioOfi.Show();
        }
    }
}
