﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuPortalWebservice.Common_Library
{
    public class ProjectConstants
    {
        
        //function ProjectTask
        public const string UspProjectTask = "UspProjectTaskOper";
        public const string paramTaskId = "@TaskId";
        public const string paramAttachments = "@Attachments";
        public const string ParamBillable = "@Billable";
        public const string paramComments = "@Comments";
        public const string ParamEndDate = "@EndDate";
        public const string paramFkProjectId = "@Fk_ProjectId";
        public const string paramPlannedHours = "@PlannedHours";
        public const string ParamPriority = "@Priority";
        public const string paramProjectPhase = "@ProjectPhase";
        public const string ParamStartDate = "@StartDate";
        public const string ParamTaskName = "@TaskName";
        public const string paramTaskDetails = "@TaskDetails";
        public const string ParamTaskStatus = "@TaskStatusId";
        public const string ParamStatus = "@Status";
        public const string paramOperation = "@Operation";
        public const string ParamCreatedDate = "@CreatedDate";
        public const string paramModifiedDate = "@ModifiedDate";
        public const string ParamCreatedEmpID = "@CreatedEmpID";
        public const string paramModifiedEmpID = "@ModifiedEmpID";
        public const string UspProjectExcelImport = "UspImportTasksExcel";
        public const string paramTasksXml = "@TasksXml";
        public const string UpdateFlag = "@UpdateFlag";

        //function SetResourceForTask
        public const string tblProjectTaskResources = "dbo.tblProjectTaskResources"; 
        public const string colFKTaskId = "FK_TaskId";
        public const string colFKTaskResources = "FK_TaskResources";
        public const string colStatus = "Status";
        public const string colFkTaskStatusId = "Fk_TaskStatusId";
        public const string TaskId = "FKTaskId";
        public const string TaskResources = "FKTaskResources";
        public const string Status = "Status";
        public const string FkTaskStatusId = "FkTaskStatusId";

        //function CreateProjectDocuments
        public const string UspProjectDocument = "UspProjectDocumentOper";
        public const string paramDescription = "@Description";
        public const string paramDocumentId = "@DocumentId";
        public const string ParamDocumentName = "@DocumentName";
        public const string paramFKProjectId = "@FK_ProjectId";
        public const string ParamFKRoleId = "@FK_RoleId";
        public const string paramFKSharedTypeId = "@FK_SharedTypeId";

        //function SetCustomDocuments
        public const string tblCustomResources = "dbo.tblCustomResources";
        public const string colFKSharedId = "FK_SharedId";
        public const string colFKDocumentId = "FK_DocumentId";
        public const string colFKSharedResource = "FK_SharedResource";
        public const string SharedId = "SharedId";
        public const string DocumentId = "DocumentId";
        public const string SharedResource = "SharedResource";

        //function SetTaskDetails
        public const string tblTaskDetails = "dbo.tblTaskDetails";
        public const string DeleteTaskDetails = "dbo.UspDeleteTaskDetails";
        public const string SelectTaskDetails = "dbo.UspSelectTaskDetails";
        public const string colTaskId = "FK_TaskId";
        public const string colEmpId = "FK_EmpId";
        public const string colHour = "Hour";
        public const string colDate = "Date";
        public const string colWeekEndDate = "WeekEndDate";
        public const string colIsApproved = "IsApproved";
        public const string EmpId = "EmpId";
        public const string Hour = "Hour";
        public const string Date = "Date";
        public const string WeekEndDate = "WeekEndDate"; 
        public const string FK_RespondedBy = "FK_RespondedBy"; 
        public const string AssignedTo = "AssignedTo"; 
        public const string TicketStatusId = "TicketStatusId";
        public const string IsApproved = "IsApproved";  
        public const string ParamEmpId = "@EmpId";
        public const string paramWeekEnd = "@WeekEnd"; 
        public const string paramdeleteXml = "@deleteXml";

        //function GetTimeSheetTicket
        public const string GetTimeSheetTicket = "UspGetTimeSheetTicket";

        //function Send Email To Resource
        public const string UspSendMailToResource = "UspSendMailToResource";
        public const string paramProjectId = "@ProjectId";
        public const string paramEmpId = "@xmlString";
        public const string ParamModifiedEmpID = "@ModifiedEmpID";
        public const string paramOppId = "@Operation";
    }
}