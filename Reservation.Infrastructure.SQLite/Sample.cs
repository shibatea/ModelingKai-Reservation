using System;
using System.Linq;
using Reservation.Infrastructure.SQLite.Reservation;

namespace Reservation.Infrastructure.SQLite
{
    public class Sample
    {
        //     public static void Blogging()
        //     {
        //         using var db = new BloggingContext();
        //
        //         // Create
        //         Console.WriteLine("Inserting a new blog");
        //         db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
        //         db.SaveChanges();
        //
        //         // Read
        //         Console.WriteLine("Querying for a blog");
        //         var blog = db.Blogs
        //             .OrderBy(b => b.BlogId)
        //             .First();
        //
        //         // Update
        //         Console.WriteLine("Updating the blog and adding a post");
        //         blog.Url = "https://devblogs.microsoft.com/dotnet";
        //         blog.Posts.Add(
        //             new Post
        //             {
        //                 Title = "Hello World",
        //                 Content = "I wrote an app using EF Core!"
        //             });
        //         db.SaveChanges();
        //
        //         // Delete
        //         Console.WriteLine("Delete the blog");
        //         db.Remove(blog);
        //         db.SaveChanges();
        //     }

        public static void Reservation()
        {
            using var db = new ReservationContext();

            // Create
            db.Add(new Reservation.Reservation
            {
                Id = 4,
                RoomName = "A",
                StartDateTime = DateTime.UtcNow,
                EndDateTime = DateTime.UtcNow.AddHours(1)
            });
            db.SaveChanges();

            // Read
            var reservation = db.Reservations
                .OrderBy(r => r.Id)
                .First();

            // Read filter DateTime
            var reservation2 = db.Reservations
                .OrderByDescending(r => r.Id)
                .First(r => r.EndDateTime > DateTime.UtcNow);

            // Update
            reservation.EndDateTime = DateTime.UtcNow.AddHours(2);
            db.SaveChanges();

            // Delete
            db.Remove(reservation);
            db.SaveChanges();
        }
    }
}
