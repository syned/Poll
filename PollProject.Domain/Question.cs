using System.Collections.Generic;

namespace PollProject.Domain
{
    public abstract class Question : Entity
    {
        public string Title { get; set; }

        public QuestionType Type { get; protected set; }
    }
}
