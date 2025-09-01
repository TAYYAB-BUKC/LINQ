namespace LINQ.OutputFromQueries
{
	public class GetSingleItem : QueryRunner
	{
		public override void Run()
		{
			//GetFirstItem();
			//GetFirstItemWithPredicate();
			GetLastItemWithPredicate();
			GetFirstItemWithDefaultAndPredicate();
			ExpectSingleMatchWithPredicate();
		}

		/// <summary>
		/// Get the first matching item
		/// </summary>
		void GetFirstItem()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = sourceMovies
						.Where(movie => movie.Name.StartsWith("Spider-Man"));

			var result = query.First();

			Print(result);
		}

		/// <summary>
		/// You can add the Where to the Single item operations.
		/// </summary>
		void GetFirstItemWithPredicate()
		{
			var sourceMovies = Repository.GetAllMovies();

			var result = sourceMovies
						 .First(movie => movie.Name.StartsWith("Spider-Man"));

			Print(result);
		}

		/// <summary>
		/// You can also retrieve the last item
		/// This only iterates the entire collections depending on the source.
		/// Use the version with predicate to maximize efficiency!
		/// </summary>
		void GetLastItemWithPredicate()
		{
			var sourceMovies = Repository.GetAllMovies();

			var result = sourceMovies
						 .Last(movie => movie.Name.StartsWith("Spider-Man"));

			Print(result);
		}

		/// <summary>
		/// Adding 'OrDefault' prevents exceptions when no item is found.
		/// </summary>
		void GetFirstItemWithDefaultAndPredicate()
		{
			var sourceMovies = Repository.GetAllMovies();

			var result = sourceMovies
						 .FirstOrDefault(movie => movie.Name.StartsWith("Batman"));

			Print(result);
		}

		/// <summary>
		/// When you only expect a single match, you can throw if more are found.
		/// </summary>
		void ExpectSingleMatchWithPredicate()
		{
			var sourceMovies = Repository.GetAllMovies();

			var result = sourceMovies
						 .SingleOrDefault(movie => movie.Name.StartsWith("Spider-Man: Homecoming"));

			Print(result);
		}
	}
}