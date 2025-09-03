using System.Diagnostics;

namespace LINQ.ParallelExecution
{
	public class PlinqExamples : QueryRunner
	{
		public override void Run()
		{
			//ASlowQueryAppeared();
			RunInParallel();
		}

		void ASlowQueryAppeared()
		{
			var allMovies = Repository.GetAllMovies();

			var query = from movie in allMovies
						where SlowCondition(movie.Phase < 3)
						select movie;

			PrintAll(query);
		}

		private bool SlowCondition(bool inputCondition)
		{
			Thread.Sleep(1000);
			return inputCondition;
		}

		/// <summary>
		/// By running in parallel, we can speed up results.
		/// </summary>
		void RunInParallel()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var allMovies = Repository.GetAllMovies();

			var query = allMovies
						.AsParallel()
						.Where(movie => SlowCondition(movie.Phase < 5));

			PrintAll(query);

			Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
		}
	}
}