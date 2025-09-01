// See https://aka.ms/new-console-template for more information
using LINQ.FilteringAndOrdering;
using LINQ.Introduction;

// Working with LINQ Query Syntax
var movies = new NonLinqCodeSamples().GetMovies();

var linqResult = from movie in movies
				 where movie.Name.Contains("Spider")
				 select movie;

// Working with LAMBDA Syntax / Fluent Syntax
var linqResult2 = movies
				  .Where(movie => movie.Name.Contains("Spider"))
				  .Select(movie => movie);

new WhereConditions().Run();

Console.ReadKey();