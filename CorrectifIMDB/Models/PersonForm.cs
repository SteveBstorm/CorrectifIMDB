using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectifIMDB.Models
{
    public class PersonForm
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Prénom")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        [StringLength(160, ErrorMessage = "Taille max: 160 et min :3", MinimumLength = 6)]
        public string LastName { get; set; }
    }
}
