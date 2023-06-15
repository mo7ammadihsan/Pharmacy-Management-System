using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Customer
    {
        public static DataTable Customer_Select_Search(string search)
        {
            return DataAccessLayer.ExecuteTable("Customer_Select_Search", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
        }
        public static DataTable Customer_Validate(string name)
        {
            return DataAccessLayer.ExecuteTable("Customer_Validate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name));
        }
        public static void Customer_Add(string name, string address, string phone)
        {
            DataAccessLayer.ExecuteNonQuery("Customer_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@address", SqlDbType.NVarChar, address),
                DataAccessLayer.CreateParameter("@phone", SqlDbType.NVarChar, phone));
        }

        public static void Customer_Update(int ID, string name, string address, string phone)
        {
            DataAccessLayer.ExecuteNonQuery("Customer_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, ID),
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@address", SqlDbType.NVarChar, address),
                DataAccessLayer.CreateParameter("@phone", SqlDbType.NVarChar, phone));
        }

        public static void Customer_Delete(int id)
        {
            DataAccessLayer.ExecuteNonQuery("Customer_Delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, id));
        }
    }
}
