﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int TableOf { get; set; }
        public string Description { get; set; }
        public StautsTable Stauts { get; set; }
        public ICollection<Request> Orders { get; set; }
    }
    public enum StautsTable { Availble = 1, InProcess, Finished }

}
