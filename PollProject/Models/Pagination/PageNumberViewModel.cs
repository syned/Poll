using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollProject.Models.Pagination
{
    public class PageNumberViewModel
    {
        public string Title { get; set; }

        public int Number { get; set; }

        public string Disabled { get; set; }

        public string Active { get; set; }
    }
}