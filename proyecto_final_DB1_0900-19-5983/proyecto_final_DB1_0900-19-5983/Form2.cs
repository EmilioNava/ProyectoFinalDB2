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
    public partial class Form2 : Form
    {
        
        bool bandera = false;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            verTodo();
            cargar_masiva();
        }


        //boton agregar
        private void button1_Click(object sender, EventArgs e)
        {
            int estado,foto,categoria,talla,color;
            estado = int.Parse(comboBox2.SelectedValue.ToString());
            foto = int.Parse(comboBox3.SelectedValue.ToString());
            color = int.Parse(comboBox4.SelectedValue.ToString());
            categoria = int.Parse(comboBox5.SelectedValue.ToString());
            talla = int.Parse(comboBox6.SelectedValue.ToString());
            conexion.ConectarDB();
            SqlCommand come = new SqlCommand("EXEC sp_insertar_producto '" + textBox1.Text + "','" + textBox2.Text + "','" + double.Parse(textBox3.Text) + "','" + estado+ "','" + foto + "','" + categoria + "','" + color + "','"+talla+"'", conexion.ConectarDB());
            come.ExecuteNonQuery();
            MessageBox.Show("funciono");
            verTodo();
            cargar_masiva();
        }


        //boton editar
        private void button2_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                MessageBox.Show("SELECCIONE EL ID DEL USUARIO QUE DESEA MODIFICAR Y MODIFIQUE LOS DATOS QUE DESEA");
                bandera = true;
                comboBox1.Enabled = true;
                button1.Enabled = false; button3.Enabled = false;
            }
            else if (bandera == true)
            {
                int estado, foto, categoria, talla, color,id;
                estado = int.Parse(comboBox2.SelectedValue.ToString());
                foto = int.Parse(comboBox3.SelectedValue.ToString());
                color = int.Parse(comboBox4.SelectedValue.ToString());
                categoria = int.Parse(comboBox5.SelectedValue.ToString());
                talla = int.Parse(comboBox6.SelectedValue.ToString());
                id = int.Parse(comboBox1.SelectedValue.ToString());
                conexion.ConectarDB();
                SqlCommand come = new SqlCommand("EXEC sp_update_producto '" + textBox1.Text + "','" + textBox2.Text + "','" + double.Parse(textBox3.Text) + "','" + estado + "','" + foto + "','" + categoria + "','" + color + "','" + talla + "','"+id+"'", conexion.ConectarDB());
                come.ExecuteNonQuery();
                MessageBox.Show("funciono");
                verTodo();
                comboBox1.Enabled = false;
                button1.Enabled = true; button3.Enabled = true;
                bandera = false;
                cargar_masiva();
            }
        }

        //boton eliminar
        private void button3_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                MessageBox.Show("SELECCIONE EL ID DEL PRODUCTO QUE DESEA ELIMINAR");
                bandera = true;
                comboBox1.Enabled = true;
                button1.Enabled = false; button2.Enabled = false;
                textBox1.Enabled = false; textBox3.Enabled = false;
                comboBox2.Enabled = false; comboBox3.Enabled = false;
                comboBox4.Enabled = false; comboBox5.Enabled = false;
                comboBox6.Enabled = false; textBox2.Enabled = false;
            }
            else if (bandera == true)
            {
                int id;
                id = int.Parse(comboBox1.SelectedValue.ToString());
                conexion.ConectarDB();
                SqlCommand come = new SqlCommand("EXEC sp_delete_producto '" + id + "'", conexion.ConectarDB());
                come.ExecuteNonQuery();
                MessageBox.Show("Registro Eliminado");
                verTodo();
                comboBox1.Enabled = false;
                button1.Enabled = true; button2.Enabled = true;
                textBox1.Enabled = true; textBox3.Enabled = true;
                comboBox2.Enabled = true; comboBox3.Enabled = true;
                comboBox4.Enabled = true; comboBox5.Enabled = true;
                comboBox6.Enabled = true; textBox2.Enabled = true;
                bandera = false;
                cargar_masiva();
            }
        }

        public void cargar_combo_talla()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("Select id_talla_producto,talla from talla_producto", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["talla"] = "Selecciona una Talla";
            dt.Rows.InsertAt(fila, 0);
            comboBox6.ValueMember = "id_talla_producto";
            comboBox6.DisplayMember = "talla";
            comboBox6.DataSource = dt;
        }

        public void cargar_combo_color()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("Select id_color_producto,color from color_producto", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["color"] = "Selecciona un Color";
            dt.Rows.InsertAt(fila, 0);
            comboBox4.ValueMember = "id_color_producto";
            comboBox4.DisplayMember = "color";
            comboBox4.DataSource = dt;
        }

        public void cargar_combo_estado()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("Select id_estado_producto,estado_producto from estado_producto", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["estado_producto"] = "Selecciona un Estado";
            dt.Rows.InsertAt(fila, 0);
            comboBox2.ValueMember = "id_estado_producto";
            comboBox2.DisplayMember = "estado_producto";
            comboBox2.DataSource = dt;
        }

        public void cargar_combo_categoria()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("Select id_categoria,nombre_categoria from categoria", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["nombre_categoria"] = "Selecciona una categoria";
            dt.Rows.InsertAt(fila, 0);
            comboBox5.ValueMember = "id_categoria";
            comboBox5.DisplayMember = "nombre_categoria";
            comboBox5.DataSource = dt;
        }
        public void cargar_combo_id()
        {
            comboBox1.Enabled = false;
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

        public void cargar_foto()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("Select id_foto_producto,url from foto_producto", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["url"] = "Selecciona un URL";
            dt.Rows.InsertAt(fila, 0);
            comboBox3.ValueMember = "id_foto_producto";
            comboBox3.DisplayMember = "url";
            comboBox3.DataSource = dt;
        }


        public void cargar_masiva()
        {
            cargar_foto();
            cargar_combo_talla();
            cargar_combo_estado();
            cargar_combo_color();
            cargar_combo_categoria();
            cargar_combo_id();
        }

        public void verTodo()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_producto", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.desconectarDB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            inicio salto = new inicio();
            this.Close();
            salto.Show();
        }
    }
}
