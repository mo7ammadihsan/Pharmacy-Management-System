using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Sales
    {
        public static DataTable Sales_Select_Search(string search)
        {
            return DataAccessLayer.ExecuteTable("Sales_Select_Search", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
        }

        public static DataTable Sales_Select_Date(string first, string secound)
        {
            return DataAccessLayer.ExecuteTable("Sales_Select_Date", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@first", SqlDbType.Date, first),
                DataAccessLayer.CreateParameter("@secound", SqlDbType.Date, secound));
        }

        public static DataTable Sales_Select_Today(string date)
        {
            return DataAccessLayer.ExecuteTable("Sales_Select_Today", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@date", SqlDbType.Date, date));
        }

        public static void Sales_Update(int ID, int Count, string paid, string amount, string total)
        {
            DataAccessLayer.ExecuteNonQuery("Sales_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Sales_ID", SqlDbType.Int, ID),
                DataAccessLayer.CreateParameter("@Sales_Count", SqlDbType.Int, Count),
                DataAccessLayer.CreateParameter("@Sales_Paid", SqlDbType.NVarChar, paid),
                DataAccessLayer.CreateParameter("@Sales_Amount", SqlDbType.NVarChar, amount),
                DataAccessLayer.CreateParameter("@Sales_Total", SqlDbType.NVarChar, total));
        }

        public static void Sales_Delete()
        {
            DataAccessLayer.ExecuteNonQuery("Sales_Delete", CommandType.StoredProcedure);
        }
        public static DataTable Sales_Select_Loan()
        {
            return DataAccessLayer.ExecuteTable("Sales_Select_Loan", CommandType.StoredProcedure);
        }

        public static DataTable Sales_Select_Loan_Customer(int id)
        {
            return DataAccessLayer.ExecuteTable("Sales_Select_Loan_Customer", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));
        }
        public static DataTable Max_ID()
        {
            return DataAccessLayer.ExecuteTable("select ISNULL(MAX(Sales_ID)+1,1) from Sales", CommandType.Text);
        }

        public static void Sales_Insert(string Date, int Cus_ID, string Notes, string User_Added, int Count, int Discount, string Paid, string Residul, string Amount, string Total)
        {
            DataAccessLayer.ExecuteNonQuery("Sales_Insert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Date", SqlDbType.DateTime, Date),
                DataAccessLayer.CreateParameter("@Cust_ID", SqlDbType.Int, Cus_ID),
                DataAccessLayer.CreateParameter("@Notes", SqlDbType.NVarChar, Notes),
                DataAccessLayer.CreateParameter("@User_Added", SqlDbType.NVarChar, User_Added),
                DataAccessLayer.CreateParameter("@Count", SqlDbType.Int, Count),
                DataAccessLayer.CreateParameter("@Discount", SqlDbType.Int, Discount),
                DataAccessLayer.CreateParameter("@Paid", SqlDbType.NVarChar, Paid),
                DataAccessLayer.CreateParameter("@Residul", SqlDbType.NVarChar, Residul),
                DataAccessLayer.CreateParameter("@Amount", SqlDbType.NVarChar, Amount),
                DataAccessLayer.CreateParameter("@Total", SqlDbType.NVarChar, Total));
        }

        public static void Sales_Loan_Update(int id, string residual, string paid, string note)
        {
            DataAccessLayer.ExecuteNonQuery("Sales_Loan_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@Paid", SqlDbType.NVarChar, paid),
                DataAccessLayer.CreateParameter("@Residul", SqlDbType.NVarChar, residual),
                DataAccessLayer.CreateParameter("@Note", SqlDbType.NVarChar, note));
        }
    }
}
