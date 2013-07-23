using PollProject.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PollProject.Controllers
{
    public class PaginationController : Controller
    {
        //
        // GET: /Pagination/

        public ActionResult Index(int page = 1)
        {
            var pageCount = 100;

            var index = new IndexViewModel
            {
                CurrentPage = page,
                PageNumbers = new[]
                {
                    new PageNumberViewModel
                    {
                        Title = "1",
                        Number = 1
                    },
                    new PageNumberViewModel
                    {
                        Title = "...",
                        Disabled = "disabled"
                    },
                    new PageNumberViewModel
                    {
                        Title = (page - 1).ToString(),
                        Number = page - 1
                    },
                    new PageNumberViewModel
                    {
                        Title = (page).ToString(),
                        Number = page,
                        Active = "active"
                    },
                    new PageNumberViewModel
                    {
                        Title = (page + 1).ToString(),
                        Number = page + 1
                    },
                    new PageNumberViewModel
                    {
                        Title = "...",
                        Disabled = "disabled"
                    },
                    new PageNumberViewModel
                    {
                        Title = (pageCount).ToString(),
                        Number = pageCount
                    }
                }
            };

            return View(index);
        }

    }
}
