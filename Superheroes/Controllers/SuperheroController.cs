using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Superhero
        public ActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();
            return View(superheroes);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            // TODO: Add insert logic here
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            // TODO: Add update logic here
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(superhero).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(superhero);
            }
        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            // TODO: Add delete logic here
            {
                var superheroes = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
                _context.Superheroes.Remove(superheroes);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}