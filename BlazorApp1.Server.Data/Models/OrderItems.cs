using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Server.Data.Models
{
    public class OrderItems
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreatedUserId { get; set; }
        public int OrderId { get; set; }
        public String Description { get; set; } = String.Empty;

        public virtual Users CreatedUser { get; set; }
        public virtual Orders Order { get; set; }

    }
}
