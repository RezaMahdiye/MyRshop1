using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyRshop.Models
{
    public class Users
    {
        [Key]
        public int UserId { set; get; }
        [Required]
        [EmailAddress]
        [MaxLength(300)]
        public string Email { set; get; }
        [Required]
        [MaxLength(50)]
        public string Password { set; get; }
        [Required]
        public DateTime RegisterDate { set; get; }
        public bool IsAdmin { set; get; }
    }
}
