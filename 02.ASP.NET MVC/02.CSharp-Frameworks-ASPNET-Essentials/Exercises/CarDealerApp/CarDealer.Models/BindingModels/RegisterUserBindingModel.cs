﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.BindingModels
{
    public class RegisterUserBindingModel
    {
        [RegularExpression(@"^(?=.{8,20}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$")]
        public string UserName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+@[a-z]+\.[a-z]+$")]
        public string Email { get; set; }

        [MinLength(5)]
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
