using System;
using System.Collections.Generic;

namespace Survey.Core.ViewModel
{
    public class QuestionVm
    {
        public Guid Id { get; set; }
        public string QuestionText { get; set; }
        public int OrderNum { get; set; }
        public virtual IEnumerable<AnswerVm> Answers { get; set; }
        public bool IsLast { get; set; }
    }
}
