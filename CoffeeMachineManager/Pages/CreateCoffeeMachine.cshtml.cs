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

        public CreateCoffeeMachineModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoffeeMachine CoffeeMachine { get; set; } = new CoffeeMachine();

        // Dropdown options for location and type

        public enum Locations : byte
        {
            Lobby,
            Cafeteria,
            Breakroom,
            Reception
        }

        public enum Types : byte
        {
            [Display(Name = "Espresso Machine")]
            EspressoMachine,
            [Display(Name = "Drip Coffee Maker")]
            DripCoffeeMaker,
            [Display(Name = "Pod Coffee Machine")]
            PodCoffeeMachine,
            [Display(Name = "Bean-to-Cup Machine")]
            BeanToCupMachine
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
