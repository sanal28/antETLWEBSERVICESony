using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace NuPortalWebservice
{
    /// <summary>
    /// Summary description for NuPortalService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NuPortalService : System.Web.Services.WebService
    {
        public string connection { get; set; }
        [WebMethod]
        public string LoginInfo(string UserName, string Password, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.getLoginInfo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramUserName, UserName);
                cmd.Parameters.AddWithValue(Constants.ParamPassword, Password);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);

                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(Constants.loginInfoTable);
                dataTable.Load(dataReader);
                if (dataTable.Rows.Count > 0)
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        [WebMethod]
        public string GetDDListBox(int Id, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.getDDLBox;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramId, Id);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);

                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(Constants.ddlTable);
                dataTable.Load(dataReader);
                if (dataTable.Rows.Count > 0)
                {
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                    Dictionary<string, object> row;
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        row = new Dictionary<string, object>();
                        foreach (DataColumn col in dataTable.Columns)
                        {
                            row.Add(col.ColumnName, dr[col]);
                        }
                        rows.Add(row);
                    }
                    return serializer.Serialize(rows);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        [WebMethod]
        public string SelectGridInfo(int Id, int Operation)
        {

            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.GridOperation;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramId, Id);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);

                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(Constants.ddlTable);
                dataTable.Load(dataReader);
                if (dataTable.Rows.Count > 0)
                {
                    return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        [WebMethod]
        public string SelectDetailsByMonth(int EmpId, int Month, int Year, int Operation)
        {

            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.GetTaskDetailsByMonth;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramId, EmpId);
                cmd.Parameters.AddWithValue(Constants.paramMonth, Month);
                cmd.Parameters.AddWithValue(Constants.paramYear, Year);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);
                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(Constants.ddlTable);
                dataTable.Load(dataReader);
                dataTable.Load(dataReader);
                if (dataTable.Rows.Count > 0)
                {
                    return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        [WebMethod]
        public string CancelItem(int Id, int EmpId, int Operation)
        {

            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.CancelItem;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramId, Id);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, EmpId);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);

                var dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(Constants.ddlTable);
                dataTable.Load(dataReader);
                if (dataTable.Rows.Count > 0)
                {
                    return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { con.Close(); }
        }

        [WebMethod]
        public string GetFilterForGrid(string JsonData, int EmpId, int Offset, int RowCount, int Operation)
        {
            //string XmlField1, string XmlField2, string XmlField3, string XmlField4, string XmlField5,
            //string XmlField6, string XmlField7,string XmlField8 
            Dictionary<string, string> dictvalues;
            SqlConnection con = new SqlConnection();
            Common_Library.CommonFunctions obj = new Common_Library.CommonFunctions();
            try
            {
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.UspFilterGrid;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                if (JsonData != string.Empty)
                {
                    dictvalues = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonData);
                    foreach (KeyValuePair<string, string> item in dictvalues)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, obj.BuildXml(item.Value));
                    }
                }
                cmd.Parameters.AddWithValue(Constants.colEmpId, EmpId);
                cmd.Parameters.AddWithValue(Constants.paramOffset, Offset);
                cmd.Parameters.AddWithValue(Constants.paramRowCount, RowCount);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);
                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(Constants.employeeProfileCompletedTable);
                dataTable.Load(dataReader);
                if (dataTable.Rows.Count > 0)
                {
                    return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                con.Close();
                dictvalues = null;
                obj = null;
            }
        }

        [WebMethod]
        public string ChangePassword(string OldPassword, string NewPassword, int EmpId, int Operation)
        {
            SqlConnection con = new SqlConnection();
            Common_Library.CommonFunctions funMail = new Common_Library.CommonFunctions();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.UspChangePassword;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramOldPassword, OldPassword);
                cmd.Parameters.AddWithValue(Constants.ParamNewPassword, NewPassword);
                cmd.Parameters.AddWithValue(Constants.paramFKEmpId, EmpId);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(Constants.loginInfoTable);
                dataTable.Load(dataReader);
                if (dataTable.Rows.Count > 0)
                {
                    if (dataTable.Columns.Contains("ToAddress"))
                    {
                        string msgBody = "Hi " + Convert.ToString(dataTable.Rows[0]["Name"]) + ",<br/><br/> The password for your Nuvento Portal account has been successfully changed." +
                             " If you did not request this change, please contact support immediately.";
                        if (funMail.SendEmail(Convert.ToString(dataTable.Rows[0]["ToAddress"]), "", "", "Password Change", msgBody))
                            return JsonConvert.SerializeObject("{\"UserUpdated\" : 1}", Formatting.Indented);
                        else
                            return string.Empty;
                    }
                    else
                        return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
                }
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                funMail = null;
            }
        }
    }
}
