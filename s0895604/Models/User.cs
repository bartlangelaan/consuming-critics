﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace s0895604.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Gebruikersnaam")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Wachtwoord")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Voornaam")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Achternaam")]
        public string LastName { get; set; }

        [DisplayName("Rol")]
        public UserRole Role { get; set; }

        [DisplayName("Actief")]
        public bool Active { get; set; }

        //public virtual ICollection<Review> Reviews { get; set; } 
    }

    public enum UserRole
    {
        Admin = 1,
        User = 2
    }
}