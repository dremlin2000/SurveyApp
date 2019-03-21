using Survey.Core.ViewModel;
using System;
using System.Threading.Tasks;

namespace Survey.Core.Abstract.AppService
{
    public interface ISurveyService
    {
        Task<QuestionVm> GetNextQuesion(Guid? currentQuestionId);
        Task<Guid> AddSurvey(SurveyVm survey);
        Task<Guid> AddSurveyAnswer(SurveyAnswerVm surveyAnswer);
    }
}
