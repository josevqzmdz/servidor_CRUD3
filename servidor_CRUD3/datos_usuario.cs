using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// libreria para hilos
using System.Threading;

namespace servidor_CRUD3
{
    public partial class datos_usuario : Form
    {
        private usuario_registrado usuario = null;

        public datos_usuario()
        {
            InitializeComponent();
        }
        public datos_usuario(usuario_registrado usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void modificar_btn_Click(object sender, EventArgs e)
        {
            // boton para modificar valores
            /*
            * You can start your NewForm in a new thread and create a new message loop

              When the main message loop is closed, the application exits. In Windows Forms,
              this loop is closed when the Exit method is called
              https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.application.run?redirectedfrom=MSDN&view=netframework-4.8#System_Windows_Forms_Application_Run
              https://stackoverflow.com/questions/26444194/methods-this-hide-vs-this-close
            */
            var hilo = new Thread(() => Application.Run(new modificar_usuario(usuario)));
            hilo.SetApartmentState(ApartmentState.STA);
            hilo.Start();

            this.Close();
        }

        private void datos_usuario_Load(object sender, EventArgs e)
        {
            nombre_lbl.Text = usuario.Nombre;
            ID_lbl.Text = usuario.ID;
            contra_lbl.Text = usuario.Contra;
        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            var hilo = new Thread(() => Application.Run(new registrar_form(usuario, true)));
            hilo.SetApartmentState(ApartmentState.STA);
            hilo.Start();

            this.Close();
        }

        private void eliminar_btn_Click(object sender, EventArgs e)
        {
            var hilo = new Thread(() => Application.Run(new eliminar_usuario(usuario)));
            hilo.SetApartmentState(ApartmentState.STA);
            hilo.Start();

            this.Close();
        }

        private void salir_btn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
