namespace LINQ.Introduction.Models
{
	public class Movie
	{
		public string Name { get; set; }
		public Guid MovieId { get; set; }
		public DateOnly ReleaseDate { get; set; }
	}
}