using Data.Repository.Base;
using Survey.Core.Enum;
using System;

namespace Survey.Core.Model
{
    public class SurveyAnswer: EntityBase<Guid>
    {
        public Guid SurveyId { get; set; }
        public virtual Survey Survey { get; set; }
        public Guid AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
