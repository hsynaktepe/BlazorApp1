using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Models
{
    public class Suppliers
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(50)]
        public String Name { get; set; } = String.Empty;
        public String WebURL { get; set; } = String.Empty;
        public bool IsActive { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }

    }
}
