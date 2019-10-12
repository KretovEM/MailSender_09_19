using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using MailSenderConsoleTest.Data;

namespace MailSenderConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SongsDB())
            {
                //db.Database.Log = msg => Console.WriteLine("EF: {0}\r\n-----------------", msg);

                var tracksCount = db.Tracks.Count();
                Console.WriteLine("В базе данных содержится {0} песен", tracksCount);

                var longTracks = db.Tracks.Where(track => track.Length > 500);

                foreach (var info in longTracks
                   .Select(t => new
                   {
                       ArtistName = t.Artist.Name,
                       t.Artist.Birthday
                   }))
                {
                    Console.WriteLine("Artist:{0}, date:{1}", info.ArtistName, info.Birthday);
                }

                //db.Database.ExecuteSqlCommand()
            }

            //Console.WriteLine();
            //Console.ReadLine();

            //Console.Clear();

            //using (var db = new SongsDB())
            //{
            //    db.Database.Log = msg => Console.WriteLine("EF: {0}\r\n-----------------", msg);

            //    for (var i = 1; i <= 3; i++)
            //    {
            //        var artist = new Artist
            //        {
            //            Name = $"Artist name {i}",
            //            Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 20))),
            //            Tracks = new List<Track>()
            //        };

            //        for (var j = 1; j < 3; j++)
            //        {
            //            var track = new Track
            //            {
            //                Name = $"Track {i + j}",
            //                Length = j * 456
            //            };
            //            artist.Tracks.Add(track);
            //        }

            //        db.Artists.Add(artist);
            //    }

            //    db.SaveChanges();
            //}

            Console.ReadLine();
        }
    }

    
}
