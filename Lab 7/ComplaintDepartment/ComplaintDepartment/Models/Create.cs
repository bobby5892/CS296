using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintDepartment.Models
{
    public class Create
    {
        [Required]
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress),EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
