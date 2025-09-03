namespace LINQ.HowLINQWorks
{
	public class EnumerableExample : QueryRunner
	{
		public override void Run()
		{
			HomeLinqMethods();
		}

		void HomeLinqMethods()
		{
			var allMovies = Repository.GetAllMovies();

			var result = allMovies.CustomWhere(movie => movie.Phase == 4).CustomFirstOrDefault();

			Console.WriteLine(result);
		}
	}

	public static class CustomLinqMethods
	{
		public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> source, Predicate<T> condition)
		{
			foreach (var sourceItem in source)
			{
				if (condition(sourceItem))
					yield return sourceItem;
			}
		}

		public static T? CustomFirstOrDefault<T>(this IEnumerable<T> source)
		{
			foreach (var sourceItem in source)
			{
				return sourceItem;
			}

			return default;
		}
	}
}
