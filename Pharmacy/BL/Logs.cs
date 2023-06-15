using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Logs
    {
        public static DataTable Logs_Select_Between(string first, string last)
        {
            return DataAccessLayer.ExecuteTable("Logs_Select_Between", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@first", SqlDbType.Date, first),
                DataAccessLayer.CreateParameter("@last", SqlDbType.Date, last));
        }

        public static DataTable Logs_Select_Today(string date)
        {
            return DataAccessLayer.ExecuteTable("Logs_Select_Today", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@date", SqlDbType.Date, date));
        }

        public static DataTable Logs_Select_Search(string search)
        {
            return DataAccessLayer.ExecuteTable("Logs_Select_Search", CommandType.StoredProcedure,
                  DataAccessLayer.CreateParameter("@Search", SqlDbType.NVarChar, search));
        }
        public static void Logs_Add(string name, string date, string operations)
        {
            DataAccessLayer.ExecuteNonQuery("Logs_Add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@date", SqlDbType.DateTime, date),
                DataAccessLayer.CreateParameter("@operations", SqlDbType.NVarChar, operations));
        }

        public static void Logs_Delete(long id)
        {
            DataAccessLayer.ExecuteNonQuery("Logs_Delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id));
        }
    }
}
