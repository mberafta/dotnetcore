﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MB_TEST.Models;

namespace MB_TEST.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int param = 0)
        {
            ViewBag.testValue = "Vikoroff application";
            var testObj = new TestModel("Vikoroff");
            return View(testObj);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class TestModel
    {
        public string Name { get; set; }

        public TestModel() { }

        public TestModel(string newName)
        {
            this.Name = newName;
        }
    }
}
