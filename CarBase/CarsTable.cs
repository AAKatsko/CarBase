using System;
using System.Collections.Generic;

namespace CarBase
{
    public partial class CarsTable
    {
        public int Id { get; set; }
        public int? Company { get; set; }
        public string? Model { get; set; }
        public int? Power { get; set; }
        public int? BodyType { get; set; }
        public int? Weight { get; set; }
        public int? Prise { get; set; }

        public virtual BodyTypeTable? BodyTypeNavigation { get; set; }
        public virtual CompanyTable? CompanyNavigation { get; set; }
    }
}
