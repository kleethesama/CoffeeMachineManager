using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace CoffeeMachineManager.Pages
{
    
    public class CoffeeMachinesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<CoffeeMachine> CoffeeMachines { get; set; }

        public CoffeeMachinesModel(ApplicationDbContext context, List<CoffeeMachine> coffeeMachines)
        {
            _context = context;
            CoffeeMachines = coffeeMachines;
        }

        public void OnGet()
        {
            // Fetch all coffee machines from the database
            CoffeeMachines = [.. _context.CoffeeMachines];
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
