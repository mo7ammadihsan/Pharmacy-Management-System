using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Users
    {
        public static DataTable Users_Select()
        {
            return DataAccessLayer.ExecuteTable("Users_Select", CommandType.StoredProcedure);
        }
        public static DataTable Permissions_Select()
        {
            return DataAccessLayer.ExecuteTable("Permissions_Select", CommandType.StoredProcedure);
        }

        public static DataTable Users_validate(string name, string fullname)
        {
            return DataAccessLayer.ExecuteTable("Users_validate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@fullname", SqlDbType.NVarChar, fullname));
        }

        public static void Users_Add(string name, string pass, string full_name, int per_id)
        {
            DataAccessLayer.ExecuteNonQuery("Users_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@pass", SqlDbType.NVarChar, pass),
                DataAccessLayer.CreateParameter("@full_name", SqlDbType.NVarChar, full_name),
                DataAccessLayer.CreateParameter("@Per_ID", SqlDbType.Int, per_id));
        }

        public static void Users_Update(int id, string name, string pass, string full_name, int per_id)
        {
            DataAccessLayer.ExecuteNonQuery("Users_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@pass", SqlDbType.NVarChar, pass),
                DataAccessLayer.CreateParameter("@full_name", SqlDbType.NVarChar, full_name),
                DataAccessLayer.CreateParameter("@Per_ID", SqlDbType.Int, per_id));
        }

        public static void Users_Delete(int id)
        {
            DataAccessLayer.ExecuteNonQuery("Users_Delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, id));
        }
    }
}
