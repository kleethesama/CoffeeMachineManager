using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CoffeeMachineManager.Models
{
    public class CoffeeMachine
    {
        public int Id { get; set; }

        [Required]
        public Locations Location { get; set; }

        [Required]
        public Types Type { get; set; }

        [Required]
        public MachineStatus Status { get; set; }

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

        public enum MachineStatus : byte
        {
            Active,
            Inactive,
            [Display(Name = "Under Maintenance")]
            UnderMaintenance,
            [Display(Name = "Out of Service")]
            OutOfService
        }
    }
}
