﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "MS Dhoni" };

            var customers = new List<Customer>
            {
                new Customer {Name="Customer 1" },
                new Customer {Name="Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
              return View(viewModel);
            //return Content("Hello Reg");
            // return HttpNotFound();
            //return new EmptyResult();
           // return RedirectToAction("Index", "Home",new { page =1, sortby = "name"});
        }
        public ActionResult Edit(int id)
        {
            return Content("Id ="  +id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortby={1}", pageIndex, sortBy));
            
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
    }
}