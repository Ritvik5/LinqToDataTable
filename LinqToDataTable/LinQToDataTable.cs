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
            productReviewTable.Columns.Add("ProductID",typeof(int));
            productReviewTable.Columns.Add("UserID",typeof(int));
            productReviewTable.Columns.Add("Rating", typeof(int));
            productReviewTable.Columns.Add("Review", typeof(string));
            productReviewTable.Columns.Add("isLike", typeof(bool));


            productReviewTable.Rows.Add(1, 101, 5, "Nice", true);
            productReviewTable.Rows.Add(2, 102, 4, "Good", false);
            productReviewTable.Rows.Add(3, 103, 3, "Nice", true);
            productReviewTable.Rows.Add(4, 104, 1, "Nice", false);
            productReviewTable.Rows.Add(5, 105, 2, "Good", true);
            productReviewTable.Rows.Add(6, 106, 3, "Nice", false);
            productReviewTable.Rows.Add(7, 107, 1, "Nice", true);
            productReviewTable.Rows.Add(8, 108, 4, "Good", true);
            productReviewTable.Rows.Add(9, 109, 2, "Nice", false);
            productReviewTable.Rows.Add(10, 110, 5, "Good", true);
            RetrieveReviewNice();  
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

        public void RetrieveIsLikeValueTrue()
        {
            var likedProducts = from DataRow row in productReviewTable.Rows
                                where row.Field<bool>("isLike") == true
                                select row;

            foreach (DataRow row in likedProducts)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}",
                                  row["ProductID"], row["UserID"], row["Rating"],
                                  row["Review"], row["isLike"]);
            }
        }

        public void RetrieveAverageRaing() 
        {
            var productRatings = from DataRow row in productReviewTable.Rows
                                 group row by row.Field<int>("ProductID") into g
                                 select new
                                 {
                                     ProductID = g.Key,
                                     AvgRating = g.Average(r => r.Field<int>("Rating"))
                                 };
            foreach (var pr in productRatings)
            {
                Console.WriteLine("ProductID: {0}, AvgRating: {1:F2}", pr.ProductID, pr.AvgRating);
            }

        }

        public void RetrieveReviewNice()
        {
            var niceReviews = from row in productReviewTable.AsEnumerable()
                              where row.Field<string>("Review") == "Nice"
                              select row;


            foreach (var row in niceReviews)
            {
                Console.WriteLine("ProductID: {0}, UserID: {1}, Rating: {2}, Review: {3}, isLike: {4}",
                    row.Field<int>("ProductID"), row.Field<int>("UserID"), row.Field<int>("Rating"),
                    row.Field<string>("Review"), row.Field<bool>("isLike"));
            }

        }
    }
}




