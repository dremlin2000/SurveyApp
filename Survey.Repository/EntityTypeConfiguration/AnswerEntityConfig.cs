using Data.EFRepository.Base.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Survey.Repository.EntityTypeConfiguration
{
    public class AnswerEntityConfig : EntityBaseConfiguration<Core.Model.Answer, Guid>
    {
        public override void Configure(EntityTypeBuilder<Core.Model.Answer> builder)
        {
            base.Configure(builder);

            builder.ToTable(nameof(Core.Model.Answer));
        }
    }
}