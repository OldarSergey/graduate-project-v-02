using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteCounter
{
    public int KeyNoteCounter { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNotes { get; set; }

    /// <summary>
    /// Подразделение (KSM)
    /// </summary>
    public int? KeyDepartment { get; set; }

    /// <summary>
    /// Значение счетчика
    /// </summary>
    public int Counter { get; set; }

    public int Flags { get; set; }

    public byte[] Version { get; set; } = null!;

    public string? Comment { get; set; }

    public int KeyNote { get; set; }

    public virtual DocNote KeyNotesNavigation { get; set; } = null!;
}
