namespace LinqToDataTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Data Table demo");
            LinqToDataTable linqToDataTable = new LinqToDataTable();
            linqToDataTable.AddToDataTableDemo();
            //linqToDataTable.DisplayTable();
            //linqToDataTable.RetrieveIsLikeValueTrue();
            Console.ReadKey();
        }
    }
}