using System;
using System.ComponentModel.DataAnnotations;

namespace DTO_Automapper_Template.Models
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime BirthDate { get; set; }

    }
}