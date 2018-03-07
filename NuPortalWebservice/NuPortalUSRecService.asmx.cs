﻿using Newtonsoft.Json;
using NuPortalWebservice.Common_Library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NuPortalWebservice
{
    /// <summary>
    /// Summary description for NuPortalUSRecService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class NuPortalUSRecService : System.Web.Services.WebService
    {
        public string connection { get; set; }
        [WebMethod]
        public string SaveOpportunity(int OppId, string Street, string City, string State, string ZipCode,string Country, string ClientName, string Contact1, string Contact2,
            string ContactPerson, int CreatedEmpID, int FKPositionType, int FKIndustry, DateTime TargetDate, string Note, string Attachments, string JobDescription,
            string Email, string Experience, string Fax, float Hours, int IsCancelled, int IsClosed, string Location, int ModifiedEmpID, int CompanyId,
            int NoOfOpenings, string PositionTitle, string ProfileType, string Rate, string Website, int Status, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveRecOpportunity;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramOppId, OppId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKCompanyId, CompanyId);
                cmd.Parameters.AddWithValue(USRecConstants.paramStreet, Street);
                cmd.Parameters.AddWithValue(USRecConstants.paramCity, City);
                cmd.Parameters.AddWithValue(USRecConstants.paramState, State);
                cmd.Parameters.AddWithValue(USRecConstants.paramZipCode, ZipCode);
                cmd.Parameters.AddWithValue(USRecConstants.Country, Country);
                cmd.Parameters.AddWithValue(USRecConstants.paramClientName, ClientName);
                cmd.Parameters.AddWithValue(USRecConstants.paramContact1, Contact1);
                cmd.Parameters.AddWithValue(USRecConstants.paramContact2, Contact2);
                cmd.Parameters.AddWithValue(USRecConstants.paramContactPerson, ContactPerson);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmail, Email);
                cmd.Parameters.AddWithValue(USRecConstants.paramExperience, Experience);
                cmd.Parameters.AddWithValue(USRecConstants.paramFax, Fax);
                cmd.Parameters.AddWithValue(USRecConstants.paramHours, Hours);
                cmd.Parameters.AddWithValue(USRecConstants.paramIsCancelled, IsCancelled);
                cmd.Parameters.AddWithValue(USRecConstants.paramIsClosed, IsClosed);
                cmd.Parameters.AddWithValue(USRecConstants.paramLocation, Location);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramNoOfOpenings, NoOfOpenings);
                cmd.Parameters.AddWithValue(USRecConstants.paramPositionTitle, PositionTitle);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKPositionType, FKPositionType);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKIndustry, FKIndustry);
                cmd.Parameters.AddWithValue(USRecConstants.paramTargetDate, TargetDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramJobDescription, JobDescription);
                cmd.Parameters.AddWithValue(USRecConstants.paramNote, Note);
                cmd.Parameters.AddWithValue(USRecConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(USRecConstants.paramProfileType, ProfileType);
                cmd.Parameters.AddWithValue(USRecConstants.paramRate, Rate);
                cmd.Parameters.AddWithValue(USRecConstants.paramWebsite, Website);
                cmd.Parameters.AddWithValue(USRecConstants.paramStatus, Status);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SaveReqDocs(int Id, string jsonReqDocs)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 72))
            {
                if (jsonReqDocs == "[]")
                    return true;
                SqlConnection con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecRequiredDocs;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.Fk_OppId, USRecConstants.Fk_OppId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.DocType, USRecConstants.DocType);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonReqDocs));
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
                        comfun = null;
                    }
                }
            }
            return false;
        }

        [WebMethod]
        public string SaveLead(int LeadId, int CreatedEmpID, string CurrentCTC, string CurrentDesignation, string CurrentEmployer,
            int VisaType, string Street, string City, string Zip, string State, string Country, string HighestQualification, string Source,
            string CurrentLocation, DateTime DOB, string EmailId, int EmployeeType, int EmploymentType, int ExperienceInMonths, string FirstName, string Gender,
            int Hours, string LastName, int LeadType, string MobileNo, int ModifiedEmpID, string Note, string Rate, int Status, int IsCancelled, string Attachments,
            int RecStatus, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveRecLead;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.LeadId, LeadId);
                cmd.Parameters.AddWithValue(USRecConstants.VisaType, VisaType);
                cmd.Parameters.AddWithValue(USRecConstants.Street, Street);
                cmd.Parameters.AddWithValue(USRecConstants.City, City);
                cmd.Parameters.AddWithValue(USRecConstants.Zip, Zip);
                cmd.Parameters.AddWithValue(USRecConstants.State, State);
                cmd.Parameters.AddWithValue(USRecConstants.Country, Country);
                cmd.Parameters.AddWithValue(USRecConstants.HighestQualification, HighestQualification);
                cmd.Parameters.AddWithValue(USRecConstants.Source, Source);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.CurrentCTC, CurrentCTC);
                cmd.Parameters.AddWithValue(USRecConstants.CurrentDesignation, CurrentDesignation);
                cmd.Parameters.AddWithValue(USRecConstants.CurrentEmployer, CurrentEmployer);
                cmd.Parameters.AddWithValue(USRecConstants.CurrentLocation, CurrentLocation);
                cmd.Parameters.AddWithValue(USRecConstants.DOB, DOB);
                cmd.Parameters.AddWithValue(USRecConstants.EmailId, EmailId);
                cmd.Parameters.AddWithValue(USRecConstants.EmployeeType, EmployeeType);
                cmd.Parameters.AddWithValue(USRecConstants.EmploymentType, EmploymentType);
                cmd.Parameters.AddWithValue(USRecConstants.paramIsCancelled, IsCancelled);
                cmd.Parameters.AddWithValue(USRecConstants.ExperienceInMonths, ExperienceInMonths);
                cmd.Parameters.AddWithValue(USRecConstants.FirstName, FirstName);
                cmd.Parameters.AddWithValue(USRecConstants.Gender, Gender);
                cmd.Parameters.AddWithValue(USRecConstants.Hours, Hours);
                cmd.Parameters.AddWithValue(USRecConstants.LastName, LastName);
                cmd.Parameters.AddWithValue(USRecConstants.LeadType, LeadType);
                cmd.Parameters.AddWithValue(USRecConstants.MobileNo, MobileNo);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.Note, Note);
                cmd.Parameters.AddWithValue(USRecConstants.Rate, Rate);
                cmd.Parameters.AddWithValue(USRecConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(USRecConstants.RecStatus, RecStatus);
                cmd.Parameters.AddWithValue(USRecConstants.paramStatus, Status);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }
        //TypeId=0 for primarySkill
        //TypeId=1 for secondarySkill
        [WebMethod]
        public bool setRecSkills(int Id, string jsonRecSkills)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 77))
            {
                if (jsonRecSkills == "[]")
                    return true;
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecSkills;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.FKOpportunityId, USRecConstants.colFKOpportunityId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.Skill, USRecConstants.colSkills);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.TypeId, USRecConstants.colTypeId);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonRecSkills));
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
        public bool setLeadSkills(int Id, string jsonLeadSkills)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 78))
            {
                if (jsonLeadSkills == "[]")
                    return true;
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblLeadSkills;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.FKLeadId, USRecConstants.colFKLeadId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.Skill, USRecConstants.colSkills);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.TypeId, USRecConstants.colTypeId);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonLeadSkills));
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
        public string SaveInterView(int InterviewId, string Attachments, int CreatedEmpID, int FK_Interviewtype, int FK_SubmissionId,
                      int FK_TicketStatusId, DateTime InterviewDate, string InterviewTime, string Note, string Location, int ModifiedEmpID, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveRecInterview;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramInterviewId, InterviewId);
                cmd.Parameters.AddWithValue(USRecConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKInterviewtype, FK_Interviewtype);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKSubmissionId, FK_SubmissionId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKTicketStatusId, FK_TicketStatusId);
                cmd.Parameters.AddWithValue(USRecConstants.paramInterviewDate, InterviewDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramInterviewTime, InterviewTime);
                cmd.Parameters.AddWithValue(USRecConstants.paramLocation, Location);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramNote, Note);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string SaveContract(int ContractId, int FK_SubmissionId,int FK_TicketStatusId, string Title, DateTime Date, string SignedBy, string TitleClient,
           DateTime DateClient, string SignedByClient, string State, DateTime ContractExpiryDate, int IsRateConfirmationPresent,
           int CreatedEmpID, int ModifiedEmpID, int Status, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveRecContract;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.ContractId, ContractId);
                cmd.Parameters.AddWithValue(USRecConstants.FK_SubmissionId, FK_SubmissionId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKTicketStatusId, FK_TicketStatusId);
                cmd.Parameters.AddWithValue(USRecConstants.Title, Title);
                cmd.Parameters.AddWithValue(USRecConstants.Date, Date);
                cmd.Parameters.AddWithValue(USRecConstants.SignedBy, SignedBy);
                cmd.Parameters.AddWithValue(USRecConstants.TitleClient, TitleClient);
                cmd.Parameters.AddWithValue(USRecConstants.DateClient, DateClient);
                cmd.Parameters.AddWithValue(USRecConstants.SignedByClient, SignedByClient);
                cmd.Parameters.AddWithValue(USRecConstants.State, State);
                cmd.Parameters.AddWithValue(USRecConstants.ContractExpiryDate, ContractExpiryDate);
                cmd.Parameters.AddWithValue(USRecConstants.IsRateConfirmationPresent, IsRateConfirmationPresent);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.Status, Status);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SaveContractDocs(int Id, string jsonContractDocs)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 79))
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecContractDocs;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFK_ContractId, USRecConstants.colFK_ContractId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colDocName, USRecConstants.colDocName);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colDocUrl, USRecConstants.colDocUrl);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonContractDocs));
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
        public string SaveVendorDetails(int VendorDetailsId, int FK_LeadId, string CompanyName, string CompanyID, string CompanyAddress,
            string ContactPerson1Name, string ContactPerson1Title, string ContactPerson2Name, string ContactPerson2Title, string ContactPerson3Name,
            string ContactPerson3Title, string VendorID, string DepositoryBankName, string Branch, string City, string State, string RoutingNumber,
            string AccountName, string AccountNumber, int AccountType, string VendorName, string IDNumber, string SignedBy, string Designation,
            DateTime Date, string Attachments,int FK_TicketStatusId, int CreatedEmpID, int ModifiedEmpID, int Status, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveRecVendorDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramVendorDetailsId, VendorDetailsId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFK_LeadId, FK_LeadId);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyName, CompanyName);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyID, CompanyID);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyAddress, CompanyAddress);
                cmd.Parameters.AddWithValue(USRecConstants.paramContactPerson1Name, ContactPerson1Name);
                cmd.Parameters.AddWithValue(USRecConstants.paramContactPerson1Title, ContactPerson1Title);
                cmd.Parameters.AddWithValue(USRecConstants.paramContactPerson2Name, ContactPerson2Name);
                cmd.Parameters.AddWithValue(USRecConstants.paramContactPerson2Title, ContactPerson2Title);
                cmd.Parameters.AddWithValue(USRecConstants.paramContactPerson3Name, ContactPerson3Name);
                cmd.Parameters.AddWithValue(USRecConstants.paramContactPerson3Title, ContactPerson3Title);
                cmd.Parameters.AddWithValue(USRecConstants.paramVendorID, VendorID);
                cmd.Parameters.AddWithValue(USRecConstants.paramDepositoryBankName, DepositoryBankName);
                cmd.Parameters.AddWithValue(USRecConstants.paramBranch, Branch);
                cmd.Parameters.AddWithValue(USRecConstants.paramCity, City);
                cmd.Parameters.AddWithValue(USRecConstants.paramState, State);
                cmd.Parameters.AddWithValue(USRecConstants.paramRoutingNumber, RoutingNumber);
                cmd.Parameters.AddWithValue(USRecConstants.paramAccountName, AccountName);
                cmd.Parameters.AddWithValue(USRecConstants.paramAccountNumber, AccountNumber);
                cmd.Parameters.AddWithValue(USRecConstants.paramAccountType, AccountType);
                cmd.Parameters.AddWithValue(USRecConstants.paramVendorName, VendorName);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKTicketStatusId, FK_TicketStatusId);
                cmd.Parameters.AddWithValue(USRecConstants.paramIDNumber, IDNumber);
                cmd.Parameters.AddWithValue(USRecConstants.paramSignedBy, SignedBy);
                cmd.Parameters.AddWithValue(USRecConstants.paramDesignation, Designation);
                cmd.Parameters.AddWithValue(USRecConstants.paramDate, Date);
                cmd.Parameters.AddWithValue(USRecConstants.paramStatus, Status);
                cmd.Parameters.AddWithValue(USRecConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string SaveInvoiceDetails(int InvoiceId,int FK_SubmissionId,int FKTicketStatusId, string Name, string Email, string Terms, int FK_BillingCycle, string Street, 
            string City, string State, string Country, string Zip, string CcList,int Status,  int CreatedEmpID, int ModifiedEmpID, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveInvoiceDetails;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramInvoiceId, InvoiceId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFK_SubmissionId, FK_SubmissionId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKTicketStatusId, FKTicketStatusId);
                cmd.Parameters.AddWithValue(USRecConstants.paramName, Name);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmail, Email);
                cmd.Parameters.AddWithValue(USRecConstants.paramTerms, Terms);
                cmd.Parameters.AddWithValue(USRecConstants.paramFK_BillingCycle, FK_BillingCycle);
                cmd.Parameters.AddWithValue(USRecConstants.paramStreet, Street);
                cmd.Parameters.AddWithValue(USRecConstants.paramCity, City);
                cmd.Parameters.AddWithValue(USRecConstants.paramState, State);
                cmd.Parameters.AddWithValue(USRecConstants.paramCountry, Country);
                cmd.Parameters.AddWithValue(USRecConstants.paramZip, Zip);
                cmd.Parameters.AddWithValue(USRecConstants.paramCcList, CcList);
                cmd.Parameters.AddWithValue(USRecConstants.paramStatus, Status);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SaveInvoiceContactDetails(int Id, string jsonInvoiceDocs)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 80))
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecInvoiceContactDetails;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFK_InvoiceId, USRecConstants.colFK_InvoiceId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colName, USRecConstants.colName);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colEmail, USRecConstants.colEmail);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colTerms, USRecConstants.colTerms);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFK_ContractType, USRecConstants.colFK_ContractType);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colStreet, USRecConstants.colStreet);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colCity, USRecConstants.colCity);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colState, USRecConstants.colState);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colCountry, USRecConstants.colCountry);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colZip, USRecConstants.colZip);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colPhone, USRecConstants.colPhone);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonInvoiceDocs));
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
        public string SaveSubmissions(int SubmissionId,int FKSubmissionStatusId, int FK_OppId, int FK_LeadId, string Rate, int AssignedTo, int FK_TicketStatusId,
                      int IsCancelled,int Status, int CreatedEmpID, int ModifiedEmpID, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveRecSubmissions;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramSubmissionId, SubmissionId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFK_OppId, FK_OppId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFK_LeadId, FK_LeadId);
                cmd.Parameters.AddWithValue(USRecConstants.paramRate, Rate);
                cmd.Parameters.AddWithValue(USRecConstants.paramAssignedTo, AssignedTo);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKSubmissionStatusId,FKSubmissionStatusId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFK_TicketStatusId, FK_TicketStatusId);
                cmd.Parameters.AddWithValue(USRecConstants.paramIsCancelled, IsCancelled);
                cmd.Parameters.AddWithValue(USRecConstants.paramStatus, Status);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SaveSubmittedVisaDocs(int Id, string jsonSubmittedVisaDocs)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 81))
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecSubmittedVisaDocs;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFK_VisaProcessingId, USRecConstants.colFK_VisaProcessingId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFK_DocTypeId, USRecConstants.colFK_DocTypeId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colDocPath, USRecConstants.colDocPath);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colDocTag, USRecConstants.colDocTag);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonSubmittedVisaDocs));
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
        public bool SaveSubmittedDocs(int Id, string jsonSubmittedDocs)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 82))
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecSubmittedDocs;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFk_SubmissionId, USRecConstants.colFk_SubmissionId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFK_DocTypeId, USRecConstants.colFK_DocTypeId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colDocPath, USRecConstants.colDocPath);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonSubmittedDocs));
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
        public string SaveVisaProcessing(int VisaProcessingId,int FKSubmissionId, string CompanyAddress, string CompanyDescription, DateTime CompanyEstDate, string CompanyName, 
               int CreatedEmpID, string Email,string EmpAbroadAddress,string EmpCountryOfBirth,DateTime EmpDOB,string EmpFname,
               string EmpLname,string EmpMName,string EmpNearestConsulate,string EmpPlaceOfBirth,string EmpSSN,string EmpUSAddress,string Fax,string FederalTAXIDNumber,
               string GrossAnnualIncome,DateTime I94IssueDate,string I94Number,DateTime I94ValidityDate,int IsCompanyH1BDependent,string JobLocationAddress,
               string JobTitleOffered,string LastI797ApprovalReceipt,int MaritalStatus,int ModifiedEmpID,string NameOfPersonToSign,string NetIncome,int NoOfEmployees,
               int NoOfH1BEmployees,DateTime PassportIssueDate, string PassportNumber, DateTime PassportValidityDate, string Phone, string SalaryOffered, 
               string TitleOfPersonToSign,DateTime TicketSubmissionDate,int FK_TicketStatusId, int Operation,int Candidate,string Client,string PositionTitle)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[USRecConstants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspSaveRecVisaProcessing;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramVisaProcessingId, VisaProcessingId);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKSubmissionId, FKSubmissionId);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyAddress, CompanyAddress);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyDescription, CompanyDescription);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyEstDate, CompanyEstDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyName, CompanyName);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmail, Email);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpAbroadAddress, EmpAbroadAddress);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpCountryOfBirth, EmpCountryOfBirth);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpDOB, EmpDOB);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpFname, EmpFname);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpLname, EmpLname);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpMName, EmpMName);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpNearestConsulate, EmpNearestConsulate);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpPlaceOfBirth, EmpPlaceOfBirth);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpSSN, EmpSSN);
                cmd.Parameters.AddWithValue(USRecConstants.paramEmpUSAddress, EmpUSAddress);
                cmd.Parameters.AddWithValue(USRecConstants.paramFax, Fax);
                cmd.Parameters.AddWithValue(USRecConstants.paramFederalTAXIDNumber, FederalTAXIDNumber);
                cmd.Parameters.AddWithValue(USRecConstants.paramGrossAnnualIncome, GrossAnnualIncome);
                cmd.Parameters.AddWithValue(USRecConstants.paramI94IssueDate, I94IssueDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramI94Number, I94Number);
                cmd.Parameters.AddWithValue(USRecConstants.paramI94ValidityDate, I94ValidityDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramIsCompanyH1BDependent, IsCompanyH1BDependent);
                cmd.Parameters.AddWithValue(USRecConstants.paramJobLocationAddress, JobLocationAddress);
                cmd.Parameters.AddWithValue(USRecConstants.paramJobTitleOffered, JobTitleOffered);
                cmd.Parameters.AddWithValue(USRecConstants.paramLastI797ApprovalReceipt, LastI797ApprovalReceipt);
                cmd.Parameters.AddWithValue(USRecConstants.paramMaritalStatus, MaritalStatus);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(USRecConstants.paramNameOfPersonToSign, NameOfPersonToSign);
                cmd.Parameters.AddWithValue(USRecConstants.paramNetIncome, NetIncome);
                cmd.Parameters.AddWithValue(USRecConstants.paramNoOfEmployees, NoOfEmployees);
                cmd.Parameters.AddWithValue(USRecConstants.paramNoOfH1BEmployees, NoOfH1BEmployees);
                cmd.Parameters.AddWithValue(USRecConstants.paramPassportIssueDate, PassportIssueDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramPassportNumber, PassportNumber);
                cmd.Parameters.AddWithValue(USRecConstants.paramPassportValidityDate, PassportValidityDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramPhone, Phone);
                cmd.Parameters.AddWithValue(USRecConstants.paramSalaryOffered, SalaryOffered);
                cmd.Parameters.AddWithValue(USRecConstants.paramTitleOfPersonToSign, TitleOfPersonToSign);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKCandidate, Candidate);
                cmd.Parameters.AddWithValue(USRecConstants.paramClient, Client);
                cmd.Parameters.AddWithValue(USRecConstants.paramPositionTitle, PositionTitle);
                if (TicketSubmissionDate.Year != 1753)
                    cmd.Parameters.AddWithValue(USRecConstants.paramTicketSubmissionDate, TicketSubmissionDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramFK_TicketStatusId, FK_TicketStatusId);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable();
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
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public bool SaveVisaDateDetails(int Id, string jsonVisaDateDetails)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 83))
            {
                if (jsonVisaDateDetails == "[]")
                    return true;
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecVisaDateDetails;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFK_VisaProcessingId, USRecConstants.colFK_VisaProcessingId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colVisaEntryDate, USRecConstants.colVisaEntryDate);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colVisaExitDate, USRecConstants.colVisaExitDate);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonVisaDateDetails));
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
        public bool SaveFamilyVisaDetails(int Id, string jsonFamilyVisaDetails)
        {
            Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
            if (comfun.DeleteRecords(Id, 84))
            {
                if (jsonFamilyVisaDetails == "[]")
                    return true;
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
                            sqlBulkCopy.DestinationTableName = USRecConstants.tblRecFamilyVisaDetails;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFk_VisaDetailsId, USRecConstants.colFk_VisaDetailsId);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colFirstName, USRecConstants.colFirstName);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colLastName, USRecConstants.colLastName);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colPlaceOfBirth, USRecConstants.colPlaceOfBirth);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colDOB, USRecConstants.colDOB);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colSOSSec, USRecConstants.colSOSSec);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colEntryDateOfUSRes, USRecConstants.colEntryDateOfUSRes);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colExitDateOfUSRes, USRecConstants.colExitDateOfUSRes);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colRelationShip, USRecConstants.colRelationShip);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colI94IfTheFamilyIsInUsa, USRecConstants.colI94IfTheFamilyIsInUsa);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colPassportVisaPage, USRecConstants.colPassportVisaPage);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colPassportPhotoPage, USRecConstants.colPassportPhotoPage);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colI94TagName, USRecConstants.colI94TagName);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colVisaTagName, USRecConstants.colVisaTagName);
                            sqlBulkCopy.ColumnMappings.Add(USRecConstants.colPhotoTagName, USRecConstants.colPhotoTagName);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonFamilyVisaDetails));
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
        public bool CreateRecEmployee(int RecEmpId,string BackGroundPicUrl,DateTime ConfirmationDate,int CreatedEmpId,string EmployeeCode,float EmpRating,string EndTime,string FirstName,
                                      int CompanyId,int JobDesignation,int FkEmpStatus,int EmptTypeId,int Fk_SalaryType,int Fk_TypeOfVisa,string InsuranceAmount,string InsurancePaidBy,
                                      int IsCancelled, int IsUSBench,string LastName,int Manager,int ModifiedEmpId,string ProfilePicUrl, string PassportUrl, string QuotesText,
                                      string RelievingAttachments,DateTime RelievingDate,string StartTime,int Status,string Title,DateTime TrainingDate,DateTime VisaExpiryDate,int WeekOffDays,
                                      string WorkEMail, int WorkLocation,int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.UspRecEmployeeOper;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramRecEmpId, RecEmpId);
                cmd.Parameters.AddWithValue(USRecConstants.paramBackGroundPicUrl, BackGroundPicUrl);
                cmd.Parameters.AddWithValue(USRecConstants.paramConfirmationDate, ConfirmationDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramCreatedEmpID, CreatedEmpId);
                cmd.Parameters.AddWithValue(USRecConstants.ParamEmployeeCode, EmployeeCode);
                cmd.Parameters.AddWithValue(USRecConstants.ParamEmpRating, EmpRating);
                cmd.Parameters.AddWithValue(USRecConstants.ParamEmployeeCode, EmployeeCode);
                cmd.Parameters.AddWithValue(USRecConstants.paramEndTime, EndTime);
                cmd.Parameters.AddWithValue(USRecConstants.paramFirstName, FirstName);
                cmd.Parameters.AddWithValue(USRecConstants.paramCompanyId, CompanyId);
                cmd.Parameters.AddWithValue(USRecConstants.ParamFKDesignationId, JobDesignation);
                cmd.Parameters.AddWithValue(USRecConstants.paramFkEmpStatus, FkEmpStatus);
                cmd.Parameters.AddWithValue(USRecConstants.paramFKEmptTypeId, EmptTypeId);
                cmd.Parameters.AddWithValue(USRecConstants.ParamFkSalaryType, Fk_SalaryType);
                cmd.Parameters.AddWithValue(USRecConstants.paramFkTypeOfVisa, Fk_TypeOfVisa);
                cmd.Parameters.AddWithValue(USRecConstants.paramInsuranceAmount, InsuranceAmount);
                cmd.Parameters.AddWithValue(USRecConstants.ParamInsurancePaidBy, InsurancePaidBy);
                cmd.Parameters.AddWithValue(USRecConstants.paramIsCancelled, IsCancelled);
                cmd.Parameters.AddWithValue(USRecConstants.paramIsUSBench, IsUSBench);
                cmd.Parameters.AddWithValue(USRecConstants.paramManager, Manager);
                cmd.Parameters.AddWithValue(USRecConstants.paramFkEmpStatus, FkEmpStatus);
                cmd.Parameters.AddWithValue(USRecConstants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(USRecConstants.paramProfilePicUrl, ProfilePicUrl);
                cmd.Parameters.AddWithValue(USRecConstants.ParamPassportUrl, PassportUrl);
                cmd.Parameters.AddWithValue(USRecConstants.ParamQuotesText, QuotesText);
                cmd.Parameters.AddWithValue(USRecConstants.ParamRelievingAttachments, RelievingAttachments);
                cmd.Parameters.AddWithValue(USRecConstants.paramRelievingDate, RelievingDate);
                cmd.Parameters.AddWithValue(USRecConstants.ParamStartTime, StartTime);
                cmd.Parameters.AddWithValue(USRecConstants.paramStatus, Status);

                cmd.Parameters.AddWithValue(USRecConstants.ParamTitle, Title);
                cmd.Parameters.AddWithValue(USRecConstants.ParamTrainingDate, TrainingDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramVisaExpiryDate, VisaExpiryDate);
                cmd.Parameters.AddWithValue(USRecConstants.ParamWeekOffDays, WeekOffDays);
                cmd.Parameters.AddWithValue(USRecConstants.paramWorkEmail, WorkEMail); 
                cmd.Parameters.AddWithValue(USRecConstants.paramWorkLocation, WorkLocation);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);

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
        public string GetTimeSheetReport(DateTime StartDate, DateTime EndDate, int ProjectId,int ResourceId, int Offset, int RowCount, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = USRecConstants.TaskStatusReport;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(USRecConstants.paramId,ResourceId);
                cmd.Parameters.AddWithValue(USRecConstants.paramProjectId, ProjectId);
                if (StartDate.Year != 1753)
                    cmd.Parameters.AddWithValue(USRecConstants.paramStartDate, StartDate);
                if (EndDate.Year != 1753)
                    cmd.Parameters.AddWithValue(USRecConstants.paramEndDate, EndDate);
                cmd.Parameters.AddWithValue(USRecConstants.paramOperation, Operation);
                cmd.Parameters.AddWithValue(USRecConstants.paramOffset, Offset);
                cmd.Parameters.AddWithValue(USRecConstants.ParamRowCount, RowCount);
                IDataReader dataReader = cmd.ExecuteReader();
                DataTable dataTable = new DataTable(USRecConstants.employeeTaskStatusReoprt);
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

    }
}
