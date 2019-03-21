using FluentValidation;
using Survey.Core.ViewModel;

namespace Survey.Core.Validator
{
    public class SurveyAnswerVmValidator : AbstractValidator<SurveyAnswerVm>
    {
        public SurveyAnswerVmValidator()
        {
            RuleFor(x => x.SurveyId)
              .NotEmpty()
              .WithMessage(x => $"[{nameof(x.SurveyId)}]: value is required");

            RuleFor(x => x.AnswerId)
              .NotEmpty()
              .WithMessage(x => "Please choose an answer");
        }
    }
}
