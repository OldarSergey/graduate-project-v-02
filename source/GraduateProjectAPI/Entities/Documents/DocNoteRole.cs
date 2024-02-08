using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteRole
{
    public int KeyNoteRole { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Роль
    /// </summary>
    public int KeyRole { get; set; }

    /// <summary>
    /// (CreationRequired, Unrestricted)
    /// </summary>
    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Разрешения, предоставляемые ролью к документам вида.
    /// </summary>
    public int Permissions { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public int KeyNotes { get; set; }

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;
}
