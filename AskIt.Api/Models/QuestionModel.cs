using System.Collections.Generic;

namespace AskIt.Api.Models
{
    public class QuestionModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public QuestionType QuestionType { get; set; }
        public IList<ChoiceModel> Choices { get; set; }

        public bool ShouldSerializeChoices()
        {
            return Choices?.Count > 0;
        }
    }
}