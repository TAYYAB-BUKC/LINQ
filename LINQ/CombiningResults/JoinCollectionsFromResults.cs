namespace LINQ.CombiningResults
{
	public class JoinCollectionsFromResults : QueryRunner
	{
		public override void Run()
		{
			//SelectManyFromProperty_Q();
			SelectManyFromProperty_F();
		}

		/// <summary>
		/// Get all of the items from a collection property of the model
		/// and append them into a single collection, query syntax.
		/// </summary>
		void SelectManyFromProperty_Q()
		{
			var allMovies = Repository.GetAllMovies();

			var allUniqueDirectors = (from movie in allMovies
									  from director in movie.Directors
									  orderby director.ToString()
									  select director).Distinct();

			PrintAll(allUniqueDirectors);
		}

		/// <summary>
		/// Get all of the items from a collection property of the model
		/// and append them into a single collection, fluent syntax.
		/// </summary>
		void SelectManyFromProperty_F()
		{
			var allMovies = Repository.GetAllMovies();

			var allUniqueDirectors = allMovies
									 .SelectMany(movie => movie.Directors)
									 .OrderBy(director => director.ToString())
									 .Distinct();

			PrintAll(allUniqueDirectors);
		}
	}
}