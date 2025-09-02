namespace LINQ.PartialResults
{
	public class SkipAndTake : QueryRunner
	{
		public override void Run()
		{
			//TakeFirstItems_Q();
			//TakeLastItems_Q();
			//TakeMatchingItems_Q();
			//SkipFirstItems_Q();
			//SkipLastItems_Q();
			SkipMatchingItems_Q();
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

		/// <summary>
		/// Take items from a source while a condition is true
		/// </summary>
		void TakeMatchingItems_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
						where movie.Producers.Count > 1
						select movie;

			var result = query.TakeWhile(movie => movie.Phase <= 3);

			PrintAll(result);
		}

		/// <summary>
		/// Skip the first X items from a source
		/// </summary>
		void SkipFirstItems_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
						where movie.Producers.Count > 1
						select movie;

			var result = query.Skip(5);

			PrintAll(result);
		}

		/// <summary>
		/// Skip the last X items from a source
		/// </summary>
		void SkipLastItems_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
						where movie.Producers.Count > 1
						select movie;

			var result = query.SkipLast(5);

			PrintAll(result);
		}

		/// <summary>
		/// Skip items from a source while a condition is true
		/// </summary>
		void SkipMatchingItems_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
						where movie.Producers.Count > 1
						select movie;

			var result = query.SkipWhile(movie => movie.Phase <= 3);

			PrintAll(result);
		}
	}
}