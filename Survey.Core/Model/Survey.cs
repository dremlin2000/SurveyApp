using Data.Repository.Base;
using Survey.Core.Enum;
using System;

namespace Survey.Core.Model
{
    public class Survey: EntityBase<Guid>
    {
        public string NickName { get; set; }
        public SurveyStatus SurveyStatus { get; set; }
    }
}
