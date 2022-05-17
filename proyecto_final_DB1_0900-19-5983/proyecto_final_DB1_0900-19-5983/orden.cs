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
    public partial class orden : Form
    {
        
        bool bandera = false;
        public orden()
        {
            InitializeComponent();
        }

        private void orden_Load(object sender, EventArgs e)
        {
            carga_masiva();
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
        public void cargar_combo_estado()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_estado_orden, estado_actual FROM estado_orden", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["estado_actual"] = "Seleccione...";
            dt.Rows.InsertAt(fila, 0);
            comboBox2.ValueMember = "id_estado_orden";
            comboBox2.DisplayMember = "estado_actual";
            comboBox2.DataSource = dt;
        }


        public void cargar_combo_id()
        {
            comboBox1.Enabled = false;
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_orden FROM orden", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            comboBox1.ValueMember = "id_orden";
            comboBox1.DisplayMember = "id_orden";
            comboBox1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int producto, estado;
            estado = int.Parse(comboBox2.SelectedValue.ToString());
            producto = int.Parse(comboBox3.SelectedValue.ToString());
            conexion.ConectarDB();
            SqlCommand come = new SqlCommand("EXEC sp_insertar_orden '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + estado + "','"+producto+"'", conexion.ConectarDB());
            come.ExecuteNonQuery();
            MessageBox.Show("funciono");
            carga_masiva();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                MessageBox.Show("SELECCIONE EL ID DE LA ORDEN QUE DESEA MODIFICAR Y MODIFIQUE LOS DATOS QUE DESEA");
                bandera = true;
                comboBox1.Enabled = true;
                button1.Enabled = false;
            }
            else if (bandera == true)
            {
                int estado, producto, id;
                estado = int.Parse(comboBox2.SelectedValue.ToString());
                producto = int.Parse(comboBox3.SelectedValue.ToString());
                id = int.Parse(comboBox1.SelectedValue.ToString());
                conexion.ConectarDB();
                SqlCommand come = new SqlCommand("EXEC sp_update_orden '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + estado + "','" + producto + "','" + id + "'", conexion.ConectarDB());
                come.ExecuteNonQuery();
                MessageBox.Show("funciono");
                verTodo();
                comboBox1.Enabled = false;
                button1.Enabled = true;
                bandera = false;
                carga_masiva();
            }
        }
        public void verTodo()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_orden", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.desconectarDB();
        }

        public void carga_masiva()
        {
            verTodo();
            cargar_combo_producto();
            cargar_combo_estado();
            cargar_combo_id();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            inicio salto = new inicio();
            this.Close();
            salto.Show();
        }
    }
}
