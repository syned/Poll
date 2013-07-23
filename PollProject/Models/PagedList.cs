using PollProject.Models.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PollProject.Models
{
    public class PagedList<T>
    {
        private int _count;
        private int _pageCount;
        private List<PageNumberViewModel> _pageNumbers;


        public PagedList(IEnumerable<T> items, int pageSize = 10, int currentPage = 1)
        {
            _count = items.Count();
            var skipCount = (currentPage - 1) * pageSize;

            _pageCount = _count / pageSize;

            if (_count % pageSize > 0)
                _pageCount++;

            if (_pageCount <= 6)
            {
                _pageNumbers = Enumerable.Range(1, _pageCount)
                    .Select(x => new PageNumberViewModel
                    {
                        Number = x,
                        Title = x.ToString(),
                        Active = x == currentPage ? "active" : null
                    }).ToList();
            }
            else
            {
                if (currentPage < 5)
                {
                    _pageNumbers = Enumerable.Range(1, 5)
                        .Select(x => new PageNumberViewModel
                        {
                            Number = x,
                            Title = x.ToString(),
                            Active = x == currentPage ? "active" : null
                        }).ToList();

                    _pageNumbers.Add(new PageNumberViewModel
                    {
                        Title = "...",
                        Disabled = "disabled"
                    });

                    _pageNumbers.Add(new PageNumberViewModel
                        {
                            Title = _pageCount.ToString(),
                            Number = _pageCount
                        });
                }
                else if (currentPage >= 5 && currentPage <= _pageCount - 4)
                {
                    _pageNumbers = Enumerable.Range(4, 5).Select(x => new PageNumberViewModel
                    {
                        Number = x,
                        Title = x.ToString(),
                        Active = x == currentPage ? "active" : null
                    }).ToList();

                    _pageNumbers.Insert(0, new PageNumberViewModel
                    {
                        Title = "...",
                        Disabled = "disabled"
                    });

                    _pageNumbers.Insert(0, new PageNumberViewModel
                    {
                        Title = "1",
                        Number = 1
                    });

                    _pageNumbers.Add(new PageNumberViewModel
                    {
                        Title = "...",
                        Disabled = "disabled"
                    });

                    _pageNumbers.Add(new PageNumberViewModel
                    {
                        Title = _pageCount.ToString(),
                        Number = _pageCount
                    });
                }
                else
                {
                    _pageNumbers = Enumerable.Range(_pageCount-4, 5)
                        .Select(x => new PageNumberViewModel
                        {
                            Number = x,
                            Title = x.ToString(),
                            Active = x == currentPage ? "active" : null
                        }).ToList();

                    _pageNumbers.Insert(0, new PageNumberViewModel
                    {
                        Title = "...",
                        Disabled = "disabled"
                    });

                    _pageNumbers.Insert(0, new PageNumberViewModel
                        {
                            Title = "1",
                            Number = 1
                        });
                }
            }
        }

        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public IEnumerable<T> PageItems { get; set; }

        public IEnumerable<PageNumberViewModel> PageNumbers { get { return _pageNumbers; } }
    }
}