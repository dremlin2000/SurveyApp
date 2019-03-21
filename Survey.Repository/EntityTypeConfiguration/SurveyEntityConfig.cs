using Data.EFRepository.Base.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Core.Model;
using System;

namespace Survey.Repository.EntityTypeConfiguration
{
    public class SurveyEntityConfig: EntityBaseConfiguration<Core.Model.Survey, Guid>
    {
        public override void Configure(EntityTypeBuilder<Core.Model.Survey> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Core.Model.Survey));
        }
    }
}
