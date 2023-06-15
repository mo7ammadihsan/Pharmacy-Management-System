using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Sales_Details
    {
        public static void Sales_Details_Insert(int Sales_ID, int Product_ID, string Price, int Qty, string Total, string Discount, string Notes)
        {
            DataAccessLayer.ExecuteNonQuery("Sales_Details_Insert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Sales_ID", SqlDbType.Int, Sales_ID),
                DataAccessLayer.CreateParameter("@Product_ID", SqlDbType.Int, Product_ID),
                DataAccessLayer.CreateParameter("@Price", SqlDbType.NVarChar, Price),
                DataAccessLayer.CreateParameter("@Qty", SqlDbType.Int, Qty),
                DataAccessLayer.CreateParameter("@Total", SqlDbType.NVarChar, Total),
                DataAccessLayer.CreateParameter("@Discount", SqlDbType.NVarChar, Discount),
                DataAccessLayer.CreateParameter("@Notes", SqlDbType.NVarChar, Notes));
        }
    }
}
