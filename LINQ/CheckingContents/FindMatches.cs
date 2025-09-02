namespace LINQ.CheckingContents
{
	public class FindMatches : QueryRunner
	{
		public override void Run()
		{
			CheckIfSingleItemIsPresentOfMatchingCriteria();
		}

		/// <summary>
		/// Check if there is at least one item that matches the criteria
		/// </summary>
		void CheckIfSingleItemIsPresentOfMatchingCriteria()
		{
			var sourceMovies = Repository.GetAllMovies();

			var isBlackWindowPresent = sourceMovies
									   .Any(movie => movie.Name.StartsWith("Iron"));

			Console.WriteLine(isBlackWindowPresent);
		}
	}
}