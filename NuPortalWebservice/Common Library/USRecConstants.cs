﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuPortalWebservice.Common_Library
{
    public class USRecConstants
    {
        //Save Opportunity

        public const string connection = "Connection";
        public const string UspSaveRecOpportunity = "UspSaveRecOpportunity"; 
        public const string paramOppId = "@OppId";
        public const string paramFKCompanyId = "@FKCompanyId";
        public const string paramStreet = "@Street";
        public const string paramCity = "@City";
        public const string paramState = "@State";
        public const string paramZipCode = "@ZipCode";
        public const string paramClientName = "@ClientName";
        public const string paramContact1 = "@Contact1";
        public const string paramContact2 = "@Contact2";
        public const string paramContactPerson = "@ContactPerson";
        public const string paramCreatedEmpID = "@CreatedEmpID";
        public const string paramEmail = "@Email";
        public const string paramExperience = "@Experience";
        public const string paramFax = "@Fax";
        public const string paramHours = "@Hours";
        public const string paramIsCancelled = "@IsCancelled";
        public const string paramIsClosed = "@IsClosed";
        public const string paramLocation = "@Location";
        public const string paramModifiedEmpID = "@ModifiedEmpID";
        public const string paramNoOfOpenings = "@NoOfOpenings";
        public const string paramPositionTitle = "@PositionTitle";
        public const string paramFKPositionType = "@FKPositionType";
        public const string paramFKIndustry = "@FKIndustry";
        public const string paramTargetDate = "@TargetDate";
        public const string paramJobDescription = "@JobDescription";
        public const string paramProfileType = "@ProfileType";
        public const string paramRate = "@Rate";
        public const string paramWebsite = "@Website";
        public const string paramStatus = "@Status"; 
        public const string paramGender = "@Gender"; 
        public const string paramNote = "@Note";
        public const string paramAttachments = "@Attachments";
        public const string paramOperation = "@Operation";

        //save required docs

        public const string tblRecRequiredDocs = "tblRecRequiredDocs";
        public const string Fk_OppId = "Fk_OppId";
        public const string DocType = "DocType";
        public const string CreatedDate = "CreatedDate";
        public const string ModifiedDate = "ModifiedDate";
        public const string colCreatedEmpID = "CreatedEmpID";
        public const string colModifiedEmpID = "ModifiedEmpID";

        //Save Lead
        public const string UspSaveRecLead = "UspSaveRecLead";
        public const string VisaType= "@VisaType";
        public const string Street= "@Street";
        public const string City= "@City";
        public const string Zip = "@Zip";
        public const string State= "@State";
        public const string Country= "@Country";
        public const string HighestQualification= "@HighestQualification";
        public const string Status = "@Status"; 
        public const string FKStatus = "@FKStatus";
        public const string Source= "@Source";
        public const string Certification = "@Certification";
        public const string CurrentCTC = "@CurrentCTC";
        public const string CurrentDesignation = "@CurrentDesignation";
        public const string CurrentEmployer = "@CurrentEmployer";
        public const string CurrentLocation = "@CurrentLocation";
        public const string DOB = "@DOB";
        public const string EmailId = "@EmailId";
        public const string EmployeeType = "@EmployeeType";
        public const string EmploymentType = "@EmploymentType";
        public const string ExperienceInMonths = "@ExperienceInMonths";
        public const string FirstName = "@FirstName";
        public const string Gender = "@Gender";
        public const string Hours = "@Hours";
        public const string LastName = "@LastName";
        public const string LeadId = "@LeadId";
        public const string LeadType = "@LeadType";
        public const string Location = "@Location";
        public const string MobileNo = "@MobileNo";
        public const string Note = "@Note";
        public const string Rate = "@Rate";
        public const string Skills = "@Skills";
        public const string Technologies = "@Technologies";
        public const string IsCitizen = "@IsCitizen";
        public const string IsGreenCardHolder = "@IsGreenCardHolder";
        public const string RecStatus = "@FK_RecStatus";

        //save Skills
        public const string tblRecSkills = "dbo.tblRecSkills";
        public const string tblLeadSkills = "dbo.tblLeadSkills";
        public const string colFKOpportunityId = "FK_OpportunityId";
        public const string colSkills = "Skills";
        public const string colTypeId = "TypeId";
        public const string FKOpportunityId = "FKOpportunityId";
        public const string Skill = "Skill";
        public const string TypeId = "TypeId";

        //save LeadSkills
        public const string colFKLeadId = "FK_LeadId";
        public const string FKLeadId = "FKLeadId";

        //Save Interview
        public const string UspSaveRecInterview = "UspSaveRecInterview";
        public const string paramFKInterviewtype = "@FK_Interviewtype";
        public const string paramFKSubmissionId = "@FK_SubmissionId";
        public const string paramFKTicketStatusId = "@FK_TicketStatusId";
        public const string paramInterviewDate = "@InterviewDate";
        public const string paramInterviewId = "@InterviewId";
        public const string paramInterviewTime= "@InterviewTime";

        //Save Contract
        public const string UspSaveRecContract = "UspSaveRecContract";
        public const string ContractId = "@ContractId";
        public const string FK_SubmissionId = "@FK_SubmissionId";
        public const string Title = "@Title";
        public const string Date = "@Date";
        public const string SignedBy = "@SignedBy";
        public const string TitleClient = "@TitleClient";
        public const string DateClient = "@DateClient";
        public const string SignedByClient = "@SignedByClient";
        public const string ContractExpiryDate = "@ContractExpiryDate";
        public const string IsRateConfirmationPresent = "@IsRateConfirmationPresent";

        //Save contract docs
        public const string tblRecContractDocs = "tblRecContractDocs";
        public const string colFK_ContractId = "FK_ContractId";
        public const string colDocName = "DocName";
        public const string colDocUrl = "DocUrl";

        //Save Vendor Details
        public const string UspSaveRecVendorDetails = "UspSaveRecVendorDetails";
        public const string paramVendorDetailsId = "@VendorDetailsId";
        public const string paramFK_SubmissionId = "@FK_SubmissionId";
        public const string paramCompanyName = "@CompanyName";
        public const string paramCompanyID = "@CompanyID";
        public const string paramCompanyAddress = "@CompanyAddress";
        public const string paramContactPerson1Name = "@ContactPerson1Name";
        public const string paramContactPerson1Title = "@ContactPerson1Title";
        public const string paramContactPerson2Name = "@ContactPerson2Name";
        public const string paramContactPerson2Title = "@ContactPerson2Title";
        public const string paramContactPerson3Name = "@ContactPerson3Name";
        public const string paramContactPerson3Title = "@ContactPerson3Title";
        public const string paramVendorID = "@VendorID";
        public const string paramDepositoryBankName = "@DepositoryBankName";
        public const string paramBranch = "@Branch";
        public const string paramRoutingNumber = "@RoutingNumber";
        public const string paramAccountName = "@AccountName";
        public const string paramAccountNumber = "@AccountNumber";
        public const string paramAccountType = "@AccountType";
        public const string paramVendorName = "@VendorName";
        public const string paramIDNumber = "@IDNumber";
        public const string paramSignedBy = "@SignedBy";
        public const string paramDesignation = "@Designation";
        public const string paramDate = "@Date";

        //Save Invoice Details
        public const string UspSaveInvoiceDetails = "UspSaveRecInvoiceDetails";
        public const string paramInvoiceId = "@InvoiceId";
        public const string paramName = "@Name";
        public const string paramTerms = "@Terms";
        public const string paramFK_BillingCycle = "@FK_BillingCycle";
        public const string paramCountry = "@Country";
        public const string paramZip = "@Zip";
        public const string paramCcList = "@CcList";

        //Save Invoice Contract Details
        public const string tblRecInvoiceContactDetails = "tblRecInvoiceContactDetails";
        public const string colFK_InvoiceId = "FK_InvoiceId";
        public const string colName = "Name";
        public const string colEmail = "Email";
        public const string colTerms = "Terms";
        public const string colFK_ContractType = "FK_ContractType";
        public const string colStreet = "Street";
        public const string colCity = "City";
        public const string colState = "State";
        public const string colCountry = "Country";
        public const string colZip = "Zip";
        public const string colPhone = "Phone";

        //Save Submissions
        public const string UspSaveRecSubmissions = "UspSaveRecSubmissions";
        public const string paramSubmissionId = "@SubmissionId";
        public const string paramFK_OppId = "@FK_OppId";
        public const string paramFK_LeadId = "@FK_LeadId";
        public const string paramAssignedTo = "@AssignedTo";
        public const string paramFKSubmissionStatusId = "@FK_SubmissionStatusId";
        public const string paramFK_TicketStatusId = "@FK_TicketStatusId";

        //Save Submitted Visa Docs Details
        public const string tblRecSubmittedVisaDocs = "tblRecSubmittedVisaDocs";
        public const string colFK_VisaProcessingId = "FK_VisaProcessingId";
        public const string colFK_DocTypeId = "FK_DocTypeId";
        public const string colDocPath = "DocPath";
        public const string colDocTag = "DocTag";
        public const string colCreatedDate = "CreatedDate";
        public const string colModifiedDate = "ModifiedDate";

        //Save Submitted Docs Details
        public const string tblRecSubmittedDocs = "tblRecSubmittedDocs";
        public const string colFk_SubmissionId = "Fk_SubmissionId";

        //Save Visa Processing
        public const string UspSaveRecVisaProcessing = "UspSaveRecVisaProcessing"; 
        public const string paramCompanyDescription = "@CompanyDescription";
        public const string paramCompanyEstDate= "@CompanyEstDate";
        public const string paramEmpAbroadAddress= "@EmpAbroadAddress";
        public const string paramEmpCountryOfBirth= "@EmpCountryOfBirth";
        public const string paramEmpDOB= "@EmpDOB";
        public const string paramEmpFname= "@EmpFname";
        public const string paramEmpLname= "@EmpLname";
        public const string paramEmpMName = "@EmpMName";
        public const string paramEmpNearestConsulate= "@EmpNearestConsulate";
        public const string paramEmpPlaceOfBirth= "@EmpPlaceOfBirth";
        public const string paramEmpSSN= "@EmpSSN";
        public const string paramEmpUSAddress= "@EmpUSAddress";
        public const string paramFederalTAXIDNumber = "@FederalTAXIDNumber";
        public const string paramGrossAnnualIncome= "@GrossAnnualIncome";
        public const string paramI94IssueDate= "@I94IssueDate";
        public const string paramI94Number= "@I94Number";
        public const string paramI94ValidityDate= "@I94ValidityDate";
        public const string paramIsCompanyH1BDependent= "@IsCompanyH1BDependent";
        public const string paramJobLocationAddress= "@JobLocationAddress";
        public const string paramJobTitleOffered= "@JobTitleOffered";
        public const string paramLastI797ApprovalReceipt = "@LastI797ApprovalReceipt";
        public const string paramMaritalStatus = "@MaritalStatus";
        public const string paramNameOfPersonToSign= "@NameOfPersonToSign";
        public const string paramNetIncome= "@NetIncome";
        public const string paramNoOfEmployees= "@NoOfEmployees";
        public const string paramNoOfH1BEmployees= "@NoOfH1BEmployees";
        public const string paramPassportIssueDate= "@PassportIssueDate";
        public const string paramPassportNumber= "@PassportNumber";
        public const string paramPassportValidityDate= "@PassportValidityDate";
        public const string paramPhone= "@Phone";
        public const string paramSalaryOffered= "@SalaryOffered";
        public const string paramTitleOfPersonToSign= "@TitleOfPersonToSign";
        public const string paramVisaProcessingId= "@VisaProcessingId";
        public const string paramTicketSubmissionDate = "@TicketSubmissionDate";

        public const string paramFKCandidate = "@FK_Candidate";
        public const string paramClient = "@Client";



        //Save Visa Date Details
        public const string tblRecVisaDateDetails = "tblRecVisaDateDetails";
        public const string colVisaEntryDate = "VisaEntryDate";
        public const string colVisaExitDate = "VisaExitDate";

        //Save Family Visa Details
        public const string tblRecFamilyVisaDetails = "tblRecFamilyVisaDetails";
        public const string colFk_VisaDetailsId = "Fk_VisaDetailsId";
        public const string colFirstName = "FirstName";
        public const string colLastName = "LastName";
        public const string colPlaceOfBirth = "PlaceOfBirth";
        public const string colDOB = "DOB";
        public const string colSOSSec = "SOSSec";
        public const string colEntryDateOfUSRes = "EntryDateOfUSRes";
        public const string colExitDateOfUSRes = "ExitDateOfUSRes";
        public const string colRelationShip = "RelationShip";
        public const string colI94IfTheFamilyIsInUsa = "I94IfTheFamilyIsInUsa";
        public const string colPassportVisaPage = "PassportVisaPage";
        public const string colPassportPhotoPage = "PassportPhotoPage";
        public const string colI94TagName = "I94TagName";
        public const string colVisaTagName = "VisaTagName";
        public const string colPhotoTagName = "PhotoTagName";

        //function CreateRecEmployee
        public const string UspRecEmployeeOper = "UspRecEmployeeOper";
        public const string paramRecEmpId = "@RecEmpId";
        public const string paramBackGroundPicUrl = "@BackGroundPicUrl";
        public const string paramConfirmationDate = "@ConfirmationDate";
        public const string ParamEmployeeCode = "@EmployeeCode";
        public const string ParamEmpRating = "@EmpRating";
        public const string paramEndTime = "@EndTime";
        public const string paramFirstName = "@FirstName";
        public const string paramCompanyId = "@FK_CompanyId";
        public const string ParamFKDesignationId  = "@FK_DesignationId";
        public const string paramFkEmpStatus = "@Fk_ EmpStatus ";
        public const string paramFKEmptTypeId = "@FK_EmptTypeId ";
        public const string ParamFkSalaryType = "@Fk_SalaryType";
        public const string paramFkTypeOfVisa = "@Fk_TypeOfVisa ";
        public const string paramInsuranceAmount = "@InsuranceAmount";
        public const string ParamInsurancePaidBy= "@InsurancePaidBy";
        public const string paramIsUSBench = "@IsUSBench";
        public const string ParamLastName = "@LastName";
        public const string paramManager = "@Manager";
        public const string ParamModifiedDate= "@ModifiedDate";
        public const string ParamPassportUrl = "@PassportUrl";
        public const string ParamQuotesText = "@QuotesText";
        public const string paramProfilePicUrl = "@ProfilePicUrl";
        public const string ParamRelievingAttachments = "@RelievingAttachments";
        public const string paramRelievingDate = "@RelievingDate";
        public const string ParamStartTime = "@StartTime";
        public const string ParamTitle= "@Title";
        public const string ParamTrainingDate = "@TrainingDate";
        public const string paramVisaExpiryDate = "@VisaExpiryDate";
        public const string ParamWeekOffDays= "@WeekOffDays";
        public const string paramWorkEmail = "@WorkEmail";
        public const string paramWorkLocation = "@WorkLocation";

        //function Task status report
        public const string TaskStatusReport = "uspTaskStatusReport";
        public const string paramStartDate = "@StartDate";
        public const string paramEndDate = "@EndDate";
        public const string paramOffset = "@Offset";
        public const string ParamRowCount = "@RowCount";
        public const string paramId = "@Id";
        public const string paramProjectId = "@ProjectId"; 
        public const string employeeTaskStatusReoprt = "employeeTaskStatusReoprt";

    }
}
			