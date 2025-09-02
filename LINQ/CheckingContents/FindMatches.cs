namespace LINQ.CheckingContents
{
	public class FindMatches : QueryRunner
	{
		public override void Run()
		{
			//CheckIfSingleItemIsPresentOfMatchingCriteria();
			CheckIfAllItemsArePresentOfMatchingCriteria();
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

		/// <summary>
		/// Check if all items match the criteria
		/// </summary>
		void CheckIfAllItemsArePresentOfMatchingCriteria()
		{
			var ironManMovies = Repository.GetAllMovies()
								.Where(movie => movie.Name.StartsWith("Iron Man"));

			var areAllIronManEarlyPhases = ironManMovies
										   .All(movie => movie.Phase <= 2);

			Console.WriteLine(areAllIronManEarlyPhases);
		}
	}
}