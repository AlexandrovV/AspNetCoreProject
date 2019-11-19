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
    public class ReviewsController : Controller
    {
        private readonly ReviewService _reviewService;
        private readonly ReviewerService _reviewerService;
        private readonly MovieService _movieService;

        public ReviewsController(ReviewService reviewService, ReviewerService reviewerService, MovieService movieService)
        {
            _reviewService = reviewService;
            _reviewerService = reviewerService;
            _movieService = movieService;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            return View(await _reviewService.GetReviews());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = id.HasValue ? await _reviewService.GetReview(id.Value) : null;
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewData["MovieId"] = new SelectList(await _movieService.GetMovies(), "MovieId", "Name");
            ViewData["ReviewerId"] = new SelectList(await _reviewerService.GetReviewers(), "ReviewerId", "Name");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,Text,MovieId,ReviewerId")] Review review)
        {
            if (ModelState.IsValid)
            {
                _reviewService.AddAndSave(review);
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(await _movieService.GetMovies(), "MovieId", "Name", review.MovieId);
            ViewData["ReviewerId"] = new SelectList(await _reviewerService.GetReviewers(), "ReviewerId", "Name", review.ReviewerId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _reviewService.GetReview(id.Value);
            if (review == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(await _movieService.GetMovies(), "MovieId", "Name", review.MovieId);
            ViewData["ReviewerId"] = new SelectList(await _reviewerService.GetReviewers(), "ReviewerId", "Name", review.ReviewerId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,Text,MovieId,ReviewerId")] Review review)
        {
            if (id != review.ReviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _reviewService.UpdateAndSave(review);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_reviewService.ReviewExists(review.ReviewId))
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
            ViewData["MovieId"] = new SelectList(await _movieService.GetMovies(), "MovieId", "Name", review.MovieId);
            ViewData["ReviewerId"] = new SelectList(await _reviewerService.GetReviewers(), "ReviewerId", "Name", review.ReviewerId);
            return View(review);
        }

        // GET: Reviews/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = id.HasValue ? await _reviewService.GetReview(id.Value) : null;
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _reviewService.DeleteAndSave(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
