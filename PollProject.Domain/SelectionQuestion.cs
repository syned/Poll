using System.Collections.Generic;

namespace PollProject.Domain
{
    public class SelectionQuestion : Question
    {
        public virtual ICollection<Answer> Answers { get; set; }
    }
}