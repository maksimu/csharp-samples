using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DriverAssistent_WebService.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public virtual UserRole role { get; set; }
        public virtual List<Destination> destinations { get; set; }
    }
}