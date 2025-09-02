namespace LINQ.CheckingContents
{
	public class CompareSequences : QueryRunner
	{
		public override void Run()
		{
			CheckIfSequencesMatch();
		}

		/// <summary>
		/// Check if the items in 2 sequences, one-by-one, are equal.
		/// </summary>
		void CheckIfSequencesMatch()
		{
			var phaseOneMovies = Repository.GetPhase1Movies();

			var firstSixMovies = Repository.GetAllMovies().Take(6);

			var areMoviesEqual = phaseOneMovies.SequenceEqual(firstSixMovies);

			Console.WriteLine(areMoviesEqual);
		}
	}
}