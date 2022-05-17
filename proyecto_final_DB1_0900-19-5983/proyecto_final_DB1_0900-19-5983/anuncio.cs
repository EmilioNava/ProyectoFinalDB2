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
    public partial class anuncio : Form
    {
        
        bool bandera = false;
        public anuncio()
        {
            InitializeComponent();
        }

        private void anuncio_Load(object sender, EventArgs e)
        {
            carga_masiva();
        }
        
        public void cargar_combo_id()
        {
            comboBox1.Enabled = false;
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_anuncio, titulo FROM anuncio", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
           conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["titulo"] = "Seleccione...";
            dt.Rows.InsertAt(fila, 0);
            comboBox1.ValueMember = "id_anuncio";
            comboBox1.DisplayMember = "titulo";
            comboBox1.DataSource = dt;
        }

        public void cargar_combo_usuario()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_usuario, nombre_usuario FROM usuario", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
           conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["nombre_usuario"] = "Seleccione el ID";
            dt.Rows.InsertAt(fila, 0);
            comboBox2.ValueMember = "id_usuario";
            comboBox2.DisplayMember = "nombre_usuario";
            comboBox2.DataSource = dt;
        }

        public void cargar_combo_producto()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_producto, nombre_producto FROM producto", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
           conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["nombre_producto"] = "Seleccione...";
            dt.Rows.InsertAt(fila, 0);
            comboBox3.ValueMember = "id_producto";
            comboBox3.DisplayMember = "nombre_producto";
            comboBox3.DataSource = dt;
        }
        public void verTodo()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_anuncio", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
           conexion.desconectarDB();
        }


        public void carga_masiva()
        {
            verTodo();
            cargar_combo_id();
            cargar_combo_producto();
            cargar_combo_usuario();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int usuario, producto;
            usuario = int.Parse(comboBox2.SelectedValue.ToString());
            producto = int.Parse(comboBox3.SelectedValue.ToString());
            conexion.ConectarDB();
            SqlCommand come = new SqlCommand("EXEC sp_insertar_anuncio '" + textBox1.Text + "','" + textBox2.Text + "','" + usuario + "','" + producto + "'", conexion.ConectarDB());
            come.ExecuteNonQuery();
            MessageBox.Show("funciono");
            carga_masiva();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                MessageBox.Show("SELECCIONE EL ID DEL ANUNCIO QUE DESEA MODIFICAR Y MODIFIQUE LOS DATOS QUE DESEA");
                bandera = true;
                comboBox1.Enabled = true;
                button1.Enabled = false;
            }
            else if (bandera == true)
            {
                int usuario, producto, id;
                usuario = int.Parse(comboBox2.SelectedValue.ToString());
                producto = int.Parse(comboBox3.SelectedValue.ToString());
                id = int.Parse(comboBox1.SelectedValue.ToString());
                conexion.ConectarDB();
                SqlCommand come = new SqlCommand("EXEC sp_update_anuncio '"+ textBox1.Text + "','" + textBox2.Text + "','" + producto + "','" + usuario + "','" + id + "'", conexion.ConectarDB());
                come.ExecuteNonQuery();
                MessageBox.Show("funciono");
                verTodo();
                comboBox1.Enabled = false;
                button1.Enabled = true;
                bandera = false;
                carga_masiva();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            inicio salto = new inicio();
            this.Close();
            salto.Show();
        }
    }
}
