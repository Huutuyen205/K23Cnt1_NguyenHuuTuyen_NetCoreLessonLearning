using System;
using System.Collections.Generic;

namespace Nht_2310900105_De01.Models;

public partial class NhtCategory
{
    public int NhtCateId { get; set; }

    public string? NhtCateName { get; set; }

    public virtual ICollection<NhtComputer> NhtComputers { get; set; } = new List<NhtComputer>();
}
