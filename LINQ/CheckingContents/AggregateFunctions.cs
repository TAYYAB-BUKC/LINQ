namespace LINQ.CheckingContents
{
	public class AggregateFunctions : QueryRunner
	{
		public override void Run()
		{
			//MinimumValue();
			MinimumItem();
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
	}
}