using Data.EFRepository.Base.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Core.Model;
using System;

namespace Survey.Repository.EntityTypeConfiguration
{
    public class SurveyAnswerEntityConfig : EntityBaseConfiguration<Core.Model.SurveyAnswer, Guid>
    {
        public override void Configure(EntityTypeBuilder<Core.Model.SurveyAnswer> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Core.Model.SurveyAnswer));
        }
    }
}
