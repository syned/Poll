using System.Collections.Generic;

namespace PollProject.Domain
{
    public class Poll : Entity
    {
        public string Title { get; set; }

        public virtual IList<Question> Questions { get; set; }
    }
}
