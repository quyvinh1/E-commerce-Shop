﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAssignment.Models;

namespace WebAssignment.Controllers
{
    public class HomeController : Controller
    {
        PRN211_ProjectContext db = new PRN211_ProjectContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var listProduct = db.Products.ToList();
            return View(listProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
