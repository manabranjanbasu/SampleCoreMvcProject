using Microsoft.AspNetCore.Mvc;
using PairingTest.API.Core.Entities;
using PairingTest.API.Core.Interfaces;
using PairingTest.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PairingTest.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IQuestionnaireService questionnaireService;
        private readonly IScoreCalculation scoreCalculationService;
        public QuestionsController(IQuestionRepository questionRepository,
            IQuestionnaireService _questionnaireService,
            IScoreCalculation _scoreCalculationService)
        {
            _questionRepository = questionRepository;
            this.questionnaireService = _questionnaireService;
            this.scoreCalculationService = _scoreCalculationService;
        }

        // GET api/questions
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get([FromRoute] long categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response  = await this.questionnaireService.GetAllQuestionsWithOptions(categoryId);
            return Ok(response);
        }

        // POST api/questions
        [HttpPost("{categoryId}")]
        public async Task<IActionResult> Post([FromBody, Required] List<UserAnswer> lstUserAnswer,[FromRoute] long categoryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await this.scoreCalculationService.CalculateScore(lstUserAnswer, categoryId);
            return Ok(response);
        }
    }
}
