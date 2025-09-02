namespace LINQ.PartialResults
{
	public class SkipAndTake : QueryRunner
	{
		public override void Run()
		{
			//TakeFirstItems_Q();
			TakeLastItems_Q();
		}

		/// <summary>
		/// Take the first X items from a source
		/// </summary>
		void TakeFirstItems_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
						where movie.Producers.Count > 1
						select movie;

			var result = query.Take(5);

			PrintAll(result);
		}

		/// <summary>
		/// Take the last X items from a source
		/// </summary>
		void TakeLastItems_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
						where movie.Producers.Count > 1
						select movie;

			var result = query.TakeLast(5);

			PrintAll(result);
		}
	}
}