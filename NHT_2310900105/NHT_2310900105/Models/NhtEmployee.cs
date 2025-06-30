using System;
using System.Collections.Generic;

namespace NHT_2310900105.Models;

public partial class NhtEmployee
{
    public int NhtEmpId { get; set; }

    public string? NhtEmpName { get; set; }

    public string? NhtEmpLevel { get; set; }

    public DateTime? NhtEmpStartDate { get; set; }

    public Boolean? NhtEmpStatus { get; set; }
}
