using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesBasketballStats.Data;
using RazorPagesBasketballStats.Models;

namespace RazorPagesBasketballStats.Pages_Players
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesBasketballStats.Data.RazorPagesBasketballStatsContext _context;

        public IndexModel(RazorPagesBasketballStats.Data.RazorPagesBasketballStatsContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Positions { get; set; }
        public string? PlayerPosition { get; set; }

        public async Task OnGetAsync()
{
    IQueryable<string> positionQuery = from n in _context.Player
                                    orderby n.Position
                                    select n.Position;
    var players = from p in _context.Player
                 select p;
    if (!string.IsNullOrEmpty(SearchString))
    {
        players = players.Where(s => s.Name.Contains(SearchString));
    }

    if (!string.IsNullOrEmpty(PlayerPosition))
    {
        players = players.Where(x => x.Position == PlayerPosition);
    }
    Positions = new SelectList(await positionQuery.Distinct().ToListAsync());
    Player = await players.ToListAsync();
}
    }
}
