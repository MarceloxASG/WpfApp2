using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProducto
    {
        private string connectionString = "Data Source=LAB1507-03\\SQLEXPRESS;Initial Catalog=FacturaDB;User ID=usuario01;Password=123456;";

        public List<Producto> Get(string invoiceNumber = null)
        {
            var invoices = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("GetFacturas", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                
                if (!string.IsNullOrEmpty(invoiceNumber))
                {
                    cmd.Parameters.AddWithValue("@invoice_number", invoiceNumber);
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var invoice = new Producto
                        {
                            InvoiceID = reader.GetInt32(reader.GetOrdinal("invoice_id")),
                            CustomerID = reader.GetInt32(reader.GetOrdinal("customer_id")),
                            Date = reader.GetDateTime(reader.GetOrdinal("date")),
                            Total = reader.GetDecimal(reader.GetOrdinal("total")),
                            Active = reader.GetBoolean(reader.GetOrdinal("active")),
                            InvoiceNumber = reader.GetString(reader.GetOrdinal("invoice_number"))
                        };
                        invoices.Add(invoice);
                    }
                }
            }
            return invoices;
        }
    }

}
