using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuPortalWebservice.Common_Library
{
    public class RecruitmentConstants
    {
        //save and update openings
        public const string UspOpenings= "UspOpeningsOper";
        public const string paramAttachments = "@Attachments";
        public const string paramCertification = "@Certification";
        public const string ParamCity = "@City";
        public const string paramContractPeriod = "@ContractPeriod";
        public const string ParamCountry = "@Country";
        public const string paramCTC = "@CTC";
        public const string paramDomain = "@Domain";
        public const string ParamExperienceRequired = "@ExperienceRequired";
        public const string ParamFKDepartment = "@FK_Department";
        public const string paramFKManager = "@FK_Manager";
        public const string ParamFKRecruiter = "@FK_Recruiter";
        public const string ParamFKRoleId = "@Role";
        public const string paramIndustry = "@Industry";
        public const string paramDescription = "@JobDescription";
        public const string paramJobOpeningStatus = "@JobOpeningStatus";
        public const string paramJobTitle = "@JobTitle";
        public const string ParamJobType = "@JobType";
        public const string paramNOOfVacancy = "@NOOfVacancy";
        public const string ParamopeningId = "@openingId";
        public const string paramSkills = "@Skills";
        public const string paramState = "@State";
        public const string ParamTechnologies = "@Technologies";
        public const string ParamCreatedEmpID = "@CreatedEmpID";
        public const string paramModifiedEmpID = "@ModifiedEmpID";
        public const string ParamCreatedDate = "@CreatedDate";
        public const string ParamModifiedDate = "@ModifiedDate";
        public const string paramEndDate = "@EndDate";
        public const string paramStartDate = "@StartDate";
        public const string ParamFKCompanyId = "@FK_CompanyId";
        public const string ParamStatus = "@Status";
        public const string paramOperation = "@Operation";

        //save and update New Applicant and All Applicant
        public const string UspNewApplicant = "UspNewApplicantOper";
        public const string UspAllApplicant = "UspAllApplicant";
        public const string paramAdditionalInfo = "@AdditionalInfo";
        public const string paramAddress = "@Address";
        public const string ParamAssignedBy = "@AssignedBy";
        public const string paramAssignedTo = "@AssignedTo";
        public const string paramComments = "@Comments";
        public const string ParamCurrentCTC = "@CurrentCTC";
        public const string paramCurrentEmployer = "@CurrentEmployer";
        public const string ParamCurrentJobTitle = "@CurrentJobTitle";
        public const string ParamEmailId = "@EmailId";
        public const string paramExpectedCTC = "@ExpectedCTC";
        public const string paramExperianceinMonths = "@ExperianceinMonths";
        public const string paramFKApplicantIdStatus = "@FK_ApplicantIdStatus";
        public const string paramFKOpeningsId = "@FK_OpeningsId";
        public const string ParamHighestQualification = "@HighestQualification";
        public const string paramLinkedInID = "@LinkedInID";
        public const string ParamMobileNo = "@MobileNo";
        public const string paramName = "@Name";
        public const string paramNewApplicantId = "@NewApplicantId";
        public const string paramAllApplicantId = "@AllApplicantId";
        public const string ParamSkills = "@Skills";
        public const string ParamSkypeID = "@SkypeID";
        public const string ParamStreet = "@Street";
        public const string paramTwitterID = "@TwitterID";
        public const string paramZipCode = "@ZipCode";
        //ScheduleInterview 
        public const string UspInterviewSchedule = "UspInterviewSchedule";
        public const string paramDate = "@Date";
        public const string paramApplicantId = "@FK_ApplicantId";
        public const string ParamInterviewType = "@FK_InterviewType";
        public const string paramLocation = "@Location";
        public const string paramTime = "@Time";

        //function tblResourcesForProjects
        public const string tblInterviewers = "dbo.tblInterviewers";
        public const string colFKScheduleId = "FK_ScheduleId";
        public const string colInterviewer = "Interviewer";
        public const string colInterviewerStatusId = "InterviewerStatusId";
        public const string colComments = "Comments";
        public const string colAttachments = "Attachments";
        public const string FKScheduleId = "FKScheduleId";
        public const string Interviewer = "Interviewer";
        public const string InterviewerStatusId = "InterviewerStatusId";
        public const string Comments = "Comments";
        public const string Attachments = "Attachments";

        //function InterviewAssessmentOper
        public const string UspInterviewAssessmentOper = "UspInterviewAssessmentOper";
        public const string paramFKInterviewerId = "@FK_InterviewerId";
        public const string paramFKScheduledId = "@FK_ScheduledId";
        public const string ParamInterpersonalSkills = "@InterpersonalSkills";
        public const string paramInterviewAssessmentId = "@InterviewAssessmentId";
        public const string paramLeadershipSkills = "@LeadershipSkills";
        public const string ParamPresentaitonSkills = "@PresentaitonSkills";
        public const string paramStatus = "@Status";
        public const string paramTeamwork = "@Teamwork"; 
        public const string paramTechinicalAbility = "@TechinicalAbility";

        //function ApplicantStatusUpdate
        public const string UspUpdateNewApplicant = "UspUpdateNewApplicant";
        public const string paramSApplicantId = "@ApplicantId";
        public const string paramOpeningId = "@OpeningId";
        public const string ParamStatusId = "@StatusId";
        public const string paramAssignTo = "@AssignTo";
        public const string paramAssignBy = "@AssignBy";
        public const string ParamComments = "@Comments";

        //function ApplicantStatusUpdate
        public const string UspTimesheetReport = "UspTimesheetReport";
        public const string paramEmpID = "@EmpID";
        public const string paramst_date = "@st_date";
        public const string Paramed_date = "@ed_date";
        public const string ParamProjectId = "@ProjectId";

        //function InterviewScheduleUpdate
        public const string UspUpdateInterViewSchedule = "UspUpdateInterViewSchedule";
        public const string paramcomments = "@comments";
        public const string paramattachments = "@attachments";
        public const string ParamstatusId = "@statusId";
        public const string ParamnewappId = "@newappId";
        public const string ParaminterviewerId = "@interviewerId";
        public const string Paraminterviewer= "@interviewer";
        public const string Paramoperation = "@operation";

        //Update JoinedEmpolyee
        public const string UspUpdateJoinedEmpolyee = "UspUpdateJoinedEmpolyee";
        public const string paramEmail = "@Email";
        public const string paramModifiedId = "@ModifiedId";
        public const string ParamId = "@Id"; 
        public const string ParamOperation = "@Operation";
    }
}