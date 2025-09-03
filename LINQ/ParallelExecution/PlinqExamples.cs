namespace LINQ.ParallelExecution
{
	public class PlinqExamples : QueryRunner
	{
		public override void Run()
		{
			ASlowQueryAppeared();
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
	}
}