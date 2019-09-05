namespace ODataService.Modes
{
	public class Student
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Age { get; set; }
		public string City { get; set; }

		public int SchoolId { get; set; }
		public virtual School School { get; set; }
	}
}
