using System;
using System.Collections.Generic;

namespace CarBase
{
    public partial class CompanyTable
    {
        public CompanyTable()
        {
            CarsTables = new HashSet<CarsTable>();
        }

        public int Id { get; set; }
        public string? Company { get; set; }

        public virtual ICollection<CarsTable> CarsTables { get; set; }
    }
}
