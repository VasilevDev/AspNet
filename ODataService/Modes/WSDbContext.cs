using Microsoft.EntityFrameworkCore;

namespace ODataService.Modes
{
	public class WSDbContext : DbContext
	{
		public WSDbContext(DbContextOptions<WSDbContext> options) 
			: base(options)
		{

		}

		public DbSet<Student> Students { get; set; }
		public DbSet<School> Schools { get; set; }
	}
}
