using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using PollProject.Domain;

namespace PollProject.Models
{
    public class SingleSelectionQuestionViewModel : QuestionViewModel
    {
        public SingleSelectionQuestionViewModel() { }

        public SingleSelectionQuestionViewModel(SingleSelectionQuestion question) : base(question)
        {
            SelectedAnswerId = question.SelectedAnswer != null ? question.SelectedAnswer.Id : (int?)null;
            Answers = question.Answers.Select(x => new AnswerViewModel
                                                       {
                                                           Id = x.Id,
                                                           Title = x.Title
                                                       }).ToList();
        }

        [Required(ErrorMessage = "Please select answer.")]
        public int? SelectedAnswerId { get; set; }

        public IList<AnswerViewModel> Answers { get; private set; }

        public object SelectedAnswerText { get; set; }
    }
}