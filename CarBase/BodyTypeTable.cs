using System;
using System.Collections.Generic;

namespace CarBase
{
    public partial class BodyTypeTable
    {
        public BodyTypeTable()
        {
            CarsTables = new HashSet<CarsTable>();
        }

        public int Id { get; set; }
        public string? BodyType { get; set; }

        public virtual ICollection<CarsTable> CarsTables { get; set; }
    }
}
