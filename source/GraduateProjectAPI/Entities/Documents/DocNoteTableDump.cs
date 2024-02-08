using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteTableDump
{
    public int KeyNoteTableDump { get; set; }

    /// <summary>
    /// Характерная таблица
    /// </summary>
    public int KeyNoteTable { get; set; }

    /// <summary>
    /// Конечная таблица, в которую будет осуществлён экспорт.
    /// </summary>
    public int KeyTable { get; set; }

    public int Flags { get; set; }

    /// <summary>
    /// Разрешения, необходимые к документу, чтобы иметь возможность произвести выгрузку.
    /// </summary>
    public int Origin { get; set; }

    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual ICollection<DocNoteTableDumpField> DocNoteTableDumpFields { get; set; } = new List<DocNoteTableDumpField>();

    public virtual DocNoteTable KeyNoteTableNavigation { get; set; } = null!;
}
