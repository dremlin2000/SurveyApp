using Survey.Core.Enum;
using System;

namespace Survey.Core.ViewModel
{
    public class SurveyVm
    {
        public Guid? Id { get; set; }
        public string NickName { get; set; }
        public SurveyStatus SurveyStatus { get; set; }
    }
}
