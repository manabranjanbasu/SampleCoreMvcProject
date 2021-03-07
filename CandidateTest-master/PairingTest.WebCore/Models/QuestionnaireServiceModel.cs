using System;
using System.Collections.Generic;
using System.Text;

namespace PairingTest.WebCore.Models
{
    public class QuestionnaireServiceModel
    {
        public string questionnaireTitle { get; set; }
        public List<QuestionOption> questionOption { get; set; }
        public int id { get; set; }
    }
    public class QuestionOption
    {
        public int questionID { get; set; }
        public string optionText { get; set; }
        public int id { get; set; }
    }
}
