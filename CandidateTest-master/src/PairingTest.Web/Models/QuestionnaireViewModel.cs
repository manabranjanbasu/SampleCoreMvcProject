using System.Collections.Generic;

namespace PairingTest.Web.Models
{
    public class QuestionnaireViewModel
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