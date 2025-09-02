namespace LINQ.CheckingContents
{
	public class AggregateFunctions : QueryRunner
	{
		public override void Run()
		{
			//MinimumValue();
			//MinimumItem();
			//MaximumValue();
			MaximumItem();
		}

		/// <summary>
		/// Get the minimum value for a certain expression
		/// </summary>
		void MinimumValue()
		{
			var sourceMovies = Repository.GetAllMovies();

			var firstReleaseDate = sourceMovies
								   .Min(movie => movie.ReleaseDate);

			Console.WriteLine(firstReleaseDate);
		}

		/// <summary>
		/// Get the item with the minimum value for a certain expression
		/// </summary>
		void MinimumItem()
		{
			var sourceMovies = Repository.GetAllMovies();

			var firstMovie = sourceMovies
							 .MinBy(movie => movie.ReleaseDate);

			Console.WriteLine(firstMovie);
		}

		/// <summary>
		/// Get the maximum value for a certain expression
		/// </summary>
		void MaximumValue()
		{
			var sourceMovies = Repository.GetAllMovies();

			var lastReleaseDate = sourceMovies
								  .Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
								  .Max(movie => movie.ReleaseDate);

			Console.WriteLine(lastReleaseDate);
		}

		/// <summary>
		/// Get the item with the maximum value for a certain expression
		/// </summary>
		void MaximumItem()
		{
			var sourceMovies = Repository.GetAllMovies();

			var lastMovie = sourceMovies
							.Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
							.MaxBy(movie => movie.ReleaseDate);

			Console.WriteLine(lastMovie);
		}
	}
}