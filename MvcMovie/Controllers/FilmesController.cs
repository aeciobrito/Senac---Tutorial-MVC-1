using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class FilmesController : Controller
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Filme.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var filme = _context.Filme
                .FirstOrDefault(m => m.Id == id);

            if (filme == null)
                return NotFound();

            return View(filme);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Titulo,DataLancamento,Genero,Preco")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(filme);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var filme = _context.Filme.Find(id);

            if (filme == null)
                return NotFound();

            return View(filme);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Titulo,DataLancamento,Genero,Preco")] Filme filme)
        {
            if (id != filme.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Filme.Any(e => e.Id == filme.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filme);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var filme = _context.Filme
                .FirstOrDefault(m => m.Id == id);

            if (filme == null)
                return NotFound();

            return View(filme);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var filme = _context.Filme.Find(id);
            _context.Filme.Remove(filme);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
