using Duende.IdentityServer.Extensions;
using EsseEuJaLi.Server.Data;
using EsseEuJaLi.Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EsseEuJaLi.Server.Controllers
{
	[Route("[controller]/[action]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly ILogger<BooksController> _logger;
		private readonly ApplicationDbContext _context;

		public BooksController(ILogger<BooksController> logger, ApplicationDbContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public IEnumerable<Book> Get()
		{
			return _context.Books.ToArray();
		}

		[HttpGet]
		public Book GetSingle(string id)
		{
			return _context.Books.First(x => x.Id == id);
		}

		[Authorize]
		[HttpGet]
		public bool WasRead(string id)
		{
			return _context.BooksRead.Where(e => e.UserId == GetUserId(User) && e.BookId == id).Any();
		}

		[Authorize]
		[HttpGet]
		public bool MarkAsRead(string id) 
		{
			try {
                var user = _context.Users.First(e => e.Id == GetUserId(User));
				var book = _context.Books.Find(id) ?? throw new NullReferenceException();
				_context.BooksRead.Add(new(user, book));
				_context.SaveChanges();
				return true;
			} catch (Exception e) {
				_logger.Log(LogLevel.Error, e.Message);
				return false;
			}

		}

		[Authorize]
		[HttpGet]
		public int GetPoints()
		{
            var user = _context.Users.Include(e => e.BooksRead).ThenInclude(e => e.Book).First(e => e.Id == GetUserId(User));
			return user.GetPoints();
        }
        [Authorize]
        [HttpGet]
        public string[] GetTrophies()
        {
            var user = _context.Users.Include(e => e.BooksRead).ThenInclude(e => e.Book).First(e => e.Id == GetUserId(User));
            return user.GetTrophies();
        }
        private static string GetUserId(ClaimsPrincipal user) => user.Claims.ToList().First(e => e.Type == ClaimTypes.NameIdentifier).Value;

    }
}
