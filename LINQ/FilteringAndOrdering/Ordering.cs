namespace LINQ.FilteringAndOrdering
{
	public class Ordering : QueryRunner
	{
		public override void Run()
		{
			 SingleOrderBy_Q();
		}

		/// <summary>
		/// Single order by, query syntax
		/// </summary>
		private void SingleOrderBy_Q()
		{
			var sourceMovies = Repository.GetAllMovies();
		}

		/// <summary>
		/// Single order by (descending), query syntax
		/// </summary>
		private void SingleOrderByDescending_Q()
		{
			var sourceMovies = Repository.GetAllMovies();
		}

		/// <summary>
		/// Single order by, fluent syntax
		/// </summary>
		private void SingleOrderBy_F()
		{
			var sourceMovies = Repository.GetAllMovies();
		}

		/// <summary>
		/// Single order by (descending), fluent syntax
		/// </summary>
		private void SingleOrderByDescending_F()
		{
			var sourceMovies = Repository.GetAllMovies();
		}

		/// <summary>
		/// Multiple order by, query syntax
		/// </summary>
		private void MultipleOrderBy_Q()
		{
			var sourceMovies = Repository.GetAllMovies();
		}

		/// <summary>
		/// Multiple order by, fluent syntax
		/// </summary>
		private void MultipleOrderBy_F()
		{
			var sourceMovies = Repository.GetAllMovies();
		}
	}
}
