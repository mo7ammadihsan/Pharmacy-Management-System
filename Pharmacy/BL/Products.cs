using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Pharmacy.DL;

namespace Pharmacy.BL
{
    class Products
    {
        public static DataTable Producs_Select_Search(string Search)
        {
            return DataAccessLayer.ExecuteTable("Products_Select_Search", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@Search", SqlDbType.NVarChar, Search));
        }

        public static DataTable Products_Select_Cashier()
        {
            return DataAccessLayer.ExecuteTable("Products_Select_Cashier", CommandType.StoredProcedure);
        }

        public static DataTable Products_Validate_Barcode(string barcode)
        {
            return DataAccessLayer.ExecuteTable("Products_Validate_Barcode", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@barcode", SqlDbType.NVarChar, barcode));
        }

        public static DataTable Products_Barcode(string barcode, int num)
        {
            string query = string.Format("select * from Products where Barcode='{0}'", barcode);
            for (int i = 0; i < num - 1; i++)
            {
                query += string.Format("union all select * from Products where Barcode='{0}'", barcode);
            }
            return DataAccessLayer.ExecuteTable(query, CommandType.Text);

        }

        public static DataTable Products_Select_Id(int id)
        {
            return DataAccessLayer.ExecuteTable("Products_Select_Id", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));
        }
        public static void products_add(string name, string description, string buyprice, string sellprice, string barcode, int cat, int sn, int com, int filling, string filling_price, bool active)
        {
            DataAccessLayer.ExecuteNonQuery("products_add", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                DataAccessLayer.CreateParameter("@description", SqlDbType.NVarChar, description),
                  DataAccessLayer.CreateParameter("@buyprice", SqlDbType.NVarChar, buyprice),
                   DataAccessLayer.CreateParameter("@sellprice", SqlDbType.NVarChar, sellprice),
                    DataAccessLayer.CreateParameter("@barcode", SqlDbType.NVarChar, barcode),
                     DataAccessLayer.CreateParameter("@cat", SqlDbType.Int, cat),
                      DataAccessLayer.CreateParameter("@com", SqlDbType.Int, com),
                       DataAccessLayer.CreateParameter("@sn", SqlDbType.Int, sn),
                        DataAccessLayer.CreateParameter("@filling", SqlDbType.Int, filling),
                         DataAccessLayer.CreateParameter("@filling_price", SqlDbType.NVarChar, filling_price),
                          DataAccessLayer.CreateParameter("@active", SqlDbType.Bit, active));

        }
        public static void products_Update(string name, string description, string buyprice, string sellprice, string barcode, int cat, int sn, int com, int filling, string filling_price, int id, bool active)
        {
            DataAccessLayer.ExecuteNonQuery("products_Update", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@name", SqlDbType.NVarChar, name),
                 DataAccessLayer.CreateParameter("@description", SqlDbType.NVarChar, description),
                      DataAccessLayer.CreateParameter("@buyprice", SqlDbType.NVarChar, buyprice),
                       DataAccessLayer.CreateParameter("@sellprice", SqlDbType.NVarChar, sellprice),
                        DataAccessLayer.CreateParameter("@barcode", SqlDbType.NVarChar, barcode),
                         DataAccessLayer.CreateParameter("@cat_id", SqlDbType.Int, cat),
                          DataAccessLayer.CreateParameter("@com_id", SqlDbType.Int, com),
                           DataAccessLayer.CreateParameter("@sn_id", SqlDbType.Int, sn),
                            DataAccessLayer.CreateParameter("@p_filling", SqlDbType.Int, filling),
                             DataAccessLayer.CreateParameter("@p_filling_price", SqlDbType.NVarChar, filling_price),
                             DataAccessLayer.CreateParameter("@active", SqlDbType.Bit, active));
        }

        public static void products_UpdatePrice(string buyprice, string sellprice, int filling, string filling_price, int id)
        {
            DataAccessLayer.ExecuteNonQuery("products_UpdatePrice", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id),
                      DataAccessLayer.CreateParameter("@buyprice", SqlDbType.NVarChar, buyprice),
                       DataAccessLayer.CreateParameter("@sellprice", SqlDbType.NVarChar, sellprice),
                            DataAccessLayer.CreateParameter("@p_filling", SqlDbType.Int, filling),
                             DataAccessLayer.CreateParameter("@p_filling_price", SqlDbType.NVarChar, filling_price));
        }

        public static void Products_Delete(int id)
        {
            DataAccessLayer.ExecuteNonQuery("Products_Delete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id));
        }
    }
}
