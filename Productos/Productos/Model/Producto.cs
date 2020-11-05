using System;
using System.Collections.Generic;
using System.Text;

namespace Productos.Model
{
    public class Producto
    {
        public int id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int Tipo { get; set; }
    }
}
