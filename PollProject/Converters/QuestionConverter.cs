using System;
using System.Linq;
using PollProject.DAL;
using PollProject.Domain;
using PollProject.Models;

namespace PollProject.Converters
{
    public class QuestionConverter : IQuestionConverter
    {
        private readonly IRepository _repository;

        public QuestionConverter(IRepository repository)
        {
            _repository = repository;
        }

        public void Convert(QuestionViewModel questionViewModel, Question question)
        {
            var questionConverter = GetQuestionConverter(questionViewModel);

            questionConverter.Convert(questionViewModel, question);
        }

        private IQuestionConverter GetQuestionConverter(QuestionViewModel questionViewModel)
        {
            if (questionViewModel.GetType() == typeof(TextQuestionViewModel))
                return new TextQuestionConverter();
            if (questionViewModel.GetType() == typeof(SingleSelectionQuestionViewModel))
                return new SingleSelectionConverter(this);
            if (questionViewModel.GetType() == typeof(MultiSelectionQuestionViewModel))
                return new MultiSelectionConverter(this);

            throw new ArgumentOutOfRangeException("questionViewModel");
        }

        private class TextQuestionConverter : IQuestionConverter
        {
            public void Convert(QuestionViewModel questionViewModel, Question question)
            {
                var textQuestionViewModel = (TextQuestionViewModel)questionViewModel;
                var textQuestion = (TextQuestion)question;

                textQuestion.AnswerText = textQuestionViewModel.AnswerText;
            }
        }

        private class SingleSelectionConverter : IQuestionConverter
        {
            private readonly QuestionConverter _outer;

            public SingleSelectionConverter(QuestionConverter outer)
            {
                _outer = outer;
            }

            public void Convert(QuestionViewModel questionViewModel, Question question)
            {
                var singleSelectionQuestionViewModel = (SingleSelectionQuestionViewModel)questionViewModel;
                var singleSelectionQuestion = (SingleSelectionQuestion) question;

                var selectedAnswerId = singleSelectionQuestionViewModel.SelectedAnswerId;
                if (selectedAnswerId != null)
                    singleSelectionQuestion.SelectedAnswer = _outer._repository.SelectById<Answer>(selectedAnswerId.Value);
            }
        }

        private class MultiSelectionConverter : IQuestionConverter
        {
            private readonly QuestionConverter _outer;

            public MultiSelectionConverter(QuestionConverter questionConverter)
            {
                _outer = questionConverter;
            }

            public void Convert(QuestionViewModel questionViewModel, Question question)
            {
                var multiSelectionQuestionViewModel = (MultiSelectionQuestionViewModel)questionViewModel;
                var multiSelectionQuestion = (MultiSelectionQuestion)question;

                var selectedAsnwersList = multiSelectionQuestionViewModel.SelectedAnswers
                            .Where(x => x.IsChecked)
                            .Select(x => x.Id)
                            .ToList();

                var selectedAnswers = _outer._repository.Select<Answer>()
                    .Where(x => selectedAsnwersList.Contains(x.Id))
                    .ToList();

                multiSelectionQuestion.SelectedAnswers.Clear();

                foreach (var selectedAnswer in selectedAnswers)
                {
                    multiSelectionQuestion.SelectedAnswers.Add(selectedAnswer);
                }
            }
        }
    }
}