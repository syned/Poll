using NUnit.Framework;
using PollProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using PollProject.Models.Pagination;

namespace PollProject.Tests
{
    [TestFixture]
    public class PaginationTests
    {
        [Test]
        public void given_page_count_1_should_return_1_page_active()
        {
            var items = new[] { 1 };
            var expected = items.Select(x => new PageNumberViewModel
            {
                Number = 1,
                Title = "1",
                Active = "active"
            });

            var sut = new PagedList<int>(items);
            sut.PageNumbers.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void given_6_pages_should_return_6_pages_and_current_page_is_active()
        {
            var items = Enumerable.Range(1, 51);
            var currentPage = 2;

            var pages = new [] { 1, 2, 3, 4, 5, 6 };

            var expected = pages.Select(x => new PageNumberViewModel
                {
                    Number = x,
                    Title = x.ToString()
                }).ToArray();

            expected[1].Active = "active";

            var sut = new PagedList<int>(items, currentPage: currentPage);

            sut.PageNumbers.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void given_10_pages_with_first_current_page_should_return_5_pages_then_dots_and_10_page()
        {
            var items = Enumerable.Range(1, 100);
            var currentPage = 1;

            var expected = Enumerable.Range(1, 5).Select(x => new PageNumberViewModel
                {
                    Number = x,
                    Title = x.ToString()
                }).ToList();

            expected.Add(new PageNumberViewModel
                {
                    Title = "...",
                    Disabled = "disabled"
                });

            expected.Add(new PageNumberViewModel
                {
                    Title = "10",
                    Number = 10                    
                });

            expected[currentPage-1].Active = "active";

            var sut = new PagedList<int>(items, currentPage: currentPage);

            sut.PageNumbers.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void given_10_pages_with_last_current_page_should_return_1_page_then_dots_and_5_last_pages()
        {
            var items = Enumerable.Range(1, 100);
            var currentPage = 10;

            var expected = Enumerable.Range(6, 5).Select(x => new PageNumberViewModel
            {
                Number = x,
                Title = x.ToString()
            }).ToList();

            expected.Insert(0, new PageNumberViewModel
            {
                Title = "...",
                Disabled = "disabled"
            });

            expected.Insert(0, new PageNumberViewModel
            {
                Title = "1",
                Number = 1
            });

            expected[expected.Count-1].Active = "active";

            var sut = new PagedList<int>(items, currentPage: currentPage);

            sut.PageNumbers.ShouldBeEquivalentTo(expected);
        }

        [Test]
        public void given_current_page_6_and_10_pages_should_return_1_dots_4_5_6_7_8_dots_10()
        {
            var items = Enumerable.Range(1, 100);
            var currentPage = 6;

            var expected = Enumerable.Range(4, 5).Select(x => new PageNumberViewModel
            {
                Number = x,
                Title = x.ToString()
            }).ToList();

            expected.Insert(0, new PageNumberViewModel
            {
                Title = "...",
                Disabled = "disabled"
            });

            expected.Insert(0, new PageNumberViewModel
            {
                Title = "1",
                Number = 1
            });

            expected.Add(new PageNumberViewModel
            {
                Title = "...",
                Disabled = "disabled"
            });

            expected.Add(new PageNumberViewModel
            {
                Title = "10",
                Number = 10
            });

            expected[4].Active = "active";

            var sut = new PagedList<int>(items, currentPage: currentPage);

            sut.PageNumbers.ShouldBeEquivalentTo(expected);
        }
    }
}