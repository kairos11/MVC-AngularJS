using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {

        }

        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public List<RegisterViewModel> Registrations { get; set; }
    }
}