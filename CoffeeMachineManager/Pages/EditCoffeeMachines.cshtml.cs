using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeMachineManager.Pages
{
    public class EditCoffeeMachinesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditCoffeeMachinesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoffeeMachine CoffeeMachine { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CoffeeMachine = _context.CoffeeMachines.FirstOrDefault(m => m.Id == id);

            if (CoffeeMachine == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            // Find and update the coffee machine
            var coffeeMachine = _context.CoffeeMachines.FirstOrDefault(m => m.Id == id);
            if (coffeeMachine == null)
            {
                return NotFound();
            }

            coffeeMachine.Location = CoffeeMachine.Location;
            coffeeMachine.Type = CoffeeMachine.Type;
            coffeeMachine.Status = CoffeeMachine.Status;

            _context.SaveChanges();

            return RedirectToPage("/CoffeeMachines");
        }
    }
}