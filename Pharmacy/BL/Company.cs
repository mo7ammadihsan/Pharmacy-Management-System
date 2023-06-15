using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Company
    {
        public static DataTable company_Info_select()
        {
            return DataAccessLayer.ExecuteTable("company_Info_select", CommandType.StoredProcedure);
        }

        public static void company_Info_Update(string name, string address, string phone, byte[] image)
        {
            DataAccessLayer.ExecuteNonQuery("company_Info_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@Address", SqlDbType.NVarChar, address),
                DataAccessLayer.CreateParameter("@Phone", SqlDbType.NVarChar, phone),
                DataAccessLayer.CreateParameter("@Logo", SqlDbType.Image, image));
        }
    }
}
