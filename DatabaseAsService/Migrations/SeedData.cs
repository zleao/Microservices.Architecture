using DatabaseAsService.Data;
using DatabaseAsService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DatabaseAsService.Migrations
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseAsServiceContext(serviceProvider.GetRequiredService<DbContextOptions<DatabaseAsServiceContext>>()))
            {
                // Look for any data in the database.
                if (context.Sessions.Any() || context.Keywords.Any() || context.SessionKeywordMappings.Any())
                {
                    return;   // DB has been seeded
                }

                context.Sessions.AddRange(
                     new Session
                     {
                         Title = "Session 1",
                     },
                     new Session
                     {
                         Title = "Session 2",
                     },
                     new Session
                     {
                         Title = "Session 3",
                     }
                );

                context.Keywords.AddRange(
                    new Keyword { Value = "Keyword 1" },
                    new Keyword { Value = "Keyword 2" },
                    new Keyword { Value = "Keyword 3" },
                    new Keyword { Value = "Keyword 4" }
                );

                context.SaveChanges();

                var s1 = context.Sessions.First();
                var s2 = context.Sessions.Skip(1).First();
                var s3 = context.Sessions.Last();

                var k1 = context.Keywords.First();
                var k2 = context.Keywords.Skip(1).First();
                var k3 = context.Keywords.Skip(2).First();
                var k4 = context.Keywords.Last();

                context.SessionKeywordMappings.AddRange(
                    new SessionKeywordMapping { SessionId = s1.Id, KeywordId = k1.Id },
                    new SessionKeywordMapping { SessionId = s1.Id, KeywordId = k2.Id },
                    new SessionKeywordMapping { SessionId = s2.Id, KeywordId = k2.Id },
                    new SessionKeywordMapping { SessionId = s2.Id, KeywordId = k3.Id },
                    new SessionKeywordMapping { SessionId = s3.Id, KeywordId = k3.Id },
                    new SessionKeywordMapping { SessionId = s3.Id, KeywordId = k4.Id }
                );

                context.SaveChanges();
            }
        }
    }
}
