namespace LINQ.CombiningResults
{
	public class JoiningData : QueryRunner
	{
		public override void Run()
		{
			//InnerJoin_Q();
			InnerJoin_F();
		}

		/// <summary>
		/// Inner join data, query syntax
		/// </summary>
		void InnerJoin_Q()
		{
			var allMovies = Repository.GetAllMovies();
			var castMembers = Repository.GetSomeCastMembers();

			var allCast = from movie in allMovies
						  join castMember in castMembers on movie.Name equals castMember.Movie
						  select (Movie: movie.Name, Released: movie.ReleaseDate, Actor: castMember.Actor);

			PrintAll(allCast);
		}

		/// <summary>
		/// Inner join data, fluent syntax
		/// </summary>
		void InnerJoin_F()
		{
			var allMovies = Repository.GetAllMovies();
			var castMembers = Repository.GetSomeCastMembers();

			var allCast = allMovies.Join(
								castMembers,
								movie => movie.Name,
								castMember => castMember.Movie,
								(movie, castMember) =>
								(Movie: movie.Name, Released: movie.ReleaseDate, Actor: castMember.Actor)
							);

			PrintAll(allCast);
		}
	}
}