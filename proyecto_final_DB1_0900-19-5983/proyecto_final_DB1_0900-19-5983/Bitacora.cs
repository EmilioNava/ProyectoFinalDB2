using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proyecto_final_DB1_0900_19_5983
{
    public partial class Bitacora : Form
    {
        public Bitacora()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inicio salto = new inicio();
            this.Close();
            salto.Show();
        }

        private void Bitacora_Load(object sender, EventArgs e)
        {
            carga_masiva();
        }

        public void cargar_log1()
        {
            SqlCommand com = new SqlCommand("exec ver_bitacora_usuario", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.desconectarDB();
        }
        public void cargar_log2()
        {
            SqlCommand com = new SqlCommand("exec ver_bitacora_producto", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            conexion.desconectarDB();
        }
        public void cargar_log3()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_bitacora_usuario_favorito_log", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            conexion.desconectarDB();
        }
        public void cargar_log4()
        {
            SqlCommand com = new SqlCommand("exec ver_bitacora_anuncio_log", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            conexion.desconectarDB();
        }
        public void cargar_log5()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_bitacora_calificacion_log", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            conexion.desconectarDB();
        }
        public void cargar_log6()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_bitacora_orden_log", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView6.DataSource = dt;
            conexion.desconectarDB();
        }
        public void cargar_log7()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_bitacora_orden_detalle_log", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView8.DataSource = dt;
            conexion.desconectarDB();
        }

        public void carga_masiva()
        {
            cargar_log1();
            cargar_log2();
            cargar_log3();
            cargar_log4();
            cargar_log5();
            cargar_log6();
            cargar_log7();
        }
    }
}
