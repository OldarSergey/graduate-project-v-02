using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteRelationType
{
    public int KeyNoteRelationType { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Тип отношения
    /// </summary>
    public int KeyRelationType { get; set; }

    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;

    public virtual DocRelationType KeyRelationTypeNavigation { get; set; } = null!;
}
