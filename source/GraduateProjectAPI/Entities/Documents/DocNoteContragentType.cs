using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteContragentType
{
    public int KeyNoteContragentType { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Тип контрагента
    /// </summary>
    public int KeyContragentType { get; set; }

    /// <summary>
    /// Класс субъекта, выступающего в качестве контрагента. Если не указывать - значит допускается любой класс.
    /// </summary>
    public int? KeyClass { get; set; }

    public int? KeyClassView { get; set; }

    /// <summary>
    /// (Caption, Unique)
    /// </summary>
    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public int KeyNotes { get; set; }

    public virtual DocContragentType KeyContragentTypeNavigation { get; set; } = null!;

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;
}
