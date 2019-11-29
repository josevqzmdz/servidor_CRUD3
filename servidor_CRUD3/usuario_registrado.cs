using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servidor_CRUD3
{
    // clase que guarda los valores del usuario conectado
    // para poder transmitirse de clase a clase
    public class usuario_registrado
    {
        private String nombre, id, contra = null;

        // GET & SET: https://stackoverflow.com/questions/5096926/what-is-the-get-set-syntax-in-c
        /*
         * get and set are accessors, meaning they're able to access data and 
         * info in private fields (usually from a backing field) and usually 
         * do so from public properties
         * 
         * get / set creado automaticamente con prop <espacio espacio>
         * 
         *  'value' is an implicit argument
         */

        public String Nombre { get => nombre; set => nombre = value; }
        public String ID { get => id; set => id = value; }
        public String Contra { get => contra; set => contra = value; }
    }
}
