using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// libreria para MySQL
using MySql.Data.MySqlClient;
// libreria para hilos
using System.Threading;

namespace servidor_CRUD3
{
	// TODO: cambiar a parametrized queries
    public partial class registrar_form : Form
    {
        private usuario_registrado usuario;
        // bandera para saber si el usuario esta accediendo desde el menu o desde el login
        // FALSE: registrar -> menu, TRUE: registrar -> login
        public Boolean esMenu;
        public registrar_form()
        {
            InitializeComponent();
        }

        public registrar_form(Boolean esMenu)
        {
            InitializeComponent();
            this.esMenu = esMenu;
        }

        public registrar_form(usuario_registrado usuario, Boolean esMenu)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.esMenu = esMenu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton de registro
            // https://stackoverflow.com/questions/13604216/how-i-can-insert-data-in-the-mysql-database
            MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = usuarios;");
            string nombre = nombre_txt.Text;
            string ID = ID_txt.Text;
            string contra = contra_txt.Text;
            try
            {
                if (nombre != "" && ID != "" && contra != "" && nombre != null && ID != null && contra != null)
                {
                    conexion.Open();
                    // MySqlCommand command = conectar.CreateCommand();
                    // Enclose any string to be passed to the mysql server inside single quotes
                    // https://stackoverflow.com/questions/1346209/unknown-column-in-field-list-error-on-mysql-update-query
                    string sqlQuery = "INSERT INTO usuario (nombre, ID, contrasena) VALUES (?, ?, ?);";
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, conexion);
                    cmd.Parameters.AddWithValue("@nombre", this.nombre_txt.Text);
                    cmd.Parameters.AddWithValue("@ID", this.ID_txt.Text);
                    cmd.Parameters.AddWithValue("@contrasena", this.contra_txt.Text);

                    // ahora si, ejecuta el cursor
                    MySqlDataReader reader = cmd.ExecuteReader();

                    MessageBox.Show("Exito al registrar");

                    this.cancelar_btn.Text = "salir";
                }
                else
                {
                    MessageBox.Show("favor de introducir valores en los campos de texto obligatorios");
                }                
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexion.Close();
            }
        }

        private void cancelar_btn_Click(object sender, EventArgs e)
        {
            // FALSE: registrar -> login, TRUE: registrar -> menu
            if (esMenu == true)
            {
                var hilo = new Thread(() => Application.Run(new datos_usuario(usuario)));
                hilo.SetApartmentState(ApartmentState.STA);
                hilo.Start();

                this.Close();
            }
            else
            {
                var hilo = new Thread(() => Application.Run(new Form1()));
                hilo.SetApartmentState(ApartmentState.STA);
                hilo.Start();

                this.Close();
            }
        }

        private void registrar_form_Load(object sender, EventArgs e)
        {

        }
    }
}
