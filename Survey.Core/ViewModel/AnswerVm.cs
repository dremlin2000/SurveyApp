using System;

namespace Survey.Core.ViewModel
{
    public class AnswerVm
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string AnswerText { get; set; }
    }
}
