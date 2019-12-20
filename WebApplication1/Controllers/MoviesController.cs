using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        
        private readonly MovieService _movieService;
        private readonly DirectorService _directorService;
        private readonly StudioService _studioService;


        public MoviesController(MovieService movieService, DirectorService directorService, StudioService studioService)
        {
            _movieService = movieService;
            _directorService = directorService;
            _studioService = studioService;
        }

        // GET: Movies
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index()
        {
            return View(await _movieService.GetMovies());
        }

        // GET: Movies/Details/5
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = id.HasValue ? await _movieService.GetMovie(id.Value) : null;
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewData["DirectorId"] = new SelectList(await _directorService.GetDirectors(), "DirectorId", "Name");
            ViewData["StudioId"] = new SelectList(await _studioService.GetStudios(), "StudioId", "Name");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Name,ShortDescription,StudioId,DirectorId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.AddAndSave(movie);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DirectorId"] = new SelectList(await _directorService.GetDirectors(), "DirectorId", "Name", movie.DirectorId);
            ViewData["StudioId"] = new SelectList(await _studioService.GetStudios(), "StudioId", "Name", movie.StudioId);
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = id.HasValue ? await _movieService.GetMovie(id.Value) : null;
            if (movie == null)
            {
                return NotFound();
            }
            ViewData["DirectorId"] = new SelectList(await _directorService.GetDirectors(), "DirectorId", "Name", movie.DirectorId);
            ViewData["StudioId"] = new SelectList(await _studioService.GetStudios(), "StudioId", "Name", movie.StudioId);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Name,ShortDescription,StudioId,DirectorId")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.UpdateAndSave(movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_movieService.MovieExists(movie.MovieId))
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
            ViewData["DirectorId"] = new SelectList(await _directorService.GetDirectors(), "DirectorId", "Name", movie.DirectorId);
            ViewData["StudioId"] = new SelectList(await _studioService.GetStudios(), "StudioId", "Name", movie.StudioId);
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = id.HasValue ? await _movieService.GetMovie(id.Value) : null;
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _movieService.DeleteAndSave(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
