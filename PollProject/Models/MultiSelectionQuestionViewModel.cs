using System.Collections.Generic;
using System.Linq;
using PollProject.Domain;

namespace PollProject.Models
{
    public class MultiSelectionQuestionViewModel : QuestionViewModel
    {
        public MultiSelectionQuestionViewModel() {}

        public MultiSelectionQuestionViewModel(MultiSelectionQuestion question) : base(question)
        {
            Answers = question.Answers.Select(x => new AnswerViewModel
                                                       {
                                                           Id = x.Id,
                                                           Title = x.Title
                                                       }).ToList();

            if (question.SelectedAnswers == null) return;

            foreach (var viewModel in Answers)
            {
                viewModel.IsChecked = question.SelectedAnswers.Any(x => x.Id == viewModel.Id);
            }
        }

        public IList<AnswerViewModel> Answers { get; set; }

        public IList<AnswerViewModel> SelectedAnswers
        {
            get { return Answers.Where(x => x.IsChecked).ToList(); }
        } 
    }
}