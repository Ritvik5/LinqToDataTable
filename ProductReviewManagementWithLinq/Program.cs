﻿namespace ProductReviewManagementWithLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management");

            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProducID=1,UserID=1,Rating=2,Review="Good",isLike=true},
                new ProductReview(){ProducID=2,UserID=1,Rating=4,Review="Good",isLike=true},
                new ProductReview(){ProducID=3,UserID=1,Rating=5,Review="Good",isLike=true},
                new ProductReview(){ProducID=4,UserID=1,Rating=6,Review="Good",isLike=false},
                new ProductReview(){ProducID=5,UserID=1,Rating=2,Review="nice",isLike=true},
                new ProductReview(){ProducID=6,UserID=1,Rating=1,Review="bas",isLike=true},
                new ProductReview(){ProducID=8,UserID=1,Rating=10,Review="Good",isLike=false},
                new ProductReview(){ProducID=8,UserID=1,Rating=9,Review="nice",isLike=true},
                new ProductReview(){ProducID=2,UserID=1,Rating=10,Review="nice",isLike=true},
                new ProductReview(){ProducID=10,UserID=1,Rating=8,Review="nice",isLike=true},
                new ProductReview(){ProducID=11,UserID=1,Rating=3,Review="nice",isLike=true}

            };

            Management management = new Management();
            //management.TopRecords(productReviewList);

            //management.SelectedRecords(productReviewList);

            //management.RetrieveCountOfRecords(productReviewList);

            //management.RetrieveSelectedColumn(productReviewList);

            management.SkipTopFiveRecords(productReviewList);
        }
    }
}