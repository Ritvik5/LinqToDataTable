using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToDataTable
{
    class LinqToDataTable
    {
        DataTable productReviewTable = new DataTable();

        public void AddToDataTableDemo()
        {
            productReviewTable.Columns.Add("ProductID");
            productReviewTable.Columns.Add("UserID");
            productReviewTable.Columns.Add("Rating");
            productReviewTable.Columns.Add("Review");
            productReviewTable.Columns.Add("isLike");


            productReviewTable.Rows.Add("1", "101", "5", "Nice", "True");
            productReviewTable.Rows.Add("2", "102", "4", "Good", "False");
            productReviewTable.Rows.Add("3", "103", "3", "Nice", "True");
            productReviewTable.Rows.Add("4", "104", "1", "Nice", "False");
            productReviewTable.Rows.Add("5", "105", "2", "Good", "True");
            productReviewTable.Rows.Add("6", "106", "3", "Nice", "False");
            productReviewTable.Rows.Add("7", "107", "1", "Nice", "True");
            productReviewTable.Rows.Add("8", "108", "4", "Good", "True");
            productReviewTable.Rows.Add("9", "109", "2", "Nice", "False");
            productReviewTable.Rows.Add("10", "110", "5", "Good", "True");
            DisplayTable();
        }

        public void DisplayTable()
        {
            var query = from row in productReviewTable.AsEnumerable()
                        select new
                        {
                            ProductID = row.Field<string>("ProductID"),
                            UserID = row.Field<string>("UserID"),
                            Rating = row.Field<string>("Rating"),
                            Review = row.Field<string>("Review"),
                            IsLike = row.Field<string>("IsLike")
                        };

            Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}", "ProductID", "UserID", "Rating", "Review", "IsLike");

            foreach (var item in query)
            {
                Console.WriteLine("{0,-10}{1,-10}{2,-10}{3,-10}{4,-10}", item.ProductID, item.UserID, item.Rating, item.Review, item.IsLike);
            }

            Console.ReadLine();
        }
    }
}




