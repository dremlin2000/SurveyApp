using AutoMapper;
using System;

namespace Survey.Core.Automapper.Profiles
{
    public class AppProfile: Profile
    {
        public AppProfile()
        {
            CreateMap<Model.Survey, ViewModel.SurveyVm>().ReverseMap();
            CreateMap<Model.SurveyAnswer, ViewModel.SurveyAnswerVm>().ReverseMap();
            CreateMap<Model.Question, ViewModel.QuestionVm>().ReverseMap();
            CreateMap<Model.Answer, ViewModel.AnswerVm>().ReverseMap();
        }
    }
}
