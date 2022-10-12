using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.Shared.FilterModels
{
    public class OrderListFilterModel
    {
        public DateTime? CreateDateFirst { get; set; }

        public DateTime CreateDateLast { get; set; }

        public int CreatedUserId { get; set; }
    }
}
