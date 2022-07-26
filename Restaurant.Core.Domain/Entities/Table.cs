using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Table
    {
        public int TableOf { get; set; }
        public string Description { get; set; }
        public enum Stauts { Availble,InProcess,Finished}
    }
}
