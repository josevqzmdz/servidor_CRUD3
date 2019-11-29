using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

/*
 * TODO: encontrar forma de editar todos los valores de una vez, cuando se detecte que todos han cambiado
 * 
 * 
 */

namespace servidor_CRUD3
{
    public partial class modificar_usuario : Form
    {
        private usuario_registrado usuario = null;
        public modificar_usuario()
        {
            InitializeComponent();
        }

        public modificar_usuario(usuario_registrado usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void modificar_btn_Click(object sender, EventArgs e)
        {
            // boton para modificar un valor (o varios) en mysql
            // TODO: utilizar parametrized queries para evitar inyecciones SQL
            // https://stackoverflow.com/questions/20492019/update-statement-in-mysql-using-c-sharp
            // https://blogs.msdn.microsoft.com/sqlphp/2008/09/30/how-and-why-to-use-parameterized-queries/
            // https://csharp-station.com/Tutorial/AdoDotNet/Lesson06

            /*
             * http://www.mysqltutorial.org/mysql-update-data.aspx
             * primero, encuentra la fila a cambiar utilizando el statement SELECT
             */
             // objeto para conectar a la base de datos, refactorizado con ctrl + r (x2)
            MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = usuarios;");
            conexion.Open();
            try
            {
                if (nombre_txt.Text != "" && contra_txt.Text != "" && ID_txt.Text != "")
                {
                    // primero se encuentra el usuario original en la base de datos
                    //string sqlQuery = "SELECT * FROM usuario WHERE nombre = '" + usuario.Nombre + "' AND contrasena = '" + usuario.Contra + "' AND ID = '" + usuario.ID + "';";
                    string sqlQuery = "SELECT nombre, contrasena, ID FROM usuario WHERE nombre = @nombre AND contrasena = @contrasena AND ID = @ID;";

                    //crear un objeto mysqlparameter para cada parametro a añadir al query
                    /*https://www.dreamincode.net/forums/topic/268104-the-right-way-to-query-a-database-parameterizing-your-sql-queries/
                     * SqlCommand has a collection of parameters, appropriately named Parameters. 
                     * This has a very handy method on it named "AddWithValue". It takes a string 
                     * and an object. First, the name of the parameter, and next the value to be 
                     * set to that parameter.
                     */
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, conexion);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@contrasena", usuario.Contra);
                    cmd.Parameters.AddWithValue("@ID", usuario.ID);

                    // ahora si, ejecuta el cursor
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // despues, se manda el query para actualizar (update)
                        /*
                         * https://www.codeproject.com/Questions/680856/There-is-already-an-open-DataReader-associated-wit
                         * You should always call the Close method when you have finished using the DataReader object.
                           If your Command contains output parameters or return values, 
                           they will not be available until the DataReader is closed.
                         */

                        reader.Close();

                        // NOMBRE
                        if (usuario.Nombre != nombre_txt.Text)
                        {
                            // https://stackoverflow.com/questions/15246182/sql-update-statement-in-c-sharp

                            string nuevoNombreSql = "UPDATE usuario SET nombre = @newNombre WHERE nombre = @oldNombre;";
                            cmd.CommandText = nuevoNombreSql;
                            cmd.Parameters.AddWithValue("@newNombre", nombre_txt.Text);
                            cmd.Parameters.AddWithValue("@oldNombre", usuario.Nombre);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("nuevo nombre: '" + nombre_txt.Text + "' editado exitosamente");
                            usuario.Nombre = nombre_txt.Text;
                            this.cancelar_btn.Text = "salir";
                        }

                        // ID
                        else if (ID_txt.Text != usuario.ID)
                        {
                            string nuevoIDSql = "UPDATE usuario SET ID = @newID WHERE ID = @oldID;";
                            cmd.CommandText = nuevoIDSql;
                            cmd.Parameters.AddWithValue("@newID", ID_txt.Text);
                            cmd.Parameters.AddWithValue("@oldID", usuario.ID);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("nuevo ID: '" + ID_txt.Text + "' editado exitosamente");
                            usuario.ID = ID_txt.Text;
                            this.cancelar_btn.Text = "salir";
                        }

                        // CONTRASEÑA
                        else if (contra_txt.Text != usuario.Contra)
                        {
                            string nuevaContraSql = "UPDATE usuario SET contrasena = @newContrasena WHERE contrasena = @oldContrasena;";
                            cmd.CommandText = nuevaContraSql;
                            cmd.Parameters.AddWithValue("@newContrasena", contra_txt.Text);
                            cmd.Parameters.AddWithValue("@oldContrasena", usuario.Contra);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("nueva contraseña editada exitosamente");
                            usuario.Contra = contra_txt.Text;
                            this.cancelar_btn.Text = "salir";
                        }

                        // TODO: encontrar forma de editar todos los valores de una vez, cuando se detecte que todos han cambiado
                        else
                        {

                        }
                    }else
                    {
                        Console.WriteLine("favor de introducir valores en los campos de texto");
                        MessageBox.Show("favor de introducir valores en los campos de texto");
                    }
                }
                else
                {
                    Console.WriteLine("favor de introducir valores en los campos de texto");
                    MessageBox.Show("favor de introducir valores en los campos de texto");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conexion.Close();
                
            }
        }

        private void cancelar_btn_Click(object sender, EventArgs e)
        {
                var hilo = new Thread(() => Application.Run(new datos_usuario(usuario)));
                hilo.SetApartmentState(ApartmentState.STA);
                hilo.Start();

                this.Close();
        }

        private void modificar_usuario_Load(object sender, EventArgs e)
        {
            nombre_txt.Text = usuario.Nombre;
            ID_txt.Text = usuario.ID;
            contra_txt.Text = usuario.Contra;
        }
    }
}
