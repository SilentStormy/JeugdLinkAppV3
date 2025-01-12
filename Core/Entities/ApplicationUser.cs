using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class ApplicationUser:IdentityUser //extend
    {
        private string Firstname { get; set; }
        
        private string Lastname { get; set; }
        
        private DateOnly DateOfBirth { get; set; }

        public ApplicationUser() { }    
        public ApplicationUser(string firstname,string lastname, DateOnly dateofbirth) 
        {
            Firstname= firstname;
            Lastname= lastname;
            DateOfBirth= dateofbirth;

        }


        [Required]
        [Display(Name="Voornaam")]
        public string firstname
        {
            get => Firstname;
            set => Firstname = value; 
        }
       

        [Required]
        [Display(Name = "Achternaam")]
        public string lastname
        {
            get => Lastname; 
            set => Lastname = value; 
        }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateOnly dateofbirth
        {
            get => DateOfBirth;
            set => DateOfBirth = value;    
        }

    }
}