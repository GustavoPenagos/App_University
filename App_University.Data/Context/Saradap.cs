using System;
using System.Collections.Generic;

namespace App_University.Data.Context;

public partial class Saradap
{
    public int SaradapPidm { get; set; }

    public string SaradapTermCodeEntry { get; set; } = null!;

    public byte SaradapApplNo { get; set; }

    public string? SaradapLevlCode { get; set; }

    public DateTime? SaradapApplDate { get; set; }

    public string? SaradapApstCode { get; set; }

    public DateTime? SaradapApstDate { get; set; }

    public string? SaradapAdmtCode { get; set; }

    public string? SaradapStypCode { get; set; }

    public string? SaradapCampCode { get; set; }

    public string? SaradapCollCode1 { get; set; }

    public string? SaradapDegcCode1 { get; set; }

    public string? SaradapMajrCode1 { get; set; }

    public string? SaradapProgram1 { get; set; }
}
