using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PollProject.Domain
{
    public class MultiSelectionQuestion : SelectionQuestion
    {
        public MultiSelectionQuestion()
        {
            Type = QuestionType.MultiSelection;
            SelectedAnswers = new Collection<Answer>();
        }

        public virtual ICollection<Answer> SelectedAnswers { get; set; } 
    }
}