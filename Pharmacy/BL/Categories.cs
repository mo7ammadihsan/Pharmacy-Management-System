using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Categories
    {
        public static DataTable Categories_Select()
        {
            return DataAccessLayer.ExecuteTable("Categories_Select", CommandType.StoredProcedure);
        }
        public static DataTable Categories_Validate_Name(string name)
        {
            return DataAccessLayer.ExecuteTable("Categories_Validate_Name", CommandType.StoredProcedure, DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, name));
        }
        public static DataTable Categories_ComboBox()
        {
            return DataAccessLayer.ExecuteTable("Categories_ComboBox", CommandType.StoredProcedure);
        }
        public static void Categories_Add(string name, bool status)
        {

            DataAccessLayer.ExecuteNonQuery("Categories_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@status", SqlDbType.Bit, status));
        }

        public static void Categories_Update(string name, bool status, int id)
        {

            DataAccessLayer.ExecuteNonQuery("Categories_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@status", SqlDbType.Bit, status),
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));

        }
        public static void Categories_delete(int id)
        {
            DataAccessLayer.ExecuteNonQuery("Categories_delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));

        }
    }
}
