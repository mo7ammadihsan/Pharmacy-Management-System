using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Pharmacy.DL
{
    class DataAccessLayer
    {
        private static string Con()
        {

            if (Properties.Settings.Default.Mode == true)
                return string.Format("Data Source={0}; Initial Catalog={1};Integrated Security=true", Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            else
                return string.Format("Data Source={0}; Initial Catalog={1};Integrated Security=false;User ID={2}; Password={3}", Properties.Settings.Default.Server, Properties.Settings.Default.Database, Properties.Settings.Default.Name, Properties.Settings.Default.Pass);

         }

        public static SqlConnection cn = new SqlConnection(Con());      

        private static void Open()
        {
            if (cn.State == ConnectionState.Closed)
            {
                try
                {
                    cn.Open();
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
                
        }

        private static void Close()
        {
            if (cn.State == ConnectionState.Open)
            {
                try
                {
                    cn.Close();
                }
                catch (SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
                
        }
        public static void ExecuteNonQuery(string Query, CommandType Type, params SqlParameter[] parameters)
        {
            try
            {
                Open();
                SqlCommand Command = new SqlCommand(Query, cn);
                Command.CommandType = Type;
                Command.Parameters.AddRange(parameters);
                Command.ExecuteNonQuery();
                Close();
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public static DataTable ExecuteTable(string Query, CommandType Type, params SqlParameter[] parameters)
        {
            try
            {
                Open();
                SqlCommand Command = new SqlCommand(Query, cn);
                Command.CommandType = Type;
                Command.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(Command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Close();
                return dt;
            }
            catch (SqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return new DataTable();
            }

        }

        public static SqlParameter CreateParameter(string name, SqlDbType Type, object Value)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = name;
            param.SqlDbType = Type;
            param.Value = Value;
            return param;
        }

    }
}
