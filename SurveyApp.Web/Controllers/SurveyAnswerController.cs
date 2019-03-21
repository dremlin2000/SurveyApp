using Microsoft.AspNetCore.Mvc;
using Survey.Core.Abstract.AppService;
using Survey.Core.ViewModel;
using Survey.Web.Infrastructure.ActionFilters;
using System.Threading.Tasks;

namespace Survey.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(UnitOfWorkActionFilter))]
    public class SurveyAnswerController : BaseController
    {
        private readonly ISurveyService _surveyService;

        public SurveyAnswerController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]SurveyAnswerVm viewModel)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await _surveyService.AddSurveyAnswer(viewModel);
                return result;
            });
        }
    }
}