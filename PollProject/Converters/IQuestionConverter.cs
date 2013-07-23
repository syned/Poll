using PollProject.Domain;
using PollProject.Models;

namespace PollProject.Converters
{
    public interface IQuestionConverter
    {
        void Convert(QuestionViewModel questionViewModel, Question question);
    }
}