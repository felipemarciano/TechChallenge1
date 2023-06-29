﻿using System.ComponentModel.DataAnnotations;

namespace TechChallenge1.Api.Model
{
    public class RegisterRequest
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}
