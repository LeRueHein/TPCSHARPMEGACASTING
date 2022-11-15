using System;
using System.Collections.Generic;

namespace MegaCasting2022.DBLib.Class
{
    public partial class ContratType
    {
        public long Identifier { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }
    }
}
