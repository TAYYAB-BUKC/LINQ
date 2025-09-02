// See https://aka.ms/new-console-template for more information
using LINQ.FilteringAndOrdering;
using LINQ.Introduction;
using LINQ.OutputFromQueries;
using LINQ.PartialResults;

// Working with LINQ Query Syntax
var movies = new NonLinqCodeSamples().GetMovies();

var linqResult = from movie in movies
				 where movie.Name.Contains("Spider")
				 select movie;

// Working with LAMBDA Syntax / Fluent Syntax
var linqResult2 = movies
				  .Where(movie => movie.Name.Contains("Spider"))
				  .Select(movie => movie);

//new WhereConditions().Run();

//new Ordering().Run();

//new DeferredExecution().Run();

//new GetAllResults().Run();

//new GetSingleItem().Run();

//new ProjectingResults().Run();

//new ChunkedResult().Run();

//new SkipAndTake().Run();

new GroupedResults().Run();

Console.ReadKey();