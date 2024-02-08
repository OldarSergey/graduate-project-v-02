using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocRelationType
{
    public int KeyRelationType { get; set; }

    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    public string Name { get; set; } = null!;

    public string? Sn { get; set; }

    public string? Comment { get; set; }

    public string? SysName { get; set; }

    public virtual ICollection<DocNoteRelationType> DocNoteRelationTypes { get; set; } = new List<DocNoteRelationType>();

    public virtual ICollection<DocRelation> DocRelations { get; set; } = new List<DocRelation>();
}
