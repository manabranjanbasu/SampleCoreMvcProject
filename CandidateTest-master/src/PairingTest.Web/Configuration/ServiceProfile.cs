using AutoMapper;
using PairingTest.Web.Core.Models;
using PairingTest.Web.Models;
using PairingTest.WebCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairingTest.Web.Configuration
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<WebCore.Models.QuestionOption, Models.QuestionOption>();
            CreateMap<QuestionnaireServiceModel, QuestionnaireViewModel>();
            CreateMap<UserSelectedOption, UserSelection>();
        }
    }
}
