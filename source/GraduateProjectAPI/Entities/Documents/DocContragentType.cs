using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocContragentType
{
    public int KeyContragentType { get; set; }

    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    public string Name { get; set; } = null!;

    public string? Sn { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public string? SysName { get; set; }

    public virtual ICollection<DocContragent> DocContragents { get; set; } = new List<DocContragent>();

    public virtual ICollection<DocNoteContragentType> DocNoteContragentTypes { get; set; } = new List<DocNoteContragentType>();
}
