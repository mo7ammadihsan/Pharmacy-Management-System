using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Login
    {
        public static DataTable login(string name, string pass)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Login", CommandType.StoredProcedure,
                    DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                    DataAccessLayer.CreateParameter("@pass", SqlDbType.NVarChar, pass));
            return dt;
        }
    }
}
