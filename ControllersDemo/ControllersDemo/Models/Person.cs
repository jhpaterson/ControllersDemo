﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ControllersDemo.Models
{
    public class Person
    {   
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}