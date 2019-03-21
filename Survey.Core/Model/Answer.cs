using Data.Repository.Base;
using System;

namespace Survey.Core.Model
{
    public class Answer : EntityBase<Guid>
    {
        public Guid QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public string AnswerText { get; set; }
    }
}
