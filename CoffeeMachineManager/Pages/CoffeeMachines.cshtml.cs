using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace CoffeeMachineManager.Pages
{
    
    public class CoffeeMachinesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CoffeeMachinesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // List of Coffee Machines to display
        public List<CoffeeMachine> CoffeeMachines { get; set; } = new List<CoffeeMachine>();

        // Dropdown options for locations, types, and statuses
        public List<string> Locations { get; set; } = new List<string> { "Lobby", "Cafeteria", "Breakroom", "Reception" };
        public List<string> Types { get; set; } = new List<string> { "Espresso Machine", "Drip Coffee Maker", "Pod Machine", "Bean-to-Cup Machine" };
        public List<string> Statuses { get; set; } = new List<string> { "Active", "Inactive", "Under Maintenance", "Out of Service" };

        public void OnGet()
        {
            // Fetch all coffee machines from the database
            CoffeeMachines = _context.CoffeeMachines.ToList();
        }

        public IActionResult OnPostAddCoffeeMachine(CoffeeMachine coffeeMachine)
        {
            if (!ModelState.IsValid)
            {
                //ModelState.AddModelError("", "All fields are required.");
                ModelState.AddModelError("", "Something went wrong!");
                return Page();
            }

            // Add to the database
            _context.CoffeeMachines.Add(coffeeMachine);
            _context.SaveChanges();

            // Redirect to the Coffee Machines page
            return RedirectToPage("/CoffeeMachines");
        }
    }
}
