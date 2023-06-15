using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Producer_Company
    {
        public static DataTable Producer_Company_Select_Search(string search)
        {
            return DataAccessLayer.ExecuteTable("Producer_Company_Select_Search", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Search", SqlDbType.NVarChar, search));
        }
        public static DataTable Producer_Company_Validate(string name, string phone)
        {
            return DataAccessLayer.ExecuteTable("Producer_Company_Validate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@Phone", SqlDbType.NVarChar, phone));
        }
        public static DataTable Producer_Company_ComboBox()
        {
            return DataAccessLayer.ExecuteTable("Producer_Company_ComboBox", CommandType.StoredProcedure);
        }
        public static void Producer_Company_Add(string Name, string Address, string Notes, string Phone, bool Status)
        {
            DataAccessLayer.ExecuteTable("Producer_Company_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, Name),
               DataAccessLayer.CreateParameter("@Address", SqlDbType.NVarChar, Address),
               DataAccessLayer.CreateParameter("@Notes", SqlDbType.NVarChar, Notes),
               DataAccessLayer.CreateParameter("@Phone", SqlDbType.NVarChar, Phone),
               DataAccessLayer.CreateParameter("@Satus", SqlDbType.Bit, Status));
        }

        public static void Producer_Company_Update(string Name, string Address, string Notes, string Phone, bool Status, int id)
        {
            DataAccessLayer.ExecuteTable("Producer_Company_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Name", SqlDbType.NVarChar, Name),
               DataAccessLayer.CreateParameter("@Address", SqlDbType.NVarChar, Address),
               DataAccessLayer.CreateParameter("@Notes", SqlDbType.NVarChar, Notes),
               DataAccessLayer.CreateParameter("@Phone", SqlDbType.NVarChar, Phone),
               DataAccessLayer.CreateParameter("@Satus", SqlDbType.Bit, Status),
               DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));
        }
        public static void Producer_Company_Delete(int ID)
        {
            DataAccessLayer.ExecuteNonQuery("Producer_Company_Delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@ID", SqlDbType.Int, ID));
        }
    }
}
