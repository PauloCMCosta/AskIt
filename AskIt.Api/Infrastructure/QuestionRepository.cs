using System.Collections.Generic;
using System.Threading.Tasks;
using AskIt.Api.Models;

namespace AskIt.Api.Infrastructure
{
    public class QuestionRepository : IQuestionRepository
    {
        public QuestionRepository()
        {
            Questions = new List<QuestionModel>();
        }

        private IList<QuestionModel> Questions {get;}

        public async Task<IEnumerable<QuestionModel>> Get()
        {
            return await Task.FromResult(Questions);
        }

        public async Task Save(QuestionModel question)
        {
            await Task.Run(() => Questions.Add(question));
        }
    }
}