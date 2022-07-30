using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Application.Dtos.Request
{
    public class CreateRequestDto
    {
        public int IdTable { get; set; }
        public StautsRequest stauts { get; set; }
        public List<int> Dishes { get; set; }
    }
}
