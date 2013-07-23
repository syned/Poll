using System.Web.Mvc;

namespace PollProject.Models
{
    public class AnswerViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}