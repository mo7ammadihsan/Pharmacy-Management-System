using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Suppliers
    {
        public static DataTable Suppliers_Select_Search(string search)
        {
            return DataAccessLayer.ExecuteTable("Suppliers_Select_Search", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
        }
        public static DataTable Suppliers_Validate(string name)
        {
            return DataAccessLayer.ExecuteTable("Suppliers_Validate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name));
        }
        public static void Suppliers_Add(string name, string phone, int city)
        {
            DataAccessLayer.ExecuteTable("Suppliers_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@phone", SqlDbType.NVarChar, phone),
                DataAccessLayer.CreateParameter("@city", SqlDbType.Int, city));
        }
        public static void Suppliers_Update(int id, string name, string phone, int city)
        {
            DataAccessLayer.ExecuteTable("Suppliers_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@phone", SqlDbType.NVarChar, phone),
                DataAccessLayer.CreateParameter("@city", SqlDbType.Int, city));
        }

        public static void Suppliers_Delete(int id)
        {
            DataAccessLayer.ExecuteTable("Suppliers_Delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, id));
        }
    }
}
