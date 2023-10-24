using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesBasketballStats.Data;
using RazorPagesBasketballStats.Models;

namespace RazorPagesBasketballStats.Pages_Players
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesBasketballStats.Data.RazorPagesBasketballStatsContext _context;

        public CreateModel(RazorPagesBasketballStats.Data.RazorPagesBasketballStatsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Player Player { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Player == null || Player == null)
            {
                return Page();
            }

            _context.Player.Add(Player);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
