namespace LINQ.CheckingContents
{
	public class RemoveDuplicates : QueryRunner
	{
		public override void Run()
		{
			RemoveDuplicateItems();
		}

		/// <summary>
		/// Remove duplicates from a source.
		/// </summary>
		private void RemoveDuplicateItems()
		{
			int[] sourceItems = [1, 3, 5, 3, 7, 7, 1, 6, 15, 23];

			var result = sourceItems.Distinct();

			PrintAll(result);
		}
	}
}