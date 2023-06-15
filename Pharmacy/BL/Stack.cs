using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Stack
    {
        public static DataTable Stack_Select(string search)
        {
            return DataAccessLayer.ExecuteTable("Stack_Select", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Search", SqlDbType.NVarChar, search));
        }

        public static DataTable Stack_Select_ID(int id)
        {
            return DataAccessLayer.ExecuteTable("Stack_Select_ID", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, id));
        }

        public static void Stack_Delete(int id, string date)
        {
            DataAccessLayer.ExecuteTable("Stack_Delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@exp", SqlDbType.DateTime, date));
        }
    }
}
