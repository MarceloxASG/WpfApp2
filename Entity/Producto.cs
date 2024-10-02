using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Producto
    {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }   
        public DateTime Date { get; set; }    
        public decimal Total { get; set; } 
        public bool Active { get; set; }   
        public string InvoiceNumber { get; set; }
    }
}
