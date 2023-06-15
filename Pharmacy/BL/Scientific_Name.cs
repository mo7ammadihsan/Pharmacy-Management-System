using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Scientific_Name
    {
        public static DataTable Sc_Name_Search_Select(string search)
        {
            return DataAccessLayer.ExecuteTable("Sc_Name_Search_Select", CommandType.StoredProcedure,
                  DataAccessLayer.CreateParameter("@Search", SqlDbType.NVarChar, search));
        }

        public static DataTable Sc_Name_Validate_Name(string name)
        {
            return DataAccessLayer.ExecuteTable("Sc_Name_Validate_Name", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, name));
        }
        public static DataTable Sc_Name_Search_ComboBox()
        {
            return DataAccessLayer.ExecuteTable("Sc_Name_Search_ComboBox", CommandType.StoredProcedure);
        }
        public static void Sc_Name_Add(string name, string description, bool status)
        {
            DataAccessLayer.ExecuteNonQuery("Sc_Name_Add", CommandType.StoredProcedure,
                 DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, name),
                 DataAccessLayer.CreateParameter("@Description", SqlDbType.NVarChar, description),
                 DataAccessLayer.CreateParameter("@Status", SqlDbType.Bit, status));

        }


        public static void Sc_Name_Update(string name, string description, bool status, int id)
        {

            DataAccessLayer.ExecuteNonQuery("Sc_Name_Update", CommandType.StoredProcedure,
                 DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, name),
                 DataAccessLayer.CreateParameter("@Description", SqlDbType.NVarChar, description),
                 DataAccessLayer.CreateParameter("@Status", SqlDbType.Bit, status),
                 DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));

        }

        public static void Sc_Name_delete(int id)
        {
            DataAccessLayer.ExecuteNonQuery("Sc_Name_delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));

        }
    }
}
