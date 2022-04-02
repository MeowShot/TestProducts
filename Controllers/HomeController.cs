using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext db;
        public HomeController(ProductContext context)
        {
            db = context;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }



        [Authorize]
        [HttpGet]
        public IActionResult AddNew()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Product person = await db.Products.FirstOrDefaultAsync(p => p.ID == id);
                if (person != null)
                    return View(person);
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(Product person)
        {
            db.Products.Update(person);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
