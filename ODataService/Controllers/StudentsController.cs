using System.Collections.Generic;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataService.Modes;

namespace ODataService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly WSDbContext _context;

		public StudentsController(WSDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		[EnableQuery()]
		public IEnumerable<Student> GetStudents()
		{
			return _context.Students;
		}
	}
}