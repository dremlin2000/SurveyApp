using Microsoft.EntityFrameworkCore;
using Survey.Core.Model;
using System;
using System.Linq;
using System.Reflection;

namespace Survey.Repository
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            //Apply all existing EntityTypeConfigurations in executing assembly
            var configTypes = 
                Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition && 
                t.GetTypeInfo().ImplementedInterfaces.Any(i => i.GetTypeInfo().IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var configType in configTypes)
            {
                dynamic config = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration(config);
            }

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = new Guid("adb23657-4208-43f5-9af3-141652459128"),
                    OrderNum = 1,
                    QuestionText = "What is your favorite colour?"
                });
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = new Guid("d1de96f7-603c-4ce3-ad78-0add7369a6f5"),
                    OrderNum = 2,
                    QuestionText = "What is your favorite car?"
                });

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = new Guid("e1cb5d46-637c-4f1f-af00-987f3bb7afb7"),
                    QuestionId = new Guid("adb23657-4208-43f5-9af3-141652459128"),
                    AnswerText =  "Blue"
                });
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = new Guid("56613ec3-a2e3-4d9c-a08c-fb30cc323026"),
                    QuestionId = new Guid("adb23657-4208-43f5-9af3-141652459128"),
                    AnswerText = "Yellow"
                });
            modelBuilder.Entity<Answer>().HasData(
               new Answer
               {
                   Id = new Guid("82604737-4ab6-4896-9bd9-d7697baa41b8"),
                   QuestionId = new Guid("adb23657-4208-43f5-9af3-141652459128"),
                   AnswerText = "Green"
               });
            //Car
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = new Guid("b77fce97-1438-47f3-8847-61b290d3f34f"),
                    QuestionId = new Guid("d1de96f7-603c-4ce3-ad78-0add7369a6f5"),
                    AnswerText = "Toyota"
                });
            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = new Guid("57777054-175c-46ca-bd37-4745bb11371a"),
                    QuestionId = new Guid("d1de96f7-603c-4ce3-ad78-0add7369a6f5"),
                    AnswerText = "Mazda"
                });
            modelBuilder.Entity<Answer>().HasData(
               new Answer
               {
                   Id = new Guid("e144bab9-259a-4688-9476-a24fa579854e"),
                   QuestionId = new Guid("d1de96f7-603c-4ce3-ad78-0add7369a6f5"),
                   AnswerText = "Ferrari"
               });
            modelBuilder.Entity<Answer>().HasData(
              new Answer
              {
                  Id = new Guid("ec017440-158b-49b4-99cf-93fce3514964"),
                  QuestionId = new Guid("d1de96f7-603c-4ce3-ad78-0add7369a6f5"),
                  AnswerText = "Lamborghini"
              });
        }
    }
}
