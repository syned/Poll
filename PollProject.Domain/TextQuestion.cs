namespace PollProject.Domain
{
    public class TextQuestion : Question
    {
        public TextQuestion()
        {
            Type = QuestionType.Text;
        }

        public string AnswerText { get; set; }
    }
}