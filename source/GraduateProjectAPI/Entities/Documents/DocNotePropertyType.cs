using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNotePropertyType
{
    public int KeyNotePropertyType { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Вид свойства
    /// </summary>
    public int KeyPropertyType { get; set; }

    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Оригинальное разрешение к документу, необходимое для редактирования этого свойства. 0 - разрешений не требуется.
    /// </summary>
    public int Origin { get; set; }

    public int? KeyDefValue { get; set; }

    public string? DefValue { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public int KeyNotes { get; set; }

    public virtual ICollection<DocNoteTableDumpField> DocNoteTableDumpFields { get; set; } = new List<DocNoteTableDumpField>();

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;

    public virtual DocPropertyType KeyPropertyTypeNavigation { get; set; } = null!;
}
