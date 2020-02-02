using System;
using System.Linq;
using AskIt.Api.Models;

namespace AskIt.Api.Features.Question
{
    public class QuestionCreationValidator
    {
        private const string ESSAY_QUESTION_WITH_CHOICES = "Essay question cannot have choices";
        private const string CHOICE_QUESTION_WITHOUT_CHOICES = "Choice question must have at least two choices";
        private const string CHOICE_QUESTION_WITOUT_RIGHT_ANSWER = "At least one answer must be the right";

        public void Validate(QuestionCreateCommand request)
        {
            if (request.QuestionType == QuestionType.EssayQuestion && request.Choices?.Count > 0)
                throw new ArgumentException(ESSAY_QUESTION_WITH_CHOICES);

            if (request.QuestionType == QuestionType.SingleChoiceQuestion)
            {
                if (request.Choices?.Count <= 2)
                    throw new ArgumentException(CHOICE_QUESTION_WITHOUT_CHOICES);
            }

            if (request.QuestionType == QuestionType.MultipleChoiceQuestion)
            {
                if (request.Choices?.Count <= 2)
                    throw new ArgumentException(CHOICE_QUESTION_WITHOUT_CHOICES);
            }

            if (!request.Choices.Any(q => q.RightAnswer))
                throw new ArgumentException(CHOICE_QUESTION_WITOUT_RIGHT_ANSWER);
        }
    }
}