using System;
using System.Web.Mvc;
using PollProject.Domain;

namespace PollProject.Models
{
    public abstract class QuestionViewModel
    {
        protected QuestionViewModel() { }

        protected QuestionViewModel(Question question)
        {
            Id = question.Id;
            Title = question.Title;
            Type = question.GetType().Name;
        }

        public string Type { get; private set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Creates question view model based on question model
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public static QuestionViewModel Create(Question question)
        {
            var questionType = question.Type;

            if (questionType == QuestionType.Text)
                return new TextQuestionViewModel((TextQuestion)question);
            if (questionType == QuestionType.SingleSelection)
                return new SingleSelectionQuestionViewModel((SingleSelectionQuestion)question);
            if (questionType == QuestionType.MultiSelection)
                return new MultiSelectionQuestionViewModel((MultiSelectionQuestion)question);

            throw new ArgumentOutOfRangeException("question");
        }
    }
}
