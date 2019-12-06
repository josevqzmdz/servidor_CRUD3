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
        private string nombre, ID, contrasena;

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

            // comando para seleccionar todas las celdas de una fila cuando esta se seleccione
            // https://stackoverflow.com/questions/13672693/how-do-i-select-a-complete-datagridview-row-when-the-user-clicks-a-cell-of-that
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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
            // https://www.c-sharpcorner.com/UploadFile/1e050f/insert-update-and-delete-record-in-datagridview-C-Sharp/
            nombre = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            ID = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            contrasena = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void eliminar_btn_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.datagridview?view=netframework-4.8
            // https://stackoverflow.com/questions/21038006/how-to-delete-selected-row-from-datagridview-and-database-in-c-sharp
            // boton para eliminar el usuario seleccionado
            // boilerplate sacado de https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/selected-cells-rows-and-columns-datagridview
            // TODO: todo
            // https://www.c-sharpcorner.com/UploadFile/1e050f/insert-update-and-delete-record-in-datagridview-C-Sharp/

            MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1; port=3306; username=root; password=; database = usuarios;");
            conexion.Open();

            try
            {
                // consigue el numero de celdas seleccionadas
                Int32 celdas_seleccionadas = dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
                if (celdas_seleccionadas > 0)
                {
                    // para detectar si todas las celdas de datagrid estan seleccionadas
                    if (dataGridView1.AreAllCellsSelected(true))
                    {
                        MessageBox.Show("todas las celdas estan seleccionadas");
                    }
                    else
                    {

                        Console.WriteLine(nombre);
                        Console.WriteLine(ID);
                        Console.WriteLine(contrasena);
                        
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine();
            }
            finally
            {
                conexion.Close();
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
