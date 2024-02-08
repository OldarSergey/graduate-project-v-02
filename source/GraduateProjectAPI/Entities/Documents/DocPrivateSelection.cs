using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocPrivateSelection
{
    public int KeyPrivateSelection { get; set; }

    public int? KeyParent { get; set; }

    /// <summary>
    /// Владелец (KSM)
    /// </summary>
    public int? KeyUserOwner { get; set; }

    public int Flags { get; set; }

    public string? Name { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public DateTime? PeriodBegin { get; set; }

    public DateTime? PeriodEnd { get; set; }

    public int? KeyUserReceiver { get; set; }

    public virtual ICollection<DocSelection> DocSelections { get; set; } = new List<DocSelection>();

    public virtual ICollection<DocPrivateSelection> InverseKeyParentNavigation { get; set; } = new List<DocPrivateSelection>();

    public virtual DocPrivateSelection? KeyParentNavigation { get; set; }
}
