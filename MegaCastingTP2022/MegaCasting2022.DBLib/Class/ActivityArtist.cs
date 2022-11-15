using System;
using System.Collections.Generic;

namespace MegaCasting2022.DBLib.Class
{
    public partial class ActivityArtist
    {
        public long Identifier { get; set; }
        public long IdentifierArtist { get; set; }
        public long IdentifierActivity { get; set; }

        public virtual Activity IdentifierActivityNavigation { get; set; } = null!;
        public virtual Artist IdentifierArtistNavigation { get; set; } = null!;
    }
}
