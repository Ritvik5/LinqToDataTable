using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagementWithLinq
{
    class Management
    {
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:-" + list.UserID +
                    " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }

        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordData = from productReviews in listProductReview
                             where (productReviews.ProducID == 1 || productReviews.ProducID == 4 || productReviews.ProducID == 9)
                             && productReviews.Rating > 3
                             select productReviews;
            Console.WriteLine(recordData);
            foreach (var list in recordData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:- " + list.UserID + " " + "Rating:- " + " " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }

        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(y => y.ProducID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "____________" + list.Count);
            }
        }

        public void RetrieveSelectedColumn(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.Select(x => new { ProductID = x.ProducID, Review = x.Review });

            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductID + "______________" + list.Review);
            }
        }

        public void SkipTopFiveRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                select productReviews).Skip(5);
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductID:- " + list.ProducID + " " + "UserID:-" + list.UserID +
                    " " + "Rating:- " + list.Rating + " " + "Review:- " + list.Review + " " + "isLike:- " + list.isLike);
            }
        }
    }
}
