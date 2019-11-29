using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace servidor_CRUD3
{
    /*
     * form que despliega la cantidad de usuarios en una tabla, extraidos de la base de datos
     */
    public partial class eliminar_usuario : Form
    {
        private usuario_registrado usuario;
        public eliminar_usuario()
        {
            InitializeComponent();
        }

        public eliminar_usuario(usuario_registrado usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void eliminar_usuario_Load(object sender, EventArgs e)
        {
            // aqui carga los usuarios de la base de datos cuando se abre la ventana
            // http://solibnis.blogspot.com/2013/02/connecting-mysql-table-to-datagridview.html
            // https://stackoverflow.com/questions/12904854/fill-datagridview-with-mysql-data/25269906
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.datagrid?view=netframework-4.8#definition

            MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = usuarios;");
            conexion.Open();
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                string sqlQuery = "Select * from usuario;";
                
                dataAdapter.SelectCommand = new MySqlCommand(sqlQuery, conexion);

                DataTable tabla = new DataTable();
                dataAdapter.Fill(tabla);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = tabla;

                dataGridView1.DataSource = bSource;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void eliminar_btn_Click(object sender, EventArgs e)
        {
            // boton para eliminar el usuario seleccionado
            // TODO: todo
            try
            {
                String nombre = DGVtoString(dataGridView1, '1');
                String ID = DGVtoString(dataGridView1, '2');
                String contra = DGVtoString(dataGridView1, '3');
                Console.WriteLine(nombre, ID, contra);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine();
            }
            finally
            {

            }
        }

        // https://stackoverflow.com/questions/6961867/getting-data-from-datagridview-to-string
        public static String DGVtoString(DataGridView dgv, char delimiter)
        {
            StringBuilder sb = new StringBuilder();
            // obtiene la coleccion de celdas seleccionadas por el usuario 
            // y lo empaqueta en un objeto "oneCell"
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append(cell.Value);
                    sb.Append(delimiter);
                }
                sb.Remove(sb.Length - 1, 1); // remove the last delimiter
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
