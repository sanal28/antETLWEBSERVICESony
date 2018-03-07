using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NuPortalWebservice.Common_Library
{
    public class HRConstants
    {
        public const string UspSaveAnnOrEvents = "UspSaveAnnOrEvents";
        public const string paramId = "@Id";
        public const string paramAttachments = "@AttachmentPath";
        public const string ParamCreatedEmpID = "@CreatedEmpID";
        public const string paramDescription = "@Description";
        public const string ParamEndDate = "@EndDate";
        public const string paramCompanyId = "@FK_CompanyId";
        public const string paramModifiedEmpId = "@ModifiedEmpID";
        public const string ParamStartDate = "@StartDate";
        public const string ParamStatus = "@Status";
        public const string paramTitle = "@Title";
        public const string ParamStartTime = "@StartTime";
        public const string ParamEndTime = "@EndTime";
        public const string paramOperation = "@Operation";

        //Save Training
        public const string UspSaveTraining = "UspSaveTraining";
        public const string paramTrainerId = "@FK_TrainerId";
        public const string paramIsAssessmentSent = "@IsAssessmentSent";
        public const string paramSubject = "@Subject";
        public const string paramDetails = "@Details";

        //Get events for month
        public const string UspEventsForCalendar = "UspGetDataForCalendar";
        public const string paramStartDate = "@StartDate";

        //Enroll Trainee
        public const string UspCreateTrainingTicket = "UspCreateTrainingTicket";
        public const string ParamRespondedBy = "@FK_RespondedBy";
        public const string ParamTrainee = "@FK_Trainee";
        public const string ParamTrainingId = "@FK_TrainingId";
        public const string ParamTicketStatus = "@TicketStatusId";

        //SaveTrainingAssessment
        public const string UspSaveTrainingAssessment = "UspSaveTrainingAssessment";
        public const string ParamAbilityToCompleteTaskOnTime = "@AbilityToCompleteTaskOnTime";
        public const string ParamAbilityToLearnNewConcept = "@AbilityToLearnNewConcept";
        public const string ParamAbilityToUnderstandConcept = "@AbilityToUnderstandConcept";
        public const string ParamAreasOfDevelopment = "@AreasOfDevelopment";
        public const string ParamAssistanceRequiredDuringCodeBuilding = "@AssistanceRequiredDuringCodeBuilding";
        public const string ParamComments = "@Comments";
        public const string ParamTrainingTicketId = "@FK_TrainingTicketId";
        public const string ParamImplementationOfNewlyLearntConcept = "@ImplementationOfNewlyLearntConcept";

        //Office polls
        public const string UspSaveOfficePolls = "UspSaveOfficePolls";
        public const string ParamNote = "@Note";
        public const string ParamIsCancelled = "@IsCancelled";

        //Save Questions
        public const string ParamFK_PollId = "@FK_PollId";
        public const string ParamFK_QuestionTypeId = "@FK_QuestionTypeId"; 
        public const string ParamQuestion = "@Question";

        //Save Options
        public const string tblPollOptions = "tblPollOptions";
        public const string FK_QuestionId = "FK_QuestionId";
        public const string ModifiedEmpID = "ModifiedEmpID";
        public const string CreatedEmpID = "CreatedEmpID";
        public const string OptionText = "OptionText";

        //Save Tb result
        public const string UspSaveTbResults = "UspSaveTbResults";
        public const string ParamTextValue = "@TextValue";

        //Save Options Result
        public const string tblPollOptionResult = "tblPollOptionResult";
        public const string FK_OptionId = "FK_OptionId";

        //Save publish type
        public const string PublishTypeId = "@PublishTypeId";
        public const string TextValue = "@TextValue";

    }
}