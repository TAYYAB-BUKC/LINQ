using LINQ.Data.Models;

namespace LINQ.OutputFromQueries
{
	public class GetAllResults : QueryRunner
	{
		public override void Run()
		{
			LoopOverResults();
		}

		/// <summary>
		/// Just iterate over an IEnumerable to get the results.
		/// </summary>
		private void LoopOverResults()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = sourceMovies
				.Where(IsSpiderManMovie);

			foreach (var movie in query)
			{
				Console.WriteLine(movie);
			}
		}

		/// <summary>
		/// Input interface = output interface.
		/// So this query on an IQueryable is an IQueryable itself 
		/// </summary>
		private void LoopOverQueryableResults()
		{
			var sourceMovies = Repository.GetAllMoviesAsQueryable();

			var query = sourceMovies
				.Where(movie => IsSpiderManMovie(movie));

			foreach (var movie in query)
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