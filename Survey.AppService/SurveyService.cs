using Survey.Core.Abstract.AppService;
using Survey.Core.Abstract.Repository;
using Survey.Core.Validator;
using Survey.Core.ViewModel;
using Lib.Utils.Abstract;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Survey.Core.Model;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.AppService
{
    public class SurveyService : ISurveyService
    {
        private readonly IAppRepository _appRepository;
        private readonly IModelValidator _modelValidator;
        private readonly IObjectMapper _objectMapper;

        public SurveyService(IAppRepository appRepository, IModelValidator modelValidator, IObjectMapper objectMapper)
        {
            _appRepository = appRepository;
            _modelValidator = modelValidator;
            _objectMapper = objectMapper;
        }

        public async Task<Guid> AddSurvey(SurveyVm viewModel)
        {
            await _modelValidator.ValidateAsync<SurveyVm, SurveyVmValidator>(viewModel);

            var model = _objectMapper.Map<SurveyVm, Core.Model.Survey>(viewModel);
            model.SurveyStatus = Core.Enum.SurveyStatus.BeingEntered;
            _appRepository.Create(model);
            await _appRepository.SaveAsync();

            return model.Id;
        }

        public async Task<Guid> AddSurveyAnswer(SurveyAnswerVm viewModel)
        {
            await _modelValidator.ValidateAsync<SurveyAnswerVm, SurveyAnswerVmValidator>(viewModel);

            var model = _objectMapper.Map<SurveyAnswerVm, Core.Model.SurveyAnswer>(viewModel);

            _appRepository.Create(model);

            var question = (await _appRepository.GetAsync<Question>(filter: x => x.Answers.Any(y => y.Id == viewModel.AnswerId))).Single();
            var isLast = await IsLast(question);
            if (isLast)
            {
                var survey = (await _appRepository.GetAsync<Core.Model.Survey>(filter: x => x.Id == viewModel.SurveyId)).Single();
                survey.SurveyStatus = Core.Enum.SurveyStatus.Submitted;
            }

            await _appRepository.SaveAsync();

            return model.Id;
        }

        private async Task<bool> IsLast(Question question)
        {
            return !(await _appRepository.GetAsync<Question>(filter: x => x.OrderNum > question.OrderNum,
                                take: 1, orderBy: x => x.OrderBy(y => y.OrderNum))).Any();
        }

        public async Task<QuestionVm> GetNextQuesion(Guid? currentQuestionId)
        {
            Question question = null;
            if (!currentQuestionId.HasValue)
            {
                question = (await _appRepository.GetAsync<Question>(
                    take: 1, orderBy: x => x.OrderBy(y => y.OrderNum),
                    includeProperties: new Expression<Func<Question, object>>[] { x => x.Answers })).FirstOrDefault();
            }
            else
            {
                var currentQuestion = (await _appRepository.GetAsync<Question>(filter: x => x.Id == currentQuestionId.Value)).Single();
                question = (await _appRepository.GetAsync<Question>(filter: x => x.OrderNum > currentQuestion.OrderNum,
                    take: 1, orderBy: x => x.OrderBy(y => y.OrderNum),
                    includeProperties: new Expression<Func<Question, object>>[] { x => x.Answers })).FirstOrDefault();
            }

            var returnResult = _objectMapper.Map<Question, QuestionVm>(question);

            if (question != null)
                returnResult.IsLast = await IsLast(question);

            return returnResult;
        }
    }
}
