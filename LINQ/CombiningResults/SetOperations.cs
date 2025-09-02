using LINQ.Data.Models;

namespace LINQ.CombiningResults
{
	public class SetOperations : QueryRunner
	{
		public override void Run()
		{
			//UnionSequences();
			//UnionSequencesWithOverlap();
			//IntersectSequences();
			ExceptSequences();
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

		/// <summary>
		/// Take all elements that appear in both sources.
		/// </summary>
		void IntersectSequences()
		{
			var infinitySaga = Repository.GetInfinitySagaMovies();
			var phase3Movies = Repository.GetPhase3Movies();

			var movies = infinitySaga.Intersect(phase3Movies);

			PrintAll(movies);
		}

		/// <summary>
		/// Take all elements that appear in the first sequence, but not the second.
		/// </summary>
		void ExceptSequences()
		{
			var infinitySaga = Repository.GetInfinitySagaMovies();
			var phase3Movies = Repository.GetPhase3Movies();

			var movies = infinitySaga.Except(phase3Movies);
			//var movies = phase3Movies.Except(infinitySaga);

			PrintAll(movies);
		}
	}
}