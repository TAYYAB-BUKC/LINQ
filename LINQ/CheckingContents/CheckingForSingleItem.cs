using LINQ.Data.Models;

namespace LINQ.CheckingContents
{
    public class CheckingForSingleItem : QueryRunner
    {
        public override void Run()
        {
            CheckIfItemIsPresent();
        }

        /// <summary>
        /// Check if an item exists in a source
        /// </summary>
        void CheckIfItemIsPresent()
        {
            var blackWidow = Repository.GetByName("Black Widow");

            var sourceMovies = Repository.GetAllMovies();

            var isMoviePresent = sourceMovies.Contains(blackWidow);

            Console.WriteLine(isMoviePresent);
        }
    }
}