namespace LINQ.CheckingContents
{
	public class AggregateFunctions : QueryRunner
	{
		public override void Run()
		{
			//MinimumValue();
			//MinimumItem();
			//MaximumValue();
			//MaximumItem();
			//AverageValue();
			//SumValue();
			CountItems();
		}

		/// <summary>
		/// Get the minimum value for a certain expression
		/// </summary>
		void MinimumValue()
		{
			var sourceMovies = Repository.GetAllMovies();

			var firstReleaseDate = sourceMovies
								   .Min(movie => movie.ReleaseDate);

			Console.WriteLine(firstReleaseDate);
		}

		/// <summary>
		/// Get the item with the minimum value for a certain expression
		/// </summary>
		void MinimumItem()
		{
			var sourceMovies = Repository.GetAllMovies();

			var firstMovie = sourceMovies
							 .MinBy(movie => movie.ReleaseDate);

			Console.WriteLine(firstMovie);
		}

		/// <summary>
		/// Get the maximum value for a certain expression
		/// </summary>
		void MaximumValue()
		{
			var sourceMovies = Repository.GetAllMovies();

			var lastReleaseDate = sourceMovies
								  .Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
								  .Max(movie => movie.ReleaseDate);

			Console.WriteLine(lastReleaseDate);
		}

		/// <summary>
		/// Get the item with the maximum value for a certain expression
		/// </summary>
		void MaximumItem()
		{
			var sourceMovies = Repository.GetAllMovies();

			var lastMovie = sourceMovies
							.Where(movie => movie.ReleaseDate < DateOnly.FromDateTime(DateTime.Now))
							.MaxBy(movie => movie.ReleaseDate);

			Console.WriteLine(lastMovie);
		}

		/// <summary>
		/// Get the average value for a certain expression
		/// </summary>
		void AverageValue()
		{
			var sourceMovies = Repository.GetAllMovies();

			var averageProducers = sourceMovies
								   .Average(movie => movie.Producers.Count);

			Console.WriteLine(averageProducers);
		}

		/// <summary>
		/// Get the added value for a certain expression
		/// </summary>
		void SumValue()
		{
			var sourceMovies = Repository.GetAllMovies();

			var totalProducers = sourceMovies
								 .Sum(movie => movie.Producers.Count);

			Console.WriteLine(totalProducers);
		}

		/// <summary>
		/// Count the number of items
		/// </summary>
		void CountItems()
		{
			var sourceMovies = Repository.GetAllMovies();

			var numberOfMovies = sourceMovies.Count();

			Console.WriteLine(numberOfMovies);
		}
	}
}