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
    public partial class detalle_orden : Form
    {
        public detalle_orden()
        {
            InitializeComponent();
        }
        
        bool bandera = false;

        private void button3_Click(object sender, EventArgs e)
        {
            inicio salto = new inicio();
            this.Close();
            salto.Show();
        }

        private void detalle_orden_Load(object sender, EventArgs e)
        {
            carga_masiva();
        }

        public void cargar_combo_id()
        {
            comboBox1.Enabled = false;
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_orden_detalle FROM orden_detalle", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            comboBox1.ValueMember = "id_orden_detalle";
            comboBox1.DisplayMember = "id_orden_detalle";
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
        public void cargar_combo_orden()
        {
            comboBox1.Enabled = false;
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_orden FROM orden", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            comboBox3.ValueMember = "id_orden";
            comboBox3.DisplayMember = "id_orden";
            comboBox3.DataSource = dt;
        }
        public void verTodo()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_orden_detalle", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.desconectarDB();
        }

        public void carga_masiva()
        {
            verTodo();
            cargar_combo_orden();
            cargar_combo_usuario();
            cargar_combo_id();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int usuario, orden;
            usuario = int.Parse(comboBox2.SelectedValue.ToString());
            orden = int.Parse(comboBox3.SelectedValue.ToString());
            conexion.ConectarDB();
            SqlCommand come = new SqlCommand("EXEC sp_insertar_orden_detalle '" + usuario+ "','" + orden + "'", conexion.ConectarDB());
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
                int usuario, orden, id;
                usuario = int.Parse(comboBox2.SelectedValue.ToString());
                orden = int.Parse(comboBox3.SelectedValue.ToString());
                id = int.Parse(comboBox1.SelectedValue.ToString());
                conexion.ConectarDB();
                SqlCommand come = new SqlCommand("EXEC sp_update_orden_detalle '" + usuario+ "','" + orden + "','" + id + "'", conexion.ConectarDB());
                come.ExecuteNonQuery();
                MessageBox.Show("funciono");
                verTodo();
                comboBox1.Enabled = false;
                button1.Enabled = true;
                bandera = false;
                carga_masiva();
            }
        }
    }
}
