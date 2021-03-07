using PairingTest.WebCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using PairingTest.WebCore.Configuration;
using Microsoft.Extensions.Options;
using PairingTest.WebInfrastructure.Constants;
using Newtonsoft.Json;
using PairingTest.WebCore.Interfaces;
using PairingTest.Web.Core.Models;

namespace PairingTest.WebInfrastructure.Services
{
    public class QuestionnaireQueryService : IQuestionnaireQueryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ServiceURLOptions _serviceUrlOptions;

        public QuestionnaireQueryService(IOptions<ServiceURLOptions>
            serviceUrlOptions,
            IHttpClientFactory httpClientFactory)
        {
            _serviceUrlOptions = serviceUrlOptions != null
                ? serviceUrlOptions.Value
                : throw new ArgumentNullException($"Options/Configuration not found for {nameof(serviceUrlOptions)}");
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        public async Task<List<QuestionnaireServiceModel>> GetAllQuestionnaire(long categoryId)
        {
            List<QuestionnaireServiceModel> lstQuestionnaireServiceModel = null;
            using var httpClient = _httpClientFactory.CreateClient(HttpClientConstants.HttpClientWithBackOff);
            httpClient.DefaultRequestHeaders.Add("ApiKey", _serviceUrlOptions.APIKey);
            var questionnaireResponse = await httpClient.GetAsync($"{_serviceUrlOptions.Questionnaire}/Questions/{categoryId}");
            var qResponse = await questionnaireResponse.Content.ReadAsStringAsync();
            if (questionnaireResponse.IsSuccessStatusCode)
            {
                lstQuestionnaireServiceModel = JsonConvert.DeserializeObject<List<QuestionnaireServiceModel>>(qResponse);
            }

            return lstQuestionnaireServiceModel;
        }
        public async Task<string> CalculateScore(List<UserSelection> lstUserSelection, long categoryId)
        {
            string scorereport = null;
            using var httpClient = _httpClientFactory.CreateClient(HttpClientConstants.HttpClientWithBackOff);
            httpClient.DefaultRequestHeaders.Add("ApiKey", _serviceUrlOptions.APIKey);
            var stringcontent =JsonConvert.SerializeObject(lstUserSelection);
            HttpContent content = new StringContent(stringcontent, Encoding.UTF8, "application/json");
            var questionnaireResponse = await httpClient.PostAsync($"{_serviceUrlOptions.Questionnaire}/Questions/{categoryId}", content);
            var qResponse = await questionnaireResponse.Content.ReadAsStringAsync();
            if (questionnaireResponse.IsSuccessStatusCode)
            {
                scorereport = qResponse;
            }

            return scorereport;
        }
    }
}
