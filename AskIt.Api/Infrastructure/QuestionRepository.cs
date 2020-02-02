using System.Collections.Generic;
using System.Threading.Tasks;
using AskIt.Api.Models;

namespace AskIt.Api.Infrastructure
{
    public class QuestionRepository : IQuestionRepository
    {
        public QuestionRepository()
        {
            Questions = new List<Question>();
        }

        private IList<Question> Questions {get;}
        
        public async Task Save(Question question)
        {
            await Task.Run(() => Questions.Add(question));
        }
    }
}