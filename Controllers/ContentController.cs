using identityStep.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using pandafilm.Models;

namespace pandafilm.Controllers
{
    public class ContentController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public ContentController(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Movie(int id)
        {
            var movie = await _db.movieModels.FirstOrDefaultAsync(x => x.Id == id);
            return View(movie);
        }

        [HttpGet]
        public IActionResult MovieSearch()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieSearch(SearchMovieViewModel searchMovieViewModel)
        {
            var searchResults = _db.movieModels.AsQueryable();

            if (searchMovieViewModel.Rating.HasValue)
            {
                if (searchMovieViewModel.Rating == 4.9)
                {
                    searchResults = searchResults.Where(movie => movie.Rating <= 5);
                } else
                {
                    searchResults = searchResults.Where(movie => movie.Rating >= searchMovieViewModel.Rating);
                }
            }

            if (!string.IsNullOrEmpty(searchMovieViewModel.Genre))
            {
                searchResults = searchResults.Where(movie => movie.Genre.Contains(searchMovieViewModel.Genre));
            }

            if (searchMovieViewModel.Year.HasValue)
            {
                if (searchMovieViewModel.Year == 2019)
                {
                    searchResults = searchResults.Where(movie => movie.Year <= 2020 && movie.Year >= 2010);
                }
                else if (searchMovieViewModel.Year == 2009)
                {
                    searchResults = searchResults.Where(movie => movie.Year <= 2010 && movie.Year >= 2000);
                }
                else if (searchMovieViewModel.Year == 1999)
                {
                    searchResults = searchResults.Where(movie => movie.Year <= 2000 && movie.Year >= 1990);
                }
                else if (searchMovieViewModel.Year == 1989)
                {
                    searchResults = searchResults.Where(movie => movie.Year <= 1990 && movie.Year >= 1980);
                }
                else if (searchMovieViewModel.Year == 1979)
                {
                    searchResults = searchResults.Where(movie => movie.Year <= 1980);
                } else
                {
                    searchResults = searchResults.Where(movie => movie.Year == searchMovieViewModel.Year);
                }
            }

            if (!string.IsNullOrEmpty(searchMovieViewModel.Name))
            {
                searchResults = searchResults.Where(movie => movie.Name.Contains(searchMovieViewModel.Name));
            }

            List<MovieModel> movies = searchResults.ToList();

            return View("MovieSearch", movies);
        }

        [HttpGet]
        public async Task<IActionResult> AddToFav(int id)
        {
            if (!User.Identity.IsAuthenticated) // if user is not authenticated
            {
                return RedirectToAction("Index", "Account");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) // if user is null
            {
                return RedirectToAction("Error");
            }

            var movie = await _db.movieModels.FindAsync(id);
            if (movie == null) // if movie is null
            {
                return RedirectToAction("Error");
            }

            var isAlreadyFav = await _db.favMovies
                .AnyAsync(x => x.MovieId == id && x.UserId == user.Id);
            if (!isAlreadyFav) // if movie isnt in users favs
            {
                var favMovie = new FavMovieViewModel
                {
                    MovieId = id,
                    UserId = user.Id
                };

                _db.favMovies.Add(favMovie);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Movie", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromFav(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var favMovieToRemove = await _db.favMovies.FirstOrDefaultAsync(x => x.MovieId == id && x.UserId == user.Id);
            _db.favMovies.Remove(favMovieToRemove);
            await _db.SaveChangesAsync();
            return RedirectToAction("Favs","Account");
        }

        [HttpGet]
        public async Task<IActionResult> AddToWatchLater(int id)
        {
            if (!User.Identity.IsAuthenticated) // if user is not authenticated
            {
                return RedirectToAction("Index", "Account");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) // if user is null
            {
                return RedirectToAction("Error");
            }

            var movie = await _db.movieModels.FindAsync(id);
            if (movie == null) // if movie is null
            {
                return RedirectToAction("Error");
            }

            var isAlreadyWatchLater = await _db.watchLaterMovies
                .AnyAsync(x => x.MovieId == id && x.UserId == user.Id);
            if (!isAlreadyWatchLater) // if movie isnt in users favs
            {
                var watchLaterMovie = new WatchLaterMovieViewModel
                {
                    MovieId = id,
                    UserId = user.Id
                };

                _db.watchLaterMovies.Add(watchLaterMovie);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Movie", new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromWatchLater(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var watchLaterMovieToRemove = await _db.watchLaterMovies.FirstOrDefaultAsync(x => x.MovieId == id && x.UserId == user.Id);
            _db.watchLaterMovies.Remove(watchLaterMovieToRemove);
            await _db.SaveChangesAsync();
            return RedirectToAction("WatchLater", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> FindMovie(SearchMovieViewModel searchMovie)
        {
            var movie = await _db.movieModels.FirstOrDefaultAsync(x => x.Name.Contains(searchMovie.Name));
            return RedirectToAction("Movie", new { id = movie.Id});
        }

        public HttpRequest GetRequest()
        {
            return Request;
        }

        [HttpPost]
        public async Task<IActionResult> SaveTimeCode(string timeCode)
        {
            if (!User.Identity.IsAuthenticated) // if user is not authenticated
            {
                return RedirectToAction("Index", "Account");
            }

            var user = await _userManager.GetUserAsync(User);
            int movieId = Convert.ToInt32(HttpContext.GetRouteValue("id"));

            var isAlreadySaved = await _db.userHistory
                .AnyAsync(x => x.UserId == user.Id && x.MovieId == movieId);
            if (!isAlreadySaved)
            {
                var addToHistory = new MovieHistoryViewModel
                {
                    UserId = user.Id,
                    MovieId = movieId,
                    TimeCode = timeCode
                };

                _db.userHistory.Add(addToHistory);
                await _db.SaveChangesAsync();
            }
            return Json(new { success = true });
        }
    }
}