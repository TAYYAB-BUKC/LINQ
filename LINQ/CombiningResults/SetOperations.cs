using LINQ.Data.Models;

namespace LINQ.CombiningResults
{
	public class SetOperations : QueryRunner
	{
		public override void Run()
		{
			//UnionSequences();
			UnionSequencesWithOverlap();
		}

		/// <summary>
		/// Take all elements that appear in either source.
		/// </summary>
		void UnionSequences()
		{
			var infinitySaga = Repository.GetInfinitySagaMovies();
			var multiverseSaga = Repository.GetMultiverseSagaMovies();

			var allMovies = infinitySaga.Union(multiverseSaga);

			PrintAll(allMovies);
		}

		/// <summary>
		/// Take all elements that appear in either source.
		/// </summary>
		void UnionSequencesWithOverlap()
		{
			var infinitySaga = Repository.GetInfinitySagaMovies();
			var phase3Movies = Repository.GetPhase3Movies();

			var movies = infinitySaga.Union(phase3Movies);

			PrintAll(movies);
		}
	}
}