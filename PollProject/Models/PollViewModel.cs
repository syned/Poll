using System.Collections.Generic;
using System.Web.Mvc;

namespace PollProject.Models
{
    public class PollViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public IList<QuestionViewModel> Questions { get; set; }
    }
}