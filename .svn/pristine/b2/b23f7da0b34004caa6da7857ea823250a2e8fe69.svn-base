using Newtonsoft.Json;
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
    /// Summary description for Recruitment
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Recruitment : System.Web.Services.WebService
    {
        public string connection { get; set; }
        Common_Library.CommonFunctions comfun = new Common_Library.CommonFunctions();
        [WebMethod]
        public string OpeningsOper(int openingId,string Attachments, string Certification, string City, string ContractPeriod, string Country, string CTC,
                                               string Domain, string ExperienceRequired, int FKDepartment, int FKManager, int FKRecruiter, string Role,
                                               string Industry,string JobDescription,int JobOpeningStatus,string JobTitle,string JobType,int NOOfVacancy,
                                               string Skills,string State,string Technologies,int CreatedEmpID,int ModifiedEmpID,int Status,
                                               DateTime CreatedDate,DateTime ModifiedDate,DateTime EndDate,DateTime StartDate,int FKCompanyId,int Operation)
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
                cmd.CommandText = RecruitmentConstants.UspOpenings;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramCertification, Certification);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCity, City);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramContractPeriod, ContractPeriod);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCountry, Country);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramCTC, CTC);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramDomain, Domain);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamExperienceRequired, ExperienceRequired);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamFKDepartment, FKDepartment);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramFKManager, FKManager);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamFKRecruiter, FKRecruiter);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamFKRoleId, Role);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramIndustry, Industry);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramDescription, JobDescription);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramJobOpeningStatus, JobOpeningStatus);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramJobTitle, JobTitle);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamJobType, JobType);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramNOOfVacancy, NOOfVacancy);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamopeningId, openingId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramSkills, Skills);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramState, State);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamTechnologies, Technologies);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramEndDate, EndDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramStartDate, StartDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamFKCompanyId, FKCompanyId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStatus, Status);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramOperation, Operation);

                IDataReader dataReader = cmd.ExecuteReader();
                if (Operation == 1)
                {
                    if (requestService.SendEmail(dataReader, 9, false))
                        return JsonConvert.SerializeObject("{\"OpeningId\" : 1}", Formatting.Indented);
                    else
                        return "";
                }
                else
                {
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
        public string NewApplicantOper(int NewApplicantId, string AdditionalInfo, string Address, int AssignedBy, int AssignedTo, string Attachments, string city,
                                                string Comments, string Country, string CurrentCTC, string CurrentEmployer, string CurrentJobTitle, string EmailId,
                                                string ExpectedCTC, int ExperianceinMonths, int FKApplicantIdStatus, int FKOpeningsId, string HighestQualification, 
                                                string LinkedInID,string MobileNo, string Name, string Skills,string SkypeID,string State,string Street, int ZipCode,
                                                string Technologies,string TwitterID,int CreatedEmpID, int ModifiedEmpID,DateTime CreatedDate, DateTime ModifiedDate, 
                                                int Status, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspNewApplicant;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramNewApplicantId, NewApplicantId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAdditionalInfo, AdditionalInfo);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAddress, Address);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamAssignedBy,AssignedBy);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAssignedTo, AssignedTo);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCity, city);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramComments, Comments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCountry, Country);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCurrentCTC, CurrentCTC);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramCurrentEmployer, CurrentEmployer);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCurrentJobTitle, CurrentJobTitle);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamEmailId, EmailId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramExpectedCTC, ExpectedCTC);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramExperianceinMonths, ExperianceinMonths);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramFKApplicantIdStatus, FKApplicantIdStatus);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramFKOpeningsId, FKOpeningsId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamHighestQualification, HighestQualification);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramLinkedInID, LinkedInID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamMobileNo, MobileNo);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramName, Name);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramSkills, Skills);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamSkypeID, SkypeID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramState, State);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStreet, Street);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramZipCode, ZipCode);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamTechnologies, Technologies);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramTwitterID, TwitterID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStatus, Status);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramOperation, Operation);

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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string NewAllApplicantOper(int AllApplicantId, string AdditionalInfo, string Address,int AssignedTo, string Attachments, string city,
                                          string Comments,string Country, string CurrentCTC, string CurrentEmployer, string CurrentJobTitle, string EmailId,
                                          string ExpectedCTC, int ExperianceinMonths, int FKApplicantIdStatus,int FKCompanyId, string HighestQualification,
                                          string LinkedInID, string MobileNo, string Name, string Skills, string SkypeID, string State, string Street, int ZipCode,
                                          string Technologies, string TwitterID, int CreatedEmpID, int ModifiedEmpID,int Status, int Operation)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspAllApplicant;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAllApplicantId, AllApplicantId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAdditionalInfo, AdditionalInfo);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAddress, Address);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAssignedTo, AssignedTo);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramComments, Comments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCity, city);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCountry, Country);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCurrentCTC, CurrentCTC);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramCurrentEmployer, CurrentEmployer);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCurrentJobTitle, CurrentJobTitle);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamEmailId, EmailId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramExpectedCTC, ExpectedCTC);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramExperianceinMonths, ExperianceinMonths);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramFKApplicantIdStatus, FKApplicantIdStatus);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamHighestQualification, HighestQualification);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramLinkedInID, LinkedInID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamMobileNo, MobileNo);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramName, Name);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramSkills, Skills);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamSkypeID, SkypeID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramState, State);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStreet, Street);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramZipCode, ZipCode);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamTechnologies, Technologies);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramTwitterID, TwitterID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamFKCompanyId, FKCompanyId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStatus, Status);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramOperation, Operation);

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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string ScheduleInterview(string Attachments, string Comments,DateTime Date,int ApplicantId,int InterviewType,string Location,string Time,
                                        int CreatedEmpID, int ModifiedEmpID, DateTime CreatedDate, DateTime ModifiedDate,int Status)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspInterviewSchedule;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAttachments, Attachments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramComments, Comments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramDate, Date);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramApplicantId, ApplicantId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamInterviewType, InterviewType);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramLocation, Location);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramTime, Time);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCreatedEmpID, CreatedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramModifiedEmpID, ModifiedEmpID);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStatus, Status);
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }
        [WebMethod]
        public bool SetInterview(int Id, string jsonInterView)
        {
            if (comfun.DeleteRecords(Id, 43))
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
                            sqlBulkCopy.DestinationTableName = RecruitmentConstants.tblInterviewers;

                            //[OPTIONAL]: Map the DataTable columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add(RecruitmentConstants.FKScheduleId, RecruitmentConstants.colFKScheduleId);
                            sqlBulkCopy.ColumnMappings.Add(RecruitmentConstants.Interviewer, RecruitmentConstants.colInterviewer);
                            sqlBulkCopy.ColumnMappings.Add(RecruitmentConstants.InterviewerStatusId, RecruitmentConstants.colInterviewerStatusId);
                            sqlBulkCopy.ColumnMappings.Add(RecruitmentConstants.Comments, RecruitmentConstants.colComments);
                            sqlBulkCopy.ColumnMappings.Add(RecruitmentConstants.Attachments, RecruitmentConstants.colAttachments);
                            sqlBulkCopy.WriteToServer(comfun.StringtoDataTable(jsonInterView));
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
        public string InterviewAssessment(int InterviewAssessmentId,int FKInterviewerId, int FKScheduledId, int InterpersonalSkills,int LeadershipSkills,
                                          int PresentaitonSkills, int Status, int Teamwork,int TechinicalAbility,string Comments,int Operation)
                                       
        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspInterviewAssessmentOper;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramInterviewAssessmentId, InterviewAssessmentId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramFKInterviewerId, FKInterviewerId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramFKScheduledId, FKScheduledId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamInterpersonalSkills, InterpersonalSkills);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramLeadershipSkills, LeadershipSkills);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamPresentaitonSkills, PresentaitonSkills); 
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStatus, Status);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramTeamwork, Teamwork);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramTechinicalAbility, TechinicalAbility);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramComments, Comments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramOperation, Operation);
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string ApplicantStatusUpdate(int ApplicantId, int OpeningId, int StatusId, int AssignTo, int AssignBy,string Comments,int operationId)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspUpdateNewApplicant;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramSApplicantId, ApplicantId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramOpeningId, OpeningId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamStatusId, StatusId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAssignTo, AssignTo);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramAssignBy, AssignBy);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamComments, Comments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramOperation, operationId);
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }
        [WebMethod]
        public string TimesheetReport(int empId,int ProjectId,DateTime startDate, DateTime endDate)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspTimesheetReport;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramEmpID, empId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamProjectId, ProjectId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramst_date, startDate);
                cmd.Parameters.AddWithValue(RecruitmentConstants.Paramed_date, endDate);
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string InterviewScheduleUpdate(int ApplicantId, int InterviewerId, int Interviewer ,int Status,
                                                string Attachments,string Comments,int Operation)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspUpdateInterViewSchedule;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamnewappId,ApplicantId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParaminterviewerId, InterviewerId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.Paraminterviewer,Interviewer);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamstatusId, Status);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramattachments, Attachments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramcomments, Comments);
                cmd.Parameters.AddWithValue(RecruitmentConstants.Paramoperation, Operation);
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string CreateJoinedEmployee(int FKNewApp,string FirstName, string LastName, string Title, string EmployeeCode, int JobTitle, int Manager, string ProfilePicUrl,
                           string QuotesPictureUrl, string BackGroundPicUrl, DateTime HireDate, DateTime ConfirmationDate, string WorkEMail, int OfficeLocation,
                           string WorkLocation, int EmptTypeId, DateTime RelievingDate, int CompanyId, int FkEmpStatus, DateTime CreatedDate, DateTime ModifiedDate, int CreatedEmpId,
                           int ModifiedEmpId, int WeekOffDays, string StartTime, string EndTime, string QuotesText)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = Constants.UspSetJoinedEmployeeInfo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                con.Open();
                cmd.Parameters.AddWithValue(Constants.paramFKNewAppId, FKNewApp);
                cmd.Parameters.AddWithValue(Constants.paramFirstName, FirstName);
                cmd.Parameters.AddWithValue(Constants.ParamLastName, LastName);
                cmd.Parameters.AddWithValue(Constants.paramTitle, Title);
                cmd.Parameters.AddWithValue(Constants.ParamEmployeeCode, EmployeeCode);
                cmd.Parameters.AddWithValue(Constants.paramJobTitle, JobTitle);
                cmd.Parameters.AddWithValue(Constants.ParamManager, Manager);
                cmd.Parameters.AddWithValue(Constants.paramProfilePicUrl, ProfilePicUrl);
                cmd.Parameters.AddWithValue(Constants.paramQuotesPictureUrl, QuotesPictureUrl);
                cmd.Parameters.AddWithValue(Constants.paramBackGroundPicUrl, BackGroundPicUrl);
                cmd.Parameters.AddWithValue(Constants.ParamHireDate, HireDate);
                cmd.Parameters.AddWithValue(Constants.paramConfirmationDate, ConfirmationDate);
                cmd.Parameters.AddWithValue(Constants.ParamWorkEmail, WorkEMail);
                cmd.Parameters.AddWithValue(Constants.paramOfficeLocation, OfficeLocation);
                cmd.Parameters.AddWithValue(Constants.ParamWorkLocation, WorkLocation);
                cmd.Parameters.AddWithValue(Constants.paramEmptTypeId, EmptTypeId);
                cmd.Parameters.AddWithValue(Constants.ParamRelievingDate, RelievingDate);
                cmd.Parameters.AddWithValue(Constants.paramCompanyId, CompanyId);
                cmd.Parameters.AddWithValue(Constants.paramFkEmpStatus, FkEmpStatus);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedDate, CreatedDate);
                cmd.Parameters.AddWithValue(Constants.paramModifiedDate, ModifiedDate);
                cmd.Parameters.AddWithValue(Constants.ParamCreatedEmpID, CreatedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramModifiedEmpID, ModifiedEmpId);
                cmd.Parameters.AddWithValue(Constants.paramWeekOffDays, WeekOffDays);
                cmd.Parameters.AddWithValue(Constants.ParamStartTime, StartTime);
                cmd.Parameters.AddWithValue(Constants.paramEndTime, EndTime);
                cmd.Parameters.AddWithValue(Constants.paramQuotesText, QuotesText);

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
                return "";
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public string UspUpdateJoinedEmpolyee(string Email, int ModifiedId, int Id, int Operation)

        {
            SqlConnection con = new SqlConnection();
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                connection = ConfigurationManager.ConnectionStrings[Constants.connection].ConnectionString;
                con.ConnectionString = connection;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = RecruitmentConstants.UspUpdateJoinedEmpolyee;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramEmail, Email);
                cmd.Parameters.AddWithValue(RecruitmentConstants.paramModifiedId, ModifiedId);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamId, Id);
                cmd.Parameters.AddWithValue(RecruitmentConstants.ParamOperation, Operation);
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
                return "";
            }
            finally
            {
                con.Close();
            }
        }
    }
}
