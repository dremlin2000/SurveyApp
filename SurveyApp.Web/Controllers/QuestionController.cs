using Microsoft.AspNetCore.Mvc;
using Survey.Core.Abstract.AppService;
using Survey.Web.Infrastructure.ActionFilters;
using System;
using System.Threading.Tasks;

namespace Survey.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(UnitOfWorkActionFilter))]
    public class QuestionController : BaseController
    {
        private readonly ISurveyService _surveyService;

        public QuestionController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet()]
        public async Task<IActionResult> Next(Guid? id)
        {
            return await ExecuteAsync(async () =>
            {
                var result = await _surveyService.GetNextQuesion(id);
                return result;
            });
        }
    }
}
