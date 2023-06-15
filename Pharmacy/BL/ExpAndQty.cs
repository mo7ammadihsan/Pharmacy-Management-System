using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class ExpAndQty
    {
        public static void ExpAndQty_Add(string date, int ID, int Qty, int Supplier_ID)
        {
            DataAccessLayer.ExecuteNonQuery("ExpAndQty_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@date", SqlDbType.DateTime, date),
                DataAccessLayer.CreateParameter("@P_ID", SqlDbType.Int, ID),
                DataAccessLayer.CreateParameter("@Qty", SqlDbType.Int, Qty),
                DataAccessLayer.CreateParameter("@Supplier_ID", SqlDbType.Int, Supplier_ID));
        }

        public static DataTable QtyInStack(int id)
        {
            return DataAccessLayer.ExecuteTable("select sum(Qty)from ExpAndQty where P_ID=" + id, CommandType.Text);
        }

        public static void Delete()
        {
            DataAccessLayer.ExecuteNonQuery("delete from ExpAndQty where Qty=0", CommandType.Text);
        }
    }
}
