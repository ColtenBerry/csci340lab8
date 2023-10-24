using Microsoft.EntityFrameworkCore;
using RazorPagesBasketballStats.Data;

namespace RazorPagesBasketballStats.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesBasketballStatsContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesBasketballStatsContext>>()))
        {
            if (context == null || context.Player == null)
            {
                throw new ArgumentNullException("Null RazorPagesBasketballStatsContext");
            }

            // Look for any movies.
            if (context.Player.Any())
            {
                return;   // DB has been seeded
            }

            context.Player.AddRange(
                new Player
                {
                    Name = "Daniel Cobb",
                    Number = 0,
                    Position = "PG",
                    FGA = 99,
                    FGM = 17,
                    FTA = 22,
                    FTM = 2
                },

                new Player
                {
                    Name = "Darvis Raspberry Jr.",
                    Number = 20,
                    Position = "PF",
                    FGA = 1354,
                    FGM = 1090,
                    FTA = 24,
                    FTM = 17
                },

                new Player
                {
                    Name = "Tyler Deithloff",
                    Number = 44,
                    Position = "SF",
                    FGA = 399,
                    FGM = 399,
                    FTA = 54,
                    FTM = 53
                },

                new Player
                {
                    Name = "Caleb Squires",
                    Number = 12,
                    Position = "SG",
                    FGA = 212,
                    FGM = 198,
                    FTA = 97,
                    FTM = 97
                }
            );
            context.SaveChanges();
        }
    }
}