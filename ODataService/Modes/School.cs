using System.Collections.Generic;

namespace ODataService.Modes
{
	public class School
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public virtual List<Student> Students { get; set; }
	}
}
