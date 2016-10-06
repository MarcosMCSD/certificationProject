using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _03_PortalMVC.Models
{
    public class LoginViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "L'adresse Email est nécessaire")]
        [EmailAddress(ErrorMessage = "Adresse Email invalide")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est nécessaire")]
        public string Password { get; set; }

        [Display(Name = "SubscriptionId")]
        public string SubscriptionId { get; set; }
        [Display(Name = "CashierId")]
        public string CashierId { get; set; }
    }
}