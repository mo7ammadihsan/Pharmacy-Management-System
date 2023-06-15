using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Countries
    {
        public static DataTable Countries_Select_Search(string name)
        {
            return DataAccessLayer.ExecuteTable("Countries_Select_Search", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name));
        }

        public static void Countries_Add(string name)
        {
            DataAccessLayer.ExecuteNonQuery("Countries_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name));
        }

        public static void Countries_Update(int ID, string name)
        {
            DataAccessLayer.ExecuteNonQuery("Countries_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, ID));
        }

        public static void Countries_delete(int ID)
        {
            DataAccessLayer.ExecuteNonQuery("Countries_delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, ID));
        }
    }
}
