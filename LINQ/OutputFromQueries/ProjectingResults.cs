namespace LINQ.OutputFromQueries
{
    public class ProjectingResults : QueryRunner
    {
        public override void Run()
        {
            //SelectSingleProperty_Q();
            //SelectSingleProperty_F();
            //SelectAnonymousType_Q();
			SelectAnonymousType_F();
		}

        /// <summary>
        /// Getting a single property from the model class, query syntax
        /// </summary>
        void SelectSingleProperty_Q()
        {
            var sourceMovies = Repository.GetAllMovies();

            var query =
                from movie in sourceMovies
                where movie.Name.StartsWith("Iron Man")
                select movie.Name;

            PrintAll(query);
        }

        /// <summary>
        /// Getting a single property from the model class, fluent syntax
        /// </summary>
        void SelectSingleProperty_F()
        {
            var sourceMovies = Repository.GetAllMovies();

            var query = sourceMovies
                .Where(movie => movie.Name.StartsWith("Iron Man"))
                .Select(movie => movie.Name);

            PrintAll(query);
        }

		/// <summary>
		/// Getting results as an anonymous type, query syntax
		/// </summary>
		void SelectAnonymousType_Q()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = from movie in sourceMovies
				        where movie.Name.StartsWith("Iron Man")
				        select new { movie.Name, movie.ReleaseDate.Year };

            PrintAll(query);
		}

		/// <summary>
		/// Getting results as an anonymous type, fluent syntax
		/// </summary>
		void SelectAnonymousType_F()
		{
			var sourceMovies = Repository.GetAllMovies();

			var query = sourceMovies
				        .Where(movie => movie.Name.StartsWith("Iron Man"))
				        .Select(movie => new { movie.Name, movie.ReleaseDate.Year });

			PrintAll(query);
		}
	}
}