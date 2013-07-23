namespace PollProject.Domain
{
    public class SingleSelectionQuestion : SelectionQuestion
    {
        public SingleSelectionQuestion()
        {
            Type = QuestionType.SingleSelection;
        }

        public virtual Answer SelectedAnswer { get; set; }
    }
}