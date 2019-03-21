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
    public class SurveyController : BaseController
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody]SurveyVm viewModel)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await _surveyService.AddSurvey(viewModel);
                return result;
            });
        }
    }
}