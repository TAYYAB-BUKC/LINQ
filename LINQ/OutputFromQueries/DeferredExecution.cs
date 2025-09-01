using LINQ.Data.Models;

namespace LINQ.OutputFromQueries
{
	public class DeferredExecution : QueryRunner
	{
		public override void Run()
		{
			//SimpleQueryWithForeach();
			SimpleQueryWithToList();
		}

		/// <summary>
		/// A single query, triggered by iterating over the results
		/// </summary>
		private void SimpleQueryWithForeach()
		{
			var sourceMovies = Repository.GetAllMovies();

			// This defines the LINQ query
			var query =
				from movie in sourceMovies
				where IsSpiderManMovie(movie)
				select movie;

			// Triggering the iterator will start execution
			foreach (var movie in query)
			{
				Console.WriteLine(movie);
			}
		}

		/// <summary>
		/// A single query, triggered by materializing to a collection type.
		/// </summary>
		private void SimpleQueryWithToList()
		{
			var sourceMovies = Repository.GetAllMovies();

			// This defines the LINQ query
			var query =
				from movie in sourceMovies
				where IsSpiderManMovie(movie)
				select movie;

			// Materializing to a collection will execute the query
			var result = query.ToList();

			foreach (var movie in result)
			{
				Console.WriteLine(movie);
			}
		}

		private static bool IsSpiderManMovie(Movie movie)
		{
			return movie.Name.Contains("Spider-Man");
		}
	}
}