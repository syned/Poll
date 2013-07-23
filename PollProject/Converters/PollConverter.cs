using System.Linq;
using PollProject.DAL;
using PollProject.Domain;
using PollProject.Models;

namespace PollProject.Converters
{
    /// <summary>
    /// Converter from Model to ViewModel and vice versa
    /// </summary>
    public class PollConverter
    {
        private readonly IRepository _repository;
        private readonly IQuestionConverter _questionConverter;

        public PollConverter(IRepository repository)
        {            
            _repository = repository;
            _questionConverter = new QuestionConverter(_repository);
        }

        public PollViewModel Convert(Poll poll)
        {
            return new PollViewModel
            {
                Id = poll.Id,
                Title = poll.Title,
                Questions = poll.Questions.Select(QuestionViewModel.Create).ToList()
            };
        }

        public void Convert(Poll poll, PollViewModel pollViewModel)
        {
            for (int i = 0; i < pollViewModel.Questions.Count; i++)
            {
                _questionConverter.Convert(pollViewModel.Questions[i], poll.Questions[i]);
            }
        }
    }
}