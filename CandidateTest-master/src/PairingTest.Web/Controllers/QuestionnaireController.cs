using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PairingTest.Web.Core.Models;
using PairingTest.Web.Models;
using PairingTest.WebCore.Interfaces;
using PairingTest.WebCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PairingTest.Web.Controllers
{
    
    public class QuestionnaireController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IQuestionnaireService _questionnaireService;
        private readonly IMapper _mapper;
        public QuestionnaireController(IConfiguration config, IQuestionnaireService questionnaireService, IMapper mapper)
        {
            _config = config;
            _questionnaireService = questionnaireService;
            _mapper = mapper;
        }
        //[HttpGet("/")]
        public async Task<ViewResult> Index(QuestionnaireViewModel qModel=null)
        {
            
            if (qModel!=null && !string.IsNullOrEmpty(qModel.questionnaireTitle))
            {
                return View(qModel);
            }
            else
            {
                List<QuestionnaireServiceModel> listQuestionnaire = await _questionnaireService.GetAllQuestionnaire(1);
                var questionnaireViewModel = _mapper.Map<List<QuestionnaireViewModel>>(listQuestionnaire);
                return View(questionnaireViewModel);
            }
        }
        public async Task<ActionResult> CalculateScore([FromBody] List<UserSelectedOption> lstUserSelectedOption)
        {
            string score = await _questionnaireService.CalculateScore(_mapper.Map<List<UserSelection>>(lstUserSelectedOption), 1);
            
            return Json(score);
        }
    }
}
