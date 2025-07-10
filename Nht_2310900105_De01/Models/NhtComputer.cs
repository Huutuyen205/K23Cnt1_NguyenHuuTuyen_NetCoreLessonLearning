using System;
using System.Collections.Generic;

namespace Nht_2310900105_De01.Models;

public partial class NhtComputer
{
    public int NhtComId { get; set; }

    public string? NhtComName { get; set; }

    public double? NhtComPrice { get; set; }

    public bool? NhtComStatus { get; set; }

    public string? NhtComImage { get; set; }

    public int? NhtCateId { get; set; }

    public virtual NhtCategory? NhtCate { get; set; }
}
