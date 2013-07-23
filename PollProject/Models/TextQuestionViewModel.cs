using System.ComponentModel.DataAnnotations;
using PollProject.Domain;

namespace PollProject.Models
{
    public class TextQuestionViewModel : QuestionViewModel
    {
        public TextQuestionViewModel() { }

        public TextQuestionViewModel(TextQuestion textQuestion) : base(textQuestion)
        {
            AnswerText = textQuestion.AnswerText;
        }

        [Required(ErrorMessage = "Answer is required.")]
        [DataType(DataType.MultilineText)]
        public string AnswerText { get; set; }
    }
}