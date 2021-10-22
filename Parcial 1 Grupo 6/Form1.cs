using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Parcial_1_Grupo_6
{
    public partial class Form1 : Form
    {
        public string cadena_conexion = "Database = parcial2; DataSource = localhost; User Id = Joan; Password = 12902";
        public string usuario_modificar;
        public string usuario_eliminar;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            lstedad.Enabled = false;
            lstsexo.Enabled = false;
            txtdui.Enabled = false;
            txtnit.Enabled = false;
            txtafp.Enabled = false;
            txtisss.Enabled = false;
            dtfecha.Enabled = false;

            bactualizar.Visible = false;

            try
            {
                String consulta = "Select * from usuarios ";
                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion);

                System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "parcial2");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial2";
            }
            catch
            {
                MessageBox.Show("Error de Conexion", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
   
        private void bsalir_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void bbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
                string myInsertQuery = "select * from usuarios where idusuario = " + txtbuscar.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery, myConnection);
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {

                    txtusuario.Text = (myReader.GetString(1));
                    txtclave.Text = (myReader.GetString(2));
                    lstnivel.Text = (myReader.GetString(3));
                    txttelefono.Text = (myReader.GetString(4));
                    txtcorreo.Text = (myReader.GetString(5));
                    lstsexo.Text = (myReader.GetString(6));
                    lstedad.Text = (myReader.GetString(7));
                    txtdui.Text = (myReader.GetString(8));
                    txtnit.Text = (myReader.GetString(9));
                    txtafp.Text = (myReader.GetString(10));
                    txtisss.Text = (myReader.GetString(11));
                    dtfecha.Text = (myReader.GetString(12));

                }
                else
                {
                    MessageBox.Show("El usuario no existe", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                myReader.Close();
                myConnection.Close();

            }
            catch (MySqlException)
            {
                MessageBox.Show("Campo de busqueda esta vasio", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            lstedad.Enabled = false;
            lstsexo.Enabled = false;
            txtdui.Enabled = false;
            txtnit.Enabled = false;
            txtafp.Enabled = false;
            txtisss.Enabled = false;
            dtfecha.Enabled = false;

            bmodificar.Focus();
        }

        private void bsalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bentrar_Click_3(object sender, EventArgs e)
        {
            Inicio Form1 = new Inicio();
            Form1.Show();
            this.Hide();
        }

        private void bactualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
                string usu = txtusuario.Text.ToString();
                string cla = txtclave.Text.ToString();
                string niv = lstnivel.Text;
                string tel = txttelefono.Text.ToString();
                string cor = txtcorreo.Text.ToString();
                string eda = lstedad.Text;
                string sex = lstsexo.Text;
                string dui = txtdui.Text.ToString();
                string nit = txtnit.Text.ToString();
                string afp = txtafp.Text.ToString();
                string isss = txtisss.Text.ToString();
                string fec = dtfecha.Text.ToString();


                string myInsertQuery = "UPDATE usuarios SET usuario = '" + usu + "',clave = '" + cla + "',nivel = '" + niv + "',telefono = '" + tel + "',correo = '" + cor + "',sexo = '" + sex + "',edad = '" + eda + "',dui = '"+ dui +"',nit = '" + nit +"',afp = '"+ afp +"',isss = '" + isss + "',fecha = '"+ fec +"' WHERE usuario = '" + usuario_modificar + "'";

                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
                MessageBox.Show("Usuario Actualizado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "select * from usuarios";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "parcial2");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial2";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error al Actualizar el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bmodificar.Visible = true;
            bactualizar.Visible = false;

            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            lstedad.Enabled = false;
            lstsexo.Enabled = false;
            txtdui.Enabled = false;
            txtnit.Enabled = false;
            txtafp.Enabled = false;
            txtisss.Enabled = false;
            dtfecha.Enabled = false;

            bmodificar.Focus();
        }

        private void beliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
                string myInsertQuery = "delete from usuarios Where idusuario = " + txtbuscar.Text + "";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
                MessageBox.Show("Usuario eliminado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "select * from usuarios";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "parcial2");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial2";
            }
            catch
            {
                MessageBox.Show("Error al eliminar el usuario, primero realice búsqueda del usuario y después puede eliminar.", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            lstedad.Enabled = false;
            lstsexo.Enabled = false;
            txtdui.Enabled = false;
            txtnit.Enabled = false;
            txtafp.Enabled = false;
            txtisss.Enabled = false;
            dtfecha.Enabled = false;
            txtusuario.Text = "";
            txtclave.Text = "";
            lstnivel.Text = "Seleccione nivel";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            lstedad.Text = "Selecione su genero";
            lstsexo.Text = "Indique su edad";
            txtdui.Text = "";
            txtnit.Text = "";
            txtafp.Text = "";
            txtisss.Text = "";
            dtfecha.Text = "";
            txtbuscar.Focus();
        }

        private void bnuevo_Click_1(object sender, EventArgs e)
        {
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;
            txttelefono.Enabled = true;
            txtcorreo.Enabled = true;
            lstedad.Enabled = true;
            lstsexo.Enabled = true;
            txtdui.Enabled = true;
            txtnit.Enabled = true;
            txtafp.Enabled = true;
            txtisss.Enabled = true;
            dtfecha.Enabled = true;
            txtusuario.Text = "";
            txtclave.Text = "";
            lstnivel.Text = "Seleccione nivel";
            txttelefono.Text = "";
            txtcorreo.Text = "";
            lstedad.Text = "Selecione su genero";
            lstsexo.Text = "Indique su edad";
            txtdui.Text = "";
            txtnit.Text = "";
            txtafp.Text = "";
            txtisss.Text = "";
            dtfecha.Text = "";
            txtusuario.Focus();

            bnuevo.Visible = false;
            bguardar.Visible = true;
        }

        private void bmodificar_Click_1(object sender, EventArgs e)
        {
            txtusuario.Enabled = true;
            txtclave.Enabled = true;
            lstnivel.Enabled = true;
            txttelefono.Enabled = true;
            txtcorreo.Enabled = true;
            lstedad.Enabled = true;
            lstsexo.Enabled = true;
            txtdui.Enabled = true;
            txtnit.Enabled = true;
            txtafp.Enabled = true;
            txtisss.Enabled = true;
            dtfecha.Enabled = true;
            txtusuario.Focus();

            bmodificar.Visible = false;
            bactualizar.Visible = true;
            usuario_modificar = txtusuario.Text.ToString();
        }

        private void bguardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
                string myInsertQuery = "INSERT INTO usuarios (usuario,clave,nivel,telefono,correo,sexo,edad) Values(?usuario,?clave,?nivel,?telefono,?correo,?sexo,?edad)";
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                myCommand.Parameters.Add("?usuario", txtusuario.Text);
                myCommand.Parameters.Add("?clave", txtclave.Text);
                myCommand.Parameters.Add("?nivel", lstnivel.Text);
                myCommand.Parameters.Add("?telefono", txttelefono.Text);
                myCommand.Parameters.Add("?correo", txtcorreo.Text);
                myCommand.Parameters.Add("?sexo", lstsexo.Text);
                myCommand.Parameters.Add("?edad", lstedad.Text);
                myCommand.Parameters.Add("?dui",  txtdui.Text);
                myCommand.Parameters.Add("?nit", txtnit.Text);
                myCommand.Parameters.Add("?afp", txtafp.Text);
                myCommand.Parameters.Add("?isss", txtisss.Text);
                myCommand.Parameters.Add("?fecha", dtfecha.Text);

                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();
                MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "select * from usuarios";

                MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                System.Data.DataSet ds = new System.Data.DataSet();
                da.Fill(ds, "parcial2");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "parcial2";
            }
            catch (MySqlException)
            {
                MessageBox.Show("No se pudo guardar el usuario en la base de datos", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            bnuevo.Visible = true;
            bguardar.Visible = false;

            txtusuario.Enabled = false;
            txtclave.Enabled = false;
            lstnivel.Enabled = false;
            txttelefono.Enabled = false;
            txtcorreo.Enabled = false;
            lstedad.Enabled = false;
            lstsexo.Enabled = false;
            txtdui.Enabled = false;
            txtnit.Enabled = false;
            txtafp.Enabled = false;
            txtisss.Enabled = false;
            dtfecha.Enabled = false;
            bnuevo.Focus();
        }

        private void lstsexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtfecha_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}