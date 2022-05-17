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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        bool bandera = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarCombo();
            verTodo();
            cargar_combo_pais();
            cargar_Combo_telefono();
            cargar_combo_id();
        }

        //boton update
        private void button3_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                MessageBox.Show("SELECCIONE EL ID DEL USUARIO QUE DESEA MODIFICAR Y MODIFIQUE LOS DATOS QUE DESEA");
                bandera = true;
                comboBox4.Enabled = true;
                btnInsert.Enabled = false;
            }
            else if (bandera == true)
            {
                int rolex, pais, telefono, id;
                rolex = int.Parse(comboBox1.SelectedValue.ToString());
                pais = int.Parse(comboBox2.SelectedValue.ToString());
                telefono = int.Parse(comboBox3.SelectedValue.ToString());
                id = int.Parse(comboBox4.SelectedValue.ToString());
                conexion.ConectarDB();
                SqlCommand come = new SqlCommand("EXEC sp_update_usuario '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + telefono + "','" + pais + "','" + rolex + "','" + id + "'", conexion.ConectarDB());
                come.ExecuteNonQuery();
                MessageBox.Show("funciono");
                carga_masiva();
                comboBox4.Enabled = false;
                btnInsert.Enabled = true;
                bandera = false;
            }

        }

        //boton insertar
        private void btnInsert_Click(object sender, EventArgs e)
        {
            int rolex, pais,telefono;
            rolex = int.Parse(comboBox1.SelectedValue.ToString());
            pais = int.Parse(comboBox2.SelectedValue.ToString());
            telefono = int.Parse(comboBox3.SelectedValue.ToString());
            conexion.ConectarDB();
            SqlCommand come = new SqlCommand("EXEC sp_insertar_usuario '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','"+textBox3.Text+"','"+telefono+"','"+pais+"','"+rolex+"'", conexion.ConectarDB());
            come.ExecuteNonQuery();
            MessageBox.Show("funciono");
            carga_masiva();
        }


        public void carga_masiva()
        {
            cargarCombo();
            cargar_combo_id();
            cargar_combo_pais();
            cargar_Combo_telefono();
            verTodo();
        }
        //boton Delete
        private void brnDelete_Click(object sender, EventArgs e)
        {

        }

        //ver todo
        public void verTodo()
        {
            SqlCommand com = new SqlCommand("exec sp_ver_usuario", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conexion.desconectarDB();
        }

        //datos comboBox
        public void cargarCombo()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("Select id_rol,rol from rol_usuario", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["rol"] = "Selecciona un Rol";
            dt.Rows.InsertAt(fila, 0);
            comboBox1.ValueMember = "id_rol";
            comboBox1.DisplayMember = "rol";
            comboBox1.DataSource = dt;
        }
        public void cargar_Combo_telefono()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("Select id_telefono,telefono from telefono", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["telefono"] = "Selecciona un telefono";
            dt.Rows.InsertAt(fila, 0);
            comboBox3.ValueMember = "id_telefono";
            comboBox3.DisplayMember = "telefono";
            comboBox3.DataSource = dt;
        }

        //cargar ComboBoxPais
        public void cargar_combo_pais()
        {
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_pais,pais FROM pais", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["pais"] = "Selecciona un Pais";
            dt.Rows.InsertAt(fila, 0);
            comboBox2.ValueMember = "id_pais";
            comboBox2.DisplayMember = "pais";
            comboBox2.DataSource = dt;
        }
        public void cargar_combo_id()
        {
            comboBox4.Enabled = false;
            conexion.ConectarDB();
            SqlCommand com = new SqlCommand("SELECT id_usuario, nombre_usuario FROM usuario", conexion.ConectarDB());
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conexion.desconectarDB();
            DataRow fila = dt.NewRow();
            fila["nombre_usuario"] = "Seleccione el ID";
            dt.Rows.InsertAt(fila, 0);
            comboBox4.ValueMember = "id_usuario";
            comboBox4.DisplayMember = "nombre_usuario";
            comboBox4.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            inicio salto = new inicio();
            this.Close();
            salto.Show();
        }
    }
}
