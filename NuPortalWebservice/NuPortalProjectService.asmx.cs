﻿using Newtonsoft.Json;
using NuPortalWebservice.Common_Library;
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
    /// Summary description for NuPortalProject
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NuPortalProject : System.Web.Services.WebService
    {
        public string connection { get; set; }
        Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
        [WebMethod]
        public string CreateClient(int CompanyId, string CompanyName, string Website, string PurchaseOrderNumber, string CompanyLogo,
            DateTime CreatedDate, DateTime ModifiedDate, int CreatedEmpId, int ModifiedEmpId, int Status)

        {

            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.setClientInfoOper;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramFKCompanyId, CompanyId);
                cmd.Parameters.AddWithValue(Constants.ParamCompanyName, CompanyName);
                cmd.Parameters.AddWithValue(Constants.paramWebsite, Website);
                cmd.Parameters.AddWithValue(Constants.ParamPurchaseOrderNumber, PurchaseOrderNumber);
                cmd.Parameters.AddWithValue(Constants.paramCompanyLogo, CompanyLogo);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(Constants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedEmpID, CreatedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramStatus, Status);
                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SetClientAddress(int Id, string jsonClientAddress)
        {
            if (comfun.DeleteRecords(Id, 11))
            {
                SqlConnection con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                using (SqlTransaction sqlTransaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = Constants.tblClientAddress;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(Constants.ClientId, Constants.colFKClientId);
                            sqlBulkCopy.ColumnMappings.Add(Constants.AddressType, Constants.colAddressType);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Address, Constants.Address);
                            sqlBulkCopy.ColumnMappings.Add(Constants.City, Constants.colCity);
                            sqlBulkCopy.ColumnMappings.Add(Constants.State, Constants.colState);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Country, Constants.colCountry);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Zip, Constants.colZip);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Phone, Constants.colPhone);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Fax, Constants.colFax);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonClientAddress));
                            sqlTransaction.Commit();

                        }
                        return true;
                    }
                    catch (Exception e)
                    {
                        sqlTransaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public bool CreateContact(int ClientId, string ContactPerson, string ContactNumber, string Extension, string Mobile, string Designation,
            string Email, string Fax, string Department, DateTime CreatedDate, DateTime ModifiedDate, int CreatedEmpId, int ModifiedEmpId, int Status)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.setProjectContactPersonOper;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramFKClientId, ClientId);
                cmd.Parameters.AddWithValue(Constants.ParamContactPerson, ContactPerson);
                cmd.Parameters.AddWithValue(Constants.paramContactNumber, ContactNumber);
                cmd.Parameters.AddWithValue(Constants.paramExtension, Extension);
                cmd.Parameters.AddWithValue(Constants.ParamMobile, Mobile);
                cmd.Parameters.AddWithValue(Constants.ParamDesignation, Designation);
                cmd.Parameters.AddWithValue(Constants.paramEmail, Email);
                cmd.Parameters.AddWithValue(Constants.ParamFax, Fax);
                cmd.Parameters.AddWithValue(Constants.paramDepartment, Department);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(Constants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedEmpID, CreatedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramStatus, Status);
                IDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.RecordsAffected == 1)
                {
                    return true;

                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string CreateProject(int CompanyId, int ClientId, int ContactId, string Name, string Description, DateTime StartDate, DateTime EndDate,
            string URL, string Priority, string ProjectStatus, string ProjectType, string ProjectCategory, int PlannedHours, int FKDepartment, string CostCenter,
            string Technologies, string Attachments, DateTime CreatedDate, DateTime ModifiedDate, int CreatedEmpId, int ModifiedEmpId, int Status)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.UspSetProjects;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramFKCompanyId, CompanyId);
                cmd.Parameters.AddWithValue(Constants.paramFKClientId, ClientId);
                cmd.Parameters.AddWithValue(Constants.paramFKContactId, ContactId);
                cmd.Parameters.AddWithValue(Constants.ParamName, Name);
                cmd.Parameters.AddWithValue(Constants.paramDescription, Description);
                cmd.Parameters.AddWithValue(Constants.ParamStartDate, StartDate);
                cmd.Parameters.AddWithValue(Constants.ParamEndDate, EndDate);
                cmd.Parameters.AddWithValue(Constants.ParamURL, URL);
                cmd.Parameters.AddWithValue(Constants.ParamPriority, Priority);
                cmd.Parameters.AddWithValue(Constants.ParamProjectStatus, ProjectStatus);
                cmd.Parameters.AddWithValue(Constants.paramProjectType, ProjectType);
                cmd.Parameters.AddWithValue(Constants.paramProjectCategory, ProjectCategory);
                cmd.Parameters.AddWithValue(Constants.paramPlannedHours, PlannedHours);
                cmd.Parameters.AddWithValue(Constants.paramFKDepartment, FKDepartment);
                cmd.Parameters.AddWithValue(Constants.ParamCostCenter, CostCenter);
                cmd.Parameters.AddWithValue(Constants.paramTechnologies, Technologies);
                cmd.Parameters.AddWithValue(Constants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(Constants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedEmpID, CreatedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramStatus, Status);
                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SetMangersForProjects(int Id, string jsonMangersForProjects)
        {
            if (comfun.DeleteRecords(Id, 13))
            {
                SqlConnection con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                using (SqlTransaction sqlTransaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = Constants.tblMangersForProjects;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(Constants.ProjectId, Constants.colFKProjectId);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Managers, Constants.colFKManagers);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Status, Constants.colStatus);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonMangersForProjects));
                            sqlTransaction.Commit();

                        }
                        return true;
                    }
                    catch (Exception e)
                    {
                        sqlTransaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public bool SetResourcesForProjects(int Id, string jsonResourcesForProjects)
        {
            if (comfun.DeleteRecords(Id, 12))
            {
                SqlConnection con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                using (SqlTransaction sqlTransaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = Constants.tblResourcesForProjects;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(Constants.ProjectId, Constants.colFKProjectId);
                            sqlBulkCopy.ColumnMappings.Add(Constants.FKResources, Constants.colFKResources);
                            sqlBulkCopy.ColumnMappings.Add(Constants.FKRole, Constants.colFKRole);
                            sqlBulkCopy.ColumnMappings.Add(Constants.RatePerHour, Constants.colRatePerHour);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Allocation, Constants.colAllocation);
                            sqlBulkCopy.ColumnMappings.Add(Constants.BillingStatus, Constants.colBillingStatus);
                            sqlBulkCopy.ColumnMappings.Add(Constants.BillingHours, Constants.colBillingHours);
                            sqlBulkCopy.ColumnMappings.Add(Constants.Status, Constants.colStatus);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonResourcesForProjects));
                            sqlTransaction.Commit();

                        }
                        return true;
                    }
                    catch (Exception e)
                    {
                        sqlTransaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public bool UpdateContact(int ContactId, string ContactPerson, string ContactNumber, string Extension, string Mobile, string Designation,
           string Email, string Fax, string Department, DateTime ModifiedDate, int ModifiedEmpId, int Status)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.UpdateProjectContactPerson;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramContactId, ContactId);
                cmd.Parameters.AddWithValue(Constants.ParamContactPerson, ContactPerson);
                cmd.Parameters.AddWithValue(Constants.paramContactNumber, ContactNumber);
                cmd.Parameters.AddWithValue(Constants.paramExtension, Extension);
                cmd.Parameters.AddWithValue(Constants.ParamMobile, Mobile);
                cmd.Parameters.AddWithValue(Constants.ParamDesignation, Designation);
                cmd.Parameters.AddWithValue(Constants.paramEmail, Email);
                cmd.Parameters.AddWithValue(Constants.ParamFax, Fax);
                cmd.Parameters.AddWithValue(Constants.paramDepartment, Department);
                cmd.Parameters.AddWithValue(Constants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramStatus, Status);
                IDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    return true;

                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool UpdateClient(int ClientId, string CompanyName, string Website, string PurchaseOrderNumber, string CompanyLogo,
            DateTime ModifiedDate, int ModifiedEmpId, int Status)

        {

            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.UpdateClientInfo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramClientId, ClientId);
                cmd.Parameters.AddWithValue(Constants.ParamCompanyName, CompanyName);
                cmd.Parameters.AddWithValue(Constants.paramWebsite, Website);
                cmd.Parameters.AddWithValue(Constants.ParamPurchaseOrderNumber, PurchaseOrderNumber);
                cmd.Parameters.AddWithValue(Constants.paramCompanyLogo, CompanyLogo);
                cmd.Parameters.AddWithValue(Constants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramStatus, Status);
                IDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    return true;

                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool UpdateProject(int ProjectId, int ClientId, int ContactId, string Name, string Description, DateTime StartDate, DateTime EndDate,
           string URL, string Priority, string ProjectStatus, string ProjectType, string ProjectCategory, int PlannedHours, int FKDepartment, string CostCenter,
           string Technologies, string Attachments, DateTime ModifiedDate, int ModifiedEmpId, int Status)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.UpdateProjects;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramProjectId, ProjectId);
                cmd.Parameters.AddWithValue(Constants.paramFKClientId, ClientId);
                cmd.Parameters.AddWithValue(Constants.paramFKContactId, ContactId);
                cmd.Parameters.AddWithValue(Constants.ParamName, Name);
                cmd.Parameters.AddWithValue(Constants.paramDescription, Description);
                cmd.Parameters.AddWithValue(Constants.ParamStartDate, StartDate);
                cmd.Parameters.AddWithValue(Constants.ParamEndDate, EndDate);
                cmd.Parameters.AddWithValue(Constants.ParamURL, URL);
                cmd.Parameters.AddWithValue(Constants.ParamPriority, Priority);
                cmd.Parameters.AddWithValue(Constants.ParamProjectStatus, ProjectStatus);
                cmd.Parameters.AddWithValue(Constants.paramProjectType, ProjectType);
                cmd.Parameters.AddWithValue(Constants.paramProjectCategory, ProjectCategory);
                cmd.Parameters.AddWithValue(Constants.paramPlannedHours, PlannedHours);
                cmd.Parameters.AddWithValue(Constants.paramFKDepartment, FKDepartment);
                cmd.Parameters.AddWithValue(Constants.ParamCostCenter, CostCenter);
                cmd.Parameters.AddWithValue(Constants.paramTechnologies, Technologies);
                cmd.Parameters.AddWithValue(Constants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(Constants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramStatus, Status);
                IDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    return true;

                }
                else
                {

                    return false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string ProjectTaskOper(int TaskId, int ProjectId, string TaskName, DateTime StartDate, DateTime EndDate, float PlannedHours, string ProjectPhase,
           int TaskStatusId, string TaskDetails, string Comments, string Priority, int Billable, string Attachments,
           DateTime CreatedDate, DateTime ModifiedDate, int CreatedEmpId, int ModifiedEmpId, int Status, int Operation,int Flag, int UpdateFlag)

        {
            SqlConnection con = new SqlConnection();
            NuPortalRequestService requestService = new NuPortalRequestService();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = ProjectConstants.UspProjectTask;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(ProjectConstants.paramTaskId, TaskId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramFkProjectId, ProjectId);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamTaskName, TaskName);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamStartDate, StartDate);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamEndDate, EndDate);
                cmd.Parameters.AddWithValue(ProjectConstants.paramPlannedHours, PlannedHours);
                cmd.Parameters.AddWithValue(ProjectConstants.paramProjectPhase, ProjectPhase);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamTaskStatus, TaskStatusId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramTaskDetails, TaskDetails);
                cmd.Parameters.AddWithValue(ProjectConstants.paramComments, Comments);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamPriority, Priority);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamBillable, Billable);
                cmd.Parameters.AddWithValue(ProjectConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(ProjectConstants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamCreatedEmpID, CreatedEmpId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamStatus, Status);
                cmd.Parameters.AddWithValue(ProjectConstants.paramOperation, Operation);
                IDataReader dataReader = cmd.ExecuteReader();
                if (Operation == 2 || Operation == 3)
                {
                    int statusId = 0;
                    if (Operation == 2)
                        statusId = 13;
                    else
                        statusId = 14;
                    if (UpdateFlag == 1)
                    {
                        if (requestService.SendEmail(dataReader, statusId, false))
                        {
                            return JsonConvert.SerializeObject("{\"TaskId\" : 1}", Formatting.Indented);
                        }
                        else
                        {
                            return "";
                        }

                    }
                    else
                        return JsonConvert.SerializeObject("{\"TaskId\" : 1}", Formatting.Indented);

                }
                else
                {

                    DataTable dataTable = new DataTable();
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
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SetResourceForTask(int Id, string jsonResourceForTask, string EmpIdData)
        {
            if (comfun.DeleteRecords(Id, 35))
            {
                SqlConnection con = new SqlConnection();
                NuPortalRequestService requestService = new NuPortalRequestService();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                using (SqlTransaction sqlTransaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = ProjectConstants.tblProjectTaskResources;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.TaskId, ProjectConstants.colFKTaskId);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.TaskResources, ProjectConstants.colFKTaskResources);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.Status, ProjectConstants.colStatus);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.FkTaskStatusId, ProjectConstants.colFkTaskStatusId);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonResourceForTask));
                            sqlTransaction.Commit();
                            string[] XmlEmps = EmpIdData.Split('|');
                            string XmlData = "<TimeSheet>";
                            for (int i = 0; i < XmlEmps.Length - 1; i++)
                            {
                                XmlData = XmlData + "<FK_EmpId>" + XmlEmps[i] + "</FK_EmpId>";
                            }
                            XmlData = XmlData + "</TimeSheet>";
                            cmd.Connection = con;
                            cmd.CommandText = Constants.GetTimeSheetReport;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 300;
                            cmd.Parameters.AddWithValue(Constants.XmlDataToDb, XmlData);
                            cmd.Parameters.AddWithValue(Constants.paramOperId, 4);
                            IDataReader dataReader = cmd.ExecuteReader();
                            if (requestService.SendEmail(dataReader, 12, false))
                                return true;
                            else
                                return false;
                        }
                    }
                    catch (Exception e)
                    {
                        sqlTransaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public string ProjectDocumentsOper(int DocumentId, int ProjectId, string DocumentName, int SharedTypeId, int FKRoleId, string Description, string Attachments,
          DateTime CreatedDate, DateTime ModifiedDate, int CreatedEmpId, int ModifiedEmpId, int Status, int Operation)

        {
            SqlConnection con = new SqlConnection();
            NuPortalRequestService requestService = new NuPortalRequestService();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = ProjectConstants.UspProjectDocument;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(ProjectConstants.paramDocumentId, DocumentId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramFKProjectId, ProjectId);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamDocumentName, DocumentName);
                cmd.Parameters.AddWithValue(ProjectConstants.paramFKSharedTypeId, SharedTypeId);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamFKRoleId, FKRoleId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramDescription, Description);
                cmd.Parameters.AddWithValue(ProjectConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(ProjectConstants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamCreatedEmpID, CreatedEmpId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamStatus, Status);
                cmd.Parameters.AddWithValue(ProjectConstants.paramOperation, Operation);
                IDataReader dataReader = cmd.ExecuteReader();
                if (Operation == 1 && (SharedTypeId == 1 || SharedTypeId == 2 || SharedTypeId == 3))
                {
                    if (requestService.SendEmail(dataReader, 11, false))
                    {
                        return JsonConvert.SerializeObject("{\"DocId\" : 1}", Formatting.Indented);
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    DataTable dataTable = new DataTable();
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
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SetCustomDocuments(int Id, string jsonCustomResource, string EmpIdData)
        {
            if (comfun.DeleteRecords(Id, 32))
            {
                SqlConnection con = new SqlConnection();
                NuPortalRequestService requestService = new NuPortalRequestService();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                using (SqlTransaction sqlTransaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = ProjectConstants.tblCustomResources;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.SharedId, ProjectConstants.colFKSharedId);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.DocumentId, ProjectConstants.colFKDocumentId);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.SharedResource, ProjectConstants.colFKSharedResource);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.Status, ProjectConstants.colStatus);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonCustomResource));
                            sqlTransaction.Commit();
                            string[] XmlEmps = EmpIdData.Split('|');
                            string XmlData = "<TimeSheet>";
                            for (int i = 0; i < XmlEmps.Length - 1; i++)
                            {
                                XmlData = XmlData + "<FK_EmpId>" + XmlEmps[i] + "</FK_EmpId>";
                            }
                            XmlData = XmlData + "</TimeSheet>";
                            cmd.Connection = con;
                            cmd.CommandText = Constants.GetTimeSheetReport;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 300;
                            cmd.Parameters.AddWithValue(Constants.XmlDataToDb, XmlData);
                            cmd.Parameters.AddWithValue(Constants.paramId, 0);
                            cmd.Parameters.AddWithValue(Constants.paramOperId, 4);
                            cmd.Parameters.AddWithValue(Constants.paramOffset, 0);
                            cmd.Parameters.AddWithValue(Constants.paramRowCount, 0);
                            IDataReader dataReader = cmd.ExecuteReader();
                            if (requestService.SendEmail(dataReader, 11, false))
                                return true;
                            else
                                return false;
                        }
                    }
                    catch (Exception e)
                    {
                        sqlTransaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public bool SetTaskDetails(string Id, string jsonTaskDetails)
        {
            SqlConnection con = new SqlConnection();
            connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
            con.ConnectionString = connection;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            bool deleteFlag = true;
            if (Id != string.Empty)
            {
                string[] XmlEmps = Id.Split('|');
                string XmlData = "<TimeSheet>";
                for (int i = 0; i < XmlEmps.Length - 1; i++)
                {
                    XmlData = XmlData + "<TaskId>" + XmlEmps[i] + "</TaskId>";
                }
                XmlData = XmlData + "</TimeSheet>";

                cmd.CommandText = ProjectConstants.DeleteTaskDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(ProjectConstants.paramdeleteXml, XmlData);
                IDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    deleteFlag = true;

                }
                else
                {

                    deleteFlag = false;
                }
                con.Close();
            }
            if (deleteFlag)
            {
                con.Open();

                using (SqlTransaction sqlTransaction = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTransaction))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = ProjectConstants.tblTaskDetails;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.TaskId, ProjectConstants.colTaskId);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.EmpId, ProjectConstants.colEmpId);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.Hour, ProjectConstants.colHour);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.FK_RespondedBy, ProjectConstants.FK_RespondedBy);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.AssignedTo, ProjectConstants.AssignedTo);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.Date, ProjectConstants.colDate);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.WeekEndDate, ProjectConstants.colWeekEndDate);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.TicketStatusId, ProjectConstants.TicketStatusId);
                            sqlBulkCopy.ColumnMappings.Add(ProjectConstants.Status, ProjectConstants.colStatus);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonTaskDetails));
                            sqlTransaction.Commit();

                        }
                        return true;
                    }
                    catch (Exception e)
                    {
                        sqlTransaction.Rollback();
                        return false;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public string GetTimeSheetReport(string EmpIdData, DateTime StartDate, DateTime EndDate, int ProjectId, int Offset, int RowCount, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                string[] XmlEmps = EmpIdData.Split('|');
                string XmlData = "<TimeSheet>";
                for (int i = 0; i < XmlEmps.Length - 1; i++)
                {
                    XmlData = XmlData + "<FK_EmpId>" + XmlEmps[i] + "</FK_EmpId>";
                }
                XmlData = XmlData + "</TimeSheet>";
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.GetTimeSheetReport;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.XmlDataToDb, XmlData);
                cmd.Parameters.AddWithValue(Constants.paramId, ProjectId);
                if (StartDate.Year != 1753)
                    cmd.Parameters.AddWithValue(Constants.StartDate, StartDate);
                if (EndDate.Year != 1753)
                    cmd.Parameters.AddWithValue(Constants.EndDate, EndDate);
                cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);
                cmd.Parameters.AddWithValue(Constants.paramOffset, Offset);
                cmd.Parameters.AddWithValue(Constants.paramRowCount, RowCount);
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
            }
        }

        //[WebMethod] //Filter With timesheet
        //public string GetTimeSheetReport(string EmpIdData, DateTime StartDate, DateTime EndDate, int ProjectId, string JsonData,
        //    int Offset, int RowCount, int Operation)
        //{
        //    SqlConnection con = new SqlConnection();
        //    Dictionary<string, string> dictvalues;
        //    Common_Library.CommonFunctions obj = new Common_Library.CommonFunctions();
        //    try
        //    {
        //        string[] XmlEmps = EmpIdData.Split('|');
        //        string XmlData = "<TimeSheet>";
        //        for (int i = 0; i < XmlEmps.Length - 1; i++)
        //        {
        //            XmlData = XmlData + "<FK_EmpId>" + XmlEmps[i] + "</FK_EmpId>";
        //        }
        //        XmlData = XmlData + "</TimeSheet>";
        //        con = new SqlConnection();
        //        connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
        //        con.ConnectionString = connection;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = Constants.GetTimeSheetReport;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 300;
        //        con.Open();
        //        if (JsonData != string.Empty)
        //        {
        //            dictvalues = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonData);
        //            foreach (KeyValuePair<string, string> item in dictvalues)
        //            {
        //                cmd.Parameters.AddWithValue("@" + item.Key, obj.BuildXml(item.Value));
        //            }
        //        }
        //        cmd.Parameters.AddWithValue(Constants.XmlDataToDb, XmlData);
        //        cmd.Parameters.AddWithValue(Constants.paramId, ProjectId);
        //        if (StartDate.Year != 1753)
        //            cmd.Parameters.AddWithValue(Constants.StartDate, StartDate);
        //        if (EndDate.Year != 1753)
        //            cmd.Parameters.AddWithValue(Constants.EndDate, EndDate);
        //        cmd.Parameters.AddWithValue(Constants.paramOffset, Offset);
        //        cmd.Parameters.AddWithValue(Constants.paramRowCount, RowCount);
        //        cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);
        //        IDataReader dataReader = cmd.ExecuteReader();
        //        DataTable dataTable = new DataTable(Constants.employeeProfileCompletedTable);
        //        dataTable.Load(dataReader);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //    finally
        //    {
        //        con.Close();
        //        dictvalues = null;
        //        obj = null;
        //    }
        //}
        [WebMethod]
        public string selectTaskDetails(int EmpId, DateTime WeekEnd)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = ProjectConstants.SelectTaskDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(ProjectConstants.ParamEmpId, EmpId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramWeekEnd, WeekEnd);
                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string SendMailToResource(int ProjId, string EmpId, int ModEmpId, int Operation)
        {
            string toAddress;
            string typeName;
            string name;
            string resource;
            string projectName;
            string subject = string.Empty;
            string msgBody = string.Empty;
            string ccAddress = string.Empty;
            string bccAddress = string.Empty;
            int place;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection();
            NuPortalRequestService requestService = new NuPortalRequestService();
            IDataReader dataReader;
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = ProjectConstants.UspSendMailToResource;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                string[] XmlEmps = EmpId.Split('|');
                string XmlData = "<TimeSheet>";
                for (int i = 0; i < XmlEmps.Length - 1; i++)
                {
                    XmlData = XmlData + "<FK_EmpId>" + XmlEmps[i] + "</FK_EmpId>";
                }
                XmlData = XmlData + "</TimeSheet>";
                con.Open();
                cmd.Parameters.AddWithValue(ProjectConstants.paramProjectId, ProjId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramEmpId, XmlData);
                cmd.Parameters.AddWithValue(ProjectConstants.ParamModifiedEmpID, ModEmpId);
                cmd.Parameters.AddWithValue(ProjectConstants.paramOppId, Operation);
                dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        toAddress = string.Empty;
                        typeName = string.Empty;
                        name = string.Empty;
                        resource = string.Empty;
                        projectName = string.Empty;
                        place = 0;
                        toAddress = toAddress + Convert.ToString(dt.Rows[i]["ToAddress"]);
                        typeName = Convert.ToString(dt.Rows[i]["TypeName"]);
                        name = Convert.ToString(dt.Rows[i]["Name"]);
                        resource = Convert.ToString(dt.Rows[i]["Resources"]);
                        projectName = Convert.ToString(dt.Rows[i]["ProjectName"]);
                        switch (Operation)
                        {
                            case 1:
                                subject = typeName + " shared " + projectName + " with you";
                                msgBody = "Hi " + name + ",<br/><br/>" +
                                          typeName + " shared a project with you<br/><br/>" +
                                          "<b>Project Name : </b>" + projectName + "<br/>" +
                                          "<b>Resources : </b>" + resource + " <br/><br/>" +
                                          "Click the below link to view the Project<br/><a href='http://portal.nuvento.com/'>http://portal.nuvento.com/</a>";
                                break;
                            case 2:
                                if (name.Contains(";"))
                                {
                                    subject = "Resuorces has been removed from " + projectName + " by " + typeName;
                                    name = name.Replace(";", ",");
                                    place = name.LastIndexOf(",");
                                    name = name.Remove(place, ",".Length).Insert(place, " and");
                                }
                                else
                                    subject = "Resuorce has been removed from " + projectName + " by " + typeName;
                                msgBody = "Hi,<br/><br/> " +
                                          name + " has been removed from a project - <b>"+ projectName + "</b> by " + typeName + "<br/><br/>" +
                                          "<b>Project Name : </b>" + projectName + "<br/>" +
                                          "<b>Resources : </b>" + resource + "<br/><br/>" +
                                          "Click the below link to view the Project<br/><a href='http://portal.nuvento.com/'>http://portal.nuvento.com/</a>";
                                break;
                        }
                        Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
                        comfun.SendEmail(toAddress, ccAddress, bccAddress, subject, msgBody);
                    }
                    return JsonConvert.SerializeObject("{\"ResourceId\" : 1}", Formatting.Indented);
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
                dataReader = null;
            }
        }
        [WebMethod]
        public string ImportExcelOperations(string taskXml)

        {
            SqlConnection con = new SqlConnection();
            NuPortalRequestService requestService = new NuPortalRequestService();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = ProjectConstants.UspProjectExcelImport;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.Add(ProjectConstants.paramTasksXml, SqlDbType.Xml, -1).Value = taskXml;
                IDataReader dataReader = cmd.ExecuteReader();
                return JsonConvert.SerializeObject("{\"TaskId\" : 1}", Formatting.Indented);
            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                con.Close();
            }
        }
        //[WebMethod]
        //public string GetTaskColTypes(int Operation)
        //{
        //    SqlConnection con = new SqlConnection();
        //    Common_Library.CommonFunctions obj = new Common_Library.CommonFunctions();
        //    try
        //    {
        //        con = new SqlConnection();
        //        connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
        //        con.ConnectionString = connection;
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = ProjectConstants.UspProjectExcelImport;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandTimeout = 300;
        //        con.Open();
        //        cmd.Parameters.AddWithValue(Constants.paramOperId, Operation);
        //        IDataReader dataReader = cmd.ExecuteReader();
        //        DataTable dataTable = new DataTable(Constants.employeeProfileCompletedTable);
        //        dataTable.Load(dataReader);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            return JsonConvert.SerializeObject(dataTable, Formatting.Indented);
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //    finally
        //    {
        //        con.Close();
        //        obj = null;
        //    }
        //}
    }
}
