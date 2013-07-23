using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollProject.Models.Pagination
{
    public class IndexViewModel
    {
        public int CurrentPage { get; set; }

        public IEnumerable<PageNumberViewModel> PageNumbers { get; set; }
    }
}