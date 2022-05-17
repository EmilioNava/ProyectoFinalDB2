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
    public partial class Form3 : Form
    {
        
        bool bandera = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cargar_masiva();
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
        public void cargar_combo_id()
        {
            comboBox3.Enabled = false;
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_producto_usuario_favorito FROM producto_usuario_favorito", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            comboBox3.ValueMember = "id_producto_usuario_favorito";
            comboBox3.DisplayMember = "id_producto_usuario_favorito";
            comboBox3.DataSource = dt;
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
            comboBox1.ValueMember = "id_producto";
            comboBox1.DisplayMember = "nombre_producto";
            comboBox1.DataSource = dt;
        }

        //AGREGAR
        private void button1_Click(object sender, EventArgs e)
        {
            int usuario, producto;
            usuario = int.Parse(comboBox2.SelectedValue.ToString());
            producto = int.Parse(comboBox1.SelectedValue.ToString());
            conexion.ConectarDB();
            SqlCommand come = new SqlCommand("EXEC sp_insertar_producto_favorito '" + textBox1.Text + "','" + producto + "','" + usuario + "'", conexion.ConectarDB());
            come.ExecuteNonQuery();
            MessageBox.Show("funciono");
            verTodo();
            cargar_masiva();
        }

        public void cargar_masiva()
        {
            cargar_combo_producto();
            cargar_combo_usuario();
            verTodo();
            cargar_combo_id();
        }

        public void verTodo()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_producto_favorito", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.desconectarDB();
        }
        //editar
        private void button2_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                MessageBox.Show("SELECCIONE EL ID DEL USUARIO QUE DESEA MODIFICAR Y MODIFIQUE LOS DATOS QUE DESEA");
                bandera = true;
                comboBox3.Enabled = true;
                button1.Enabled = false;
            }
            else if (bandera == true)
            {
                int usuario, producto, id;
                usuario = int.Parse(comboBox2.SelectedValue.ToString());
                producto = int.Parse(comboBox1.SelectedValue.ToString());
                id = int.Parse(comboBox3.SelectedValue.ToString());
                conexion.ConectarDB();
                SqlCommand come = new SqlCommand("EXEC sp_update_producto_favorito '" + textBox1.Text + "','" + producto + "','" + usuario + "','"+id+"'", conexion.ConectarDB());
                come.ExecuteNonQuery();
                MessageBox.Show("funciono");
                verTodo();
                comboBox3.Enabled = false;
                button1.Enabled = true;
                bandera = false;
                cargar_masiva();

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            inicio salto = new inicio();
            this.Close();
            salto.Show();
        }
    }
}
