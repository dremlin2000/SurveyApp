using System;

namespace Survey.Core.ViewModel
{
    public class SurveyAnswerVm
    {
        public Guid? Id { get; set; }
        public Guid? SurveyId { get; set; }
        public Guid? AnswerId { get; set; }
    }
}
