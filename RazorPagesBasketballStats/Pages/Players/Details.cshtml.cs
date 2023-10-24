using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesBasketballStats.Data;
using RazorPagesBasketballStats.Models;

namespace RazorPagesBasketballStats.Pages_Players
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesBasketballStats.Data.RazorPagesBasketballStatsContext _context;

        public DetailsModel(RazorPagesBasketballStats.Data.RazorPagesBasketballStatsContext context)
        {
            _context = context;
        }

      public Player Player { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Player == null)
            {
                return NotFound();
            }

            var player = await _context.Player.FirstOrDefaultAsync(m => m.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            else 
            {
                Player = player;
            }
            return Page();
        }
    }
}
