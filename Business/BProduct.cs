using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProduct
    {
        public List<Producto> Get()
        {
            DProducto datos = new DProducto();
            var productos = datos.Get();
            return productos;
        }
    }
}
