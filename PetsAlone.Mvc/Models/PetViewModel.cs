using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetsAlone.Mvc.Models
{
    public class PetViewModel
    {
        public PetViewModel()
        {
            PetTypes = new List<SelectListItem>()
            {
                new SelectListItem() { Text= "Cat", Value="1" },
                new SelectListItem() { Text = "Dog", Value = "2" },
                new SelectListItem() { Text = "Hamster", Value = "3" },
                new SelectListItem() { Text = "Bird", Value = "4" },
                new SelectListItem() { Text = "Rabbit", Value = "5" },
                new SelectListItem() { Text = "Fish", Value = "6" },
                new SelectListItem() { Text = "Lizard", Value = "7" },
                new SelectListItem() { Text = "Horse", Value = "8" },
                new SelectListItem() { Text = "Gerbil", Value = "9" },
                new SelectListItem() { Text = "Tortoise", Value = "10" }
            };
        }
        
        [RegularExpression("[A-Za-z]*", ErrorMessage = "Pet name cannot be empty")]
        public string Name { get; set; }
        
        [DisplayName("Missing Since Date")]
        public DateTime MissingSinceDateTime { get; set; }
        
        [DisplayName("Pet Type")]
        public string selectedPetType { get; set; }
        
        public IList<SelectListItem> PetTypes { get; set; }
    }
}