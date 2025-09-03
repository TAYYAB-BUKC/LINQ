namespace LINQ.CombiningResults
{
	public class JoiningData : QueryRunner
	{
		public override void Run()
		{
			//InnerJoin_Q();
			//InnerJoin_F();
			//InnerJoinMultiField_Q();
			//InnerJoinMultiField_F();
			//GroupJoin_Q();
			GroupJoin_F();
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

		/// <summary>
		/// Inner join data on multiple properties, query syntax
		/// </summary>
		void InnerJoinMultiField_Q()
		{
			var movieDirectors = Repository.GetAllMovies().SelectMany(
									movie => movie.Directors,
									(movie, director) => (Movie: movie, Director: director)
								);

			var directors = Repository.GetSomeDirectors();

			var result = from movieDirector in movieDirectors
						 join director in directors
						 on new { movieDirector.Director.FirstName, movieDirector.Director.LastName }
						 equals new { director.FirstName, director.LastName }
						 select (Movie: movieDirector.Movie.Name, Director: director.FullName);

			PrintAll(result);
		}

		/// <summary>
		/// Inner join data on multiple properties, fluent syntax
		/// </summary>
		void InnerJoinMultiField_F()
		{
			var movieDirectors = Repository.GetAllMovies().SelectMany(
									movie => movie.Directors,
									(movie, director) => (Movie: movie, Director: director)
								);

			var directors = Repository.GetSomeDirectors();

			var result = movieDirectors.Join(
							directors,
							movieDirector => new { movieDirector.Director.FirstName, movieDirector.Director.LastName },
							director => new { director.FirstName, director.LastName },
							(movieDirector, director) => (Movie: movieDirector.Movie.Name, Director: director.FullName)
						);

			PrintAll(result);
		}

		/// <summary>
		/// Group join data, query syntax
		/// </summary>
		void GroupJoin_Q()
		{
			var allMovies = Repository.GetAllMovies();
			var castMembers = Repository.GetSomeCastMembers();

			var allCast = from movie in allMovies
						  join castMember in castMembers
						  on movie.Name equals castMember.Movie 
						  into cast
						  //where cast.Any()
						  select (Movie: movie.Name, Actors: cast);

			foreach (var movieWithCast in allCast)
			{
				Console.WriteLine($"{movieWithCast.Movie} ({movieWithCast.Actors.Count()})");
			}
		}

		/// <summary>
		/// Group join data, fluent syntax
		/// </summary>
		void GroupJoin_F()
		{
			var allMovies = Repository.GetAllMovies();
			var castMembers = Repository.GetSomeCastMembers();

			var allCast = allMovies.GroupJoin(
							castMembers,
							movie => movie.Name,
							castMember => castMember.Movie,
							(movie, cast) => (Movie: movie.Name, Actors: cast)
						  );
						  //).Where(movie => movie.Actors.Any());

			foreach (var movieWithCast in allCast)
			{
				Console.WriteLine($"{movieWithCast.Movie} ({movieWithCast.Actors.Count()})");
			}
		}
	}
}