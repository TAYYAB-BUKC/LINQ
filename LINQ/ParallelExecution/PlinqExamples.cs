using System.Diagnostics;

namespace LINQ.ParallelExecution
{
	public class PlinqExamples : QueryRunner
	{
		public override void Run()
		{
			//ASlowQueryAppeared();
			//RunInParallel();
			//RunInParallelButPreserveOrdering();
			//LimitParallelization();
			UseForAll();
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

		/// <summary>
		/// If we need to keep the order of the source intact
		/// </summary>
		void RunInParallelButPreserveOrdering()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var allMovies = Repository.GetAllMovies();

			var query = allMovies
						.AsParallel()
						.AsOrdered()
						.Where(movie => SlowCondition(movie.Phase < 5));

			PrintAll(query);

			Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
		}

		/// <summary>
		/// Sometimes we want to limit the number of threads.
		/// </summary>
		void LimitParallelization()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var allMovies = Repository.GetAllMovies();

			var query = allMovies
						.AsParallel()
						.AsOrdered()
						.WithDegreeOfParallelism(10) // Number of concurrent tasks
						.Where(movie => SlowCondition(movie.Phase < 5));

			PrintAll(query);

			Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
		}
		
		/// <summary>
		/// Instead of iterating, the pipeline can remain parallel.
		/// </summary>
		void UseForAll()
		{
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			var allMovies = Repository.GetAllMovies();

			allMovies
				.AsParallel()
				//.AsOrdered()
				.WithDegreeOfParallelism(10)
				.Where(movie => SlowCondition(movie.Phase < 5))
				.ForAll(movie => Console.WriteLine(movie));

			Console.WriteLine($"Execution time: {stopWatch.ElapsedMilliseconds} ms");
		}
	}
}