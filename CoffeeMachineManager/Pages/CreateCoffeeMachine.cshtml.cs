using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoffeeMachineManager.Data;
using CoffeeMachineManager.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CoffeeMachineManager.Pages
{
    
    public class CreateCoffeeMachineModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public CoffeeMachine CoffeeMachine { get; set; }

        public CreateCoffeeMachineModel(ApplicationDbContext context, CoffeeMachine coffeeMachine)
        {
            _context = context;
            CoffeeMachine = coffeeMachine;
        }

        public IActionResult OnPost()
        {
            // Validate form inputs
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save coffee machine to the database
            _context.CoffeeMachines.Add(CoffeeMachine);
            _context.SaveChanges();

            TempData["Message"] = "Coffee machine added successfully!";
            return RedirectToPage("CoffeeMachines");
        }
    }
}
