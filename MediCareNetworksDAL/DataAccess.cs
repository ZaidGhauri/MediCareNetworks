using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Configuration;

namespace MediCareNetworksDAL
{
    public class DataAccess
    {
        //string ConnectionString = "Data Source=(local);Initial Catalog=MediCare; User Id=sa; Password=Usman123";
        string ConnectionString = ConfigurationManager.ConnectionStrings["MediCare"].ConnectionString.ToString();
        
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public bool IsLogin()
        {
            //Session["UserLoginID"].ToString() != "" || Session["UserLoginID"].ToString() != string.Empty || 
            //if (Session["UserLoginID"] != null)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        public bool IsEmailValid(string Email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                return addr.Address == Email;
            }
            catch
            {
                return false;
            }

        }

        public DataTable GetDatatable(string SPName, string[] paramNames, object[] paramValues)
        {
            try
            {

                SqlConnection cnn = new SqlConnection(ConnectionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(SPName, (SqlConnection)cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < paramNames.Length; i++)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = paramNames[i];
                    p.Value = paramValues[i];
                    cmd.Parameters.Add(p);
                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);

                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable GetDatatable(string SPName)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(SPName, (SqlConnection)cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);

                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public int ExecuteNonQuery(string SPName, string[] paramNames, object[] paramValues)
        {
            try
            {
                int rowsAffected = 0;
                SqlConnection cnn = new SqlConnection(ConnectionString);
                cnn.Open();
                SqlCommand cmd = new SqlCommand(SPName, (SqlConnection)cnn);
                cmd.CommandType = CommandType.StoredProcedure;

                for (int i = 0; i < paramNames.Length; i++)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = paramNames[i];
                    p.Value = paramValues[i];
                    cmd.Parameters.Add(p);
                }
                rowsAffected = cmd.ExecuteNonQuery();

                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                if (cnn != null)
                {
                    cnn.Dispose();
                }
                return rowsAffected;
            }
            catch
            {
                return -1;
            }
        }

        public DataSet GetDataset(string SPName)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(SPName, (SqlConnection)cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);

                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public DataSet GetDataset(string SPName, string[] paramNames, object[] paramValues)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand(SPName, (SqlConnection)cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < paramNames.Length; i++)
                {
                    var p = cmd.CreateParameter();
                    p.ParameterName = paramNames[i];
                    p.Value = paramValues[i];
                    cmd.Parameters.Add(p);
                }

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter((SqlCommand)cmd);

                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

    }
}
