using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_final_DB1_0900_19_5983
{
    public partial class inicio : Form
    {
        public inicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 salto = new Form1();
            salto.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 salto = new Form2();
            salto.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 salto = new Form3();
            salto.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anuncio salto = new anuncio();
            salto.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            calificacion salto = new calificacion();
            salto.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            orden salto = new orden();
            salto.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            detalle_orden salto = new detalle_orden();
            salto.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Bitacora salto = new Bitacora();
            salto.Show();
            this.Hide();
        }
    }
}
