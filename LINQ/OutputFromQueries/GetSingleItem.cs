namespace LINQ.OutputFromQueries
{
	public class GetSingleItem : QueryRunner
	{
		public override void Run()
		{
			GetFirstItem();
			//GetFirstItemWithPredicate();
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
	}
}