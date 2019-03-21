using FluentValidation;
using Survey.Core.ViewModel;

namespace Survey.Core.Validator
{
    public class SurveyVmValidator : AbstractValidator<SurveyVm>
    {
        public SurveyVmValidator()
        {
            RuleFor(x => x.NickName)
              .NotEmpty()
              .WithMessage(x => $"[{nameof(x.NickName)}]: value is required");
        }
    }
}
