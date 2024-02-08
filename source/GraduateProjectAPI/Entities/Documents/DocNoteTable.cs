using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteTable
{
    public int KeyNoteTable { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Оригинальное разрешение к документу, необходимое для редактирования табличных данных.
    /// </summary>
    public int Origin { get; set; }

    /// <summary>
    /// Индекс ассоциируемой картинки
    /// </summary>
    public int? ImageIndex { get; set; }

    /// <summary>
    /// Наименование характерной таблицы
    /// </summary>
    public string Name { get; set; } = null!;

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual ICollection<DocNoteTableDump> DocNoteTableDumps { get; set; } = new List<DocNoteTableDump>();

    public virtual ICollection<DocNoteTableField> DocNoteTableFields { get; set; } = new List<DocNoteTableField>();

    public virtual ICollection<DocRecord> DocRecords { get; set; } = new List<DocRecord>();

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;
}
