﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuPortalWebservice.Common_Library
{
    public class RequestConstants
    {
        //Common
        public const string CreatedDate = "@CreatedDate";
        public const string CreatedEmpId = "@CreatedEmpId";
        public const string ModifiedDate = "@ModifiedDate";
        public const string ModifiedEmpId = "@ModifiedEmpId";
        public const string AttachmentPath = "@Attachments";
        public const string Status = "@Status";

        //function CreateRequest
        public const string setRequests = "UspSaveRequests";
        public const string RequestType = "@RequestType"; 
        public const string RequestTypeName = "@RequestTypeName";
        public const string RequestText = "@RequestText";
        public const string RequestStatus = "@RequestStatus";
        public const string CompOffFor = "@CompOffFor"; 
        public const string RequestedDateVal = "@RequestedDateVal"; 
        public const string TicketStatus = "@TicketStatusName";
        public const string RequestedToDate = "@RequestedToDate";
        public const string GroupName = "@GroupName";

        //function CreateAllowance and Reimbursement
        public const string setAllOrReim = "UspSaveAllowance";
        public const string Amount = "@Amount";
        public const string StartDate = "@Date";
        public const string EndDate = "@EndDate";
        public const string Description = "@Description";
        public const string CategoryId = "@FK_CategoryId";
        public const string CategoryTypeId = "@CategoryTypeId";

        //function CreateLeaveRequest
        public const string UspLeaveTransaction = "UspSaveLeaveRequest";
        public const string paramFK_EmpId = "@FK_EmpId";
        public const string paramFK_EmpIdRequester = "@FK_EmpIdRequester";
        public const string paramFK_EmpAssignedTo = "@FK_EmpAssignedTo";
        public const string paramLeaveStartDate = "@LeaveStartDate";
        public const string paramLeaveEndDate = "@LeaveEndDate";
        public const string paramFK_LeaveTypeId = "@FK_LeaveTypeId";
        public const string paramFK_StatusId = "@FK_StatusId";
        public const string paramFK_LeaveTransId = "@FK_LeaveTransId";
        public const string paramLeaveAppliedDays = "@LeaveAppliedDays";
        public const string paramReason = "@Reason";
        public const string paramIsCreate = "@IsCreate";

        //function CancelMyLeave
        public const string UspCancelLeave = "UspUpdateCancelLeaves";
        public const string paramFK_Id = "@Id";
        public const string paramEmpId = "@EmpId";
        public const string paramCompanyId = "@CompanyId";
        public const string paramOperation = "@Operation";
        public const string paramStatusId = "@statusId";

        //function GetAvailableLeaves
        public const string UspAvailableLeaves = "UspLeaveBalance";
        public const string paramFK_CompanyId = "@FK_Companyid";

        //function UpdateRequestStatus
        public const string UspUpdateStatus = "UspGridUpdate";

        //function UspSearchAllowanceReimbursement
        public const string UspSearchAllowanceReimbursement = "UspSearchAllowanceReimbursement";
        public const string paramTicketStatusId = "@TicketStatusId";

        //function CheckIsReqApplied
        public const string UspCheckRequestApplied = "uspCheckRequestApplied";
    }
}