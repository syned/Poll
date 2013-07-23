using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using PollProject.Converters;
using PollProject.DAL;
using PollProject.DAL.EF;
using PollProject.Domain;
using PollProject.Models;

namespace PollProject.Controllers
{
    public class PollController : Controller
    {
        private readonly IRepository _repository;
        private readonly PollConverter _pollConverter;

        public PollController()
        {
            // without DI
            _repository = new CodeFirstRepository();
            _pollConverter = new PollConverter(_repository);
        }

        public ActionResult Take(int id)
        {
            var poll = _repository.SelectById<Poll>(id);

            var viewModel = _pollConverter.Convert(poll);

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var viewModel = new PollListViewModel
                                {
                                    Polls = _repository.Select<Poll>()
                                        .Select(x => new PollViewModel
                                        {
                                            Id = x.Id,
                                            Title = x.Title
                                        }).ToList()
                                };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Take(PollViewModel pollVm)
        {
            if (ModelState.IsValid)
            {
                var poll = _repository.SelectById<Poll>(pollVm.Id);

                _pollConverter.Convert(poll, pollVm);

                _repository.SaveChanges();

                return View("Complete", pollVm);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Summary(PollViewModel poll)
        {
            return PartialView(poll);
        }
    }
}