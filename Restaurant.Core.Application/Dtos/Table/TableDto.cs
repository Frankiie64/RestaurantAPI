using Restaurant.Core.Application.Dtos.Request;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.Table
{
    public class TableDto
    {
        public int Id { get; set; }
        public int TableOf { get; set; }
        public string Description { get; set; }
        public string Disponibility { get; set; }
        public StautsTable Stauts { get; set; }
        public ICollection<RequestDto> Orders { get; set; }
    }
}
