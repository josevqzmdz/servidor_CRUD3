using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// libreria para queries de mysql / SQL
using MySql.Data.MySqlClient;
// libreria para hilos
using System.Threading;

namespace servidor_CRUD3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ingresar_btn_Click(object sender, EventArgs e)
        {
            //boton para ingresar
            // TODO: cerrar forms 
            // https://stackoverflow.com/questions/3965043/how-to-open-a-new-form-from-another-form
            // https://stackoverflow.com/questions/13604216/how-i-can-insert-data-in-the-mysql-database
            string nombre = nombre_txt.Text;
            string contra = contra_txt.Text;
            MySqlConnection conectar = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = usuarios;");
            conectar.Open();

            try
            {                
                if (nombre != "" &&  contra != "" && nombre != null  && contra != null)
                {
                    // https://www.youtube.com/watch?v=brTPquMQIu8 
                    // archivo: prueba
                    // https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-sql-command.html

                    string sqlQuery = "SELECT nombre, contrasena, ID FROM usuario WHERE nombre = @nombre AND contrasena = @contrasena;";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conectar);
                    command.Parameters.AddWithValue("@nombre", nombre_txt.Text);
                    command.Parameters.AddWithValue("@contrasena", contra_txt.Text);
                    MySqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        // https://stackoverflow.com/questions/34497524/how-to-read-one-row-from-mysql
                        // https://stackoverflow.com/questions/27389056/c-sharp-login-using-mysql-database-could-not-find-specified-column-in-results
                        // https://stackoverflow.com/questions/44570908/could-not-find-specified-column-in-results-in-mysql
                        
                        usuario_registrado usuario = new usuario_registrado();
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.ID = reader["ID"].ToString();
                        usuario.Contra = reader["contrasena"].ToString();
                        MessageBox.Show("Bienvenido, " + usuario.Nombre + ", ID: " +usuario.ID);
                        /*
                         * You can start your NewForm in a new thread and create a new message loop

                           When the main message loop is closed, the application exits. In Windows Forms,
                           this loop is closed when the Exit method is called
                           https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.run?redirectedfrom=MSDN&view=netframework-4.8#System_Windows_Forms_Application_Run
                           https://stackoverflow.com/questions/26444194/methods-this-hide-vs-this-close
                         */
                        var hilo = new Thread(() => Application.Run(new datos_usuario(usuario)));
                        hilo.SetApartmentState(ApartmentState.STA);
                        hilo.Start();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("usuario y/o contraseña incorrecto o no existe");
                    }
                }

                else
                {
                    MessageBox.Show("favor de introducir datos al campo de texto");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conectar.Close();             
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void registrar_btn_Click(object sender, EventArgs e)
        {
            // boton para registrar
            // https://stackoverflow.com/questions/3965043/how-to-open-a-new-form-from-another-form

            var hilo = new Thread(() => Application.Run(new registrar_form(false)));
            hilo.SetApartmentState(ApartmentState.STA);
            hilo.Start();

            this.Close();

        }
    }
}
