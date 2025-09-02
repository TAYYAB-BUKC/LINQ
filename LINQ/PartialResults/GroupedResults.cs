namespace LINQ.PartialResults
{
	public class GroupedResults : QueryRunner
	{
		public override void Run()
		{
			GroupedResults_Q();
		}

		/// <summary>
		/// Grouped query results, query syntax
		/// </summary>
		private void GroupedResults_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
						where movie.Producers.Count > 1
						group movie by movie.Phase into phase
						where phase.Key > 2
						select phase;

			foreach (var phase in query)
			{
				Console.WriteLine($"PHASE {phase.Key}:");
				foreach (var movie in phase)
				{
					Console.WriteLine(movie);
				}
			}
		}
	}
}