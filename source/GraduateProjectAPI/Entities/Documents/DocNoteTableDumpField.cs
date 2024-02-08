using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteTableDumpField
{
    public int KeyNoteTableDumpField { get; set; }

    public int KeyNoteTableDump { get; set; }

    /// <summary>
    /// Поле из конечной таблицы, в котрое будут записаны данные
    /// </summary>
    public int KeyDestinationField { get; set; }

    /// <summary>
    /// Поле характерной таблицы, из которого будут взяты данные для перекачки в конечную таблицу. Имеет приоритет перед DefValue.
    /// </summary>
    public int? KeySourceField { get; set; }

    /// <summary>
    /// Характерное свойство документа-источник
    /// </summary>
    public int? KeySourceProperty { get; set; }

    /// <summary>
    /// (DefIfNull)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Ключ значения по умолчанию
    /// </summary>
    public int? KeyDefValue { get; set; }

    /// <summary>
    /// Текст значения по умолчанию
    /// </summary>
    public string? DefValue { get; set; }

    public string? Comment { get; set; }

    public virtual DocNoteTableDump KeyNoteTableDumpNavigation { get; set; } = null!;

    public virtual DocNoteTableField? KeySourceFieldNavigation { get; set; }

    public virtual DocNotePropertyType? KeySourcePropertyNavigation { get; set; }
}
