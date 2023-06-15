using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class City
    {
        public static DataTable Cities_Select_Search(string search)
        {
            return DataAccessLayer.ExecuteTable("Cities_Select_Search", CommandType.StoredProcedure,
                 DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, search));
        }

        public static DataTable Cities_ComboBox(int id)
        {
            return DataAccessLayer.ExecuteTable("Cities_ComboBox", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));
        }
        public static void Cities_Add(string city, int country)
        {
            DataAccessLayer.ExecuteNonQuery("Cities_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@City", SqlDbType.NVarChar, city),
                DataAccessLayer.CreateParameter("@Country", SqlDbType.Int, country));
        }

        public static void Cities_Update(int ID, string city, int country)
        {
            DataAccessLayer.ExecuteNonQuery("Cities_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, ID),
                DataAccessLayer.CreateParameter("@City", SqlDbType.NVarChar, city),
                DataAccessLayer.CreateParameter("@Country", SqlDbType.Int, country));
        }

        public static void Cities_delete(int ID)
        {
            DataAccessLayer.ExecuteNonQuery("Cities_delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, ID));
        }
    }
}
