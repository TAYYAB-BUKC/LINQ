using LINQ.Data.Models;
using Microsoft.Data.SqlClient;
using System.Xml;

namespace LINQ.Introduction
{
	public class NonLinqCodeSamples
	{
		public void Run()
		{
			// Working with in-memory objects
			var objectsResult = new List<Movie>();

			var movieObjects = GetMovies();

			foreach (var movie in movieObjects)
			{
				if (movie.Name.Contains("Spider"))
				{
					objectsResult.Add(movie);
				}
			}


			// Working with SQL databases
			var sqlResult = new List<Movie>();

			var connection = new SqlConnection(GetConnectionString());
			connection.Open();

			var command = connection.CreateCommand();
			command.CommandText = """
                              SELECT Id, Name, ReleaseDate
                              FROM dbo.Movies
                              WHERE Name LIKE '%Spider%'
                              """;

			var reader = command.ExecuteReader();
			while (reader.Read())
			{
				sqlResult.Add(new Movie
				{
					MovieId = (Guid)reader["Id"],
					Name = (string)reader["Name"],
					ReleaseDate = (DateOnly)reader["ReleaseDate"]
				});
			}

			// Working with XML
			var xmlResult = new List<Movie>();

			var document = new XmlDocument();
			document.Load("movies.xml");

			var namespaceMgr = new XmlNamespaceManager(document.NameTable);
			namespaceMgr.AddNamespace("mcu", "urn:mcu-movie-schema");

			var movieNodes = document.DocumentElement!.SelectNodes(
				"descendant::mcu:movie[mcu:Name[contains(text(),'Spider')]]", namespaceMgr);
			foreach (XmlNode movieNode in movieNodes!)
			{
				xmlResult.Add(new Movie
				{
					MovieId = Guid.Parse(movieNode
						.SelectSingleNode("descendant::mcu:movie-id", namespaceMgr)!.InnerText),
					Name = movieNode
						.SelectSingleNode("descendant::mcu:movie-name", namespaceMgr)!.InnerText,
					ReleaseDate = DateOnly.Parse(movieNode
						.SelectSingleNode("descendant::mcu:movie-release", namespaceMgr)!.InnerText)
				});
			}
		}

		/// <summary>
		/// Just to make the code highlighting look OK.
		/// Should return actual movies
		/// </summary>
		/// <returns>An empty list of movies.</returns>
		public List<Movie> GetMovies()
		{
			//
			return new List<Movie>();
		}

		/// <summary>
		/// Just to make the code highlighting look OK.
		/// Should return and actual connection string
		/// </summary>
		/// <returns>An empty string.</returns>
		string GetConnectionString()
		{
			return string.Empty;
		}
	}
}
