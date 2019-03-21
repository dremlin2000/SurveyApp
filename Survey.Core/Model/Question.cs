using Data.Repository.Base;
using System;
using System.Collections.Generic;

namespace Survey.Core.Model
{
    public class Question : EntityBase<Guid>
    {
        public string QuestionText { get; set; }
        public int OrderNum { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
