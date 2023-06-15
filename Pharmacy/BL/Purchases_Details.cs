using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Purchases_Details
    {
        public static void Purchases_Details_Insert(int Purchases_ID, int Product_ID, string Price, int Qty, string Total, string Discount, string Notes, string ExpiredDate)
        {
            DataAccessLayer.ExecuteNonQuery("Purchases_Details_Insert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Purchases_ID", SqlDbType.Int, Purchases_ID),
                DataAccessLayer.CreateParameter("@Product_ID", SqlDbType.Int, Product_ID),
                DataAccessLayer.CreateParameter("@Price", SqlDbType.NVarChar, Price),
                DataAccessLayer.CreateParameter("@Qty", SqlDbType.Int, Qty),
                DataAccessLayer.CreateParameter("@Total", SqlDbType.NVarChar, Total),
                DataAccessLayer.CreateParameter("@Discount", SqlDbType.NVarChar, Discount),
                DataAccessLayer.CreateParameter("@Notes", SqlDbType.NVarChar, Notes),
                DataAccessLayer.CreateParameter("@ExpiredDate", SqlDbType.Date, ExpiredDate)
                );
        }
    }
}
