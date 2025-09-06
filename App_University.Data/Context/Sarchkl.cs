using System;
using System.Collections.Generic;

namespace App_University.Data.Context;

public partial class Sarchkl
{
    public int SarchklPidm { get; set; }

    public string SarchklTermCodeEntry { get; set; } = null!;

    public byte SarchklApplNo { get; set; }

    public string SarchklAdmrCode { get; set; } = null!;

    public string? SarchklMandatoryInd { get; set; }

    public DateTime? SarchklReceiveDate { get; set; }

    public string? SarchklComment { get; set; }
}
