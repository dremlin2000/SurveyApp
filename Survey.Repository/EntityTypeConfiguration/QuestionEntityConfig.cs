using Data.EFRepository.Base.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Survey.Repository.EntityTypeConfiguration
{
    public class QuestionEntityConfig : EntityBaseConfiguration<Core.Model.Question, Guid>
    {
        public override void Configure(EntityTypeBuilder<Core.Model.Question> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Core.Model.Question));
        }
    }
}