using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Purchases
    {
        public static DataTable Purchases_Select_Search(string search)
        {
            return DataAccessLayer.ExecuteTable("Purchases_Select_Search", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
        }

        public static DataTable Purchases_Select_Date(string first, string secound)
        {
            return DataAccessLayer.ExecuteTable("Purchases_Select_Date", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@first", SqlDbType.Date, first),
                DataAccessLayer.CreateParameter("@secound", SqlDbType.Date, secound));
        }

        public static DataTable Purchases_Select_Dateofnow(string date)
        {
            return DataAccessLayer.ExecuteTable("Purchases_Select_Dateofnow", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@date", SqlDbType.Date, date));
        }

        public static DataTable Purchases_Select_Loan()
        {
            return DataAccessLayer.ExecuteTable("Purchases_Select_Loan", CommandType.StoredProcedure);
        }

        public static DataTable Purchases_Select_Loan_With_Supplier(int id)
        {
            return DataAccessLayer.ExecuteTable("Purchases_Select_Loan_With_Supplier", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));
        }
        public static DataTable Max_ID()
        {
            return DataAccessLayer.ExecuteTable("select ISNULL(MAX(Purchases_ID)+1,1) from Purchases", CommandType.Text);
        }

        public static void Purchases_Insert(string Date, int Supp_ID, string Notes, string User_Added, int Count, int Discount, string Paid, string Residul, string Amount, string Total)
        {
            DataAccessLayer.ExecuteNonQuery("Purchases_Insert", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Date", SqlDbType.DateTime, Date),
                DataAccessLayer.CreateParameter("@Supp_ID", SqlDbType.Int, Supp_ID),
                DataAccessLayer.CreateParameter("@Notes", SqlDbType.NVarChar, Notes),
                DataAccessLayer.CreateParameter("@User_Added", SqlDbType.NVarChar, User_Added),
                DataAccessLayer.CreateParameter("@Count", SqlDbType.Int, Count),
                DataAccessLayer.CreateParameter("@Discount", SqlDbType.Int, Discount),
                DataAccessLayer.CreateParameter("@Paid", SqlDbType.NVarChar, Paid),
                DataAccessLayer.CreateParameter("@Residul", SqlDbType.NVarChar, Residul),
                DataAccessLayer.CreateParameter("@Amount", SqlDbType.NVarChar, Amount),
                DataAccessLayer.CreateParameter("@Total", SqlDbType.NVarChar, Total));
        }

        public static void Purchases_Loan_Update(int id, string residual, string paid, string note)
        {
            DataAccessLayer.ExecuteNonQuery("Purchases_Loan_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@Paid", SqlDbType.NVarChar, paid),
                DataAccessLayer.CreateParameter("@Residul", SqlDbType.NVarChar, residual),
                DataAccessLayer.CreateParameter("@Note", SqlDbType.NVarChar, note));
        }
    }
}
