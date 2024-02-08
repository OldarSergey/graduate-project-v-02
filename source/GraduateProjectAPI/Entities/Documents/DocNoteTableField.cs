using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteTableField
{
    public int KeyNoteTableField { get; set; }

    /// <summary>
    /// Вид характерной таблицы
    /// </summary>
    public int KeyNoteTable { get; set; }

    /// <summary>
    /// Поле таблицы Doc_Tables, в котором будет храниться ключ данных.
    /// </summary>
    public int? KeyField { get; set; }

    /// <summary>
    /// Поле таблицы Doc_Tables, в котором будет храниться значение данных.
    /// </summary>
    public int KeyValueField { get; set; }

    /// <summary>
    /// Класс данных, хранимых в поле
    /// </summary>
    public int? KeyDataClass { get; set; }

    /// <summary>
    /// (Copied)
    /// </summary>
    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Порядок отображения в таблице (по умолчанию)
    /// </summary>
    public int DisplayOrder { get; set; }

    public int Width { get; set; }

    /// <summary>
    /// Заголовок столбца в таблице (по-русски)
    /// </summary>
    public string Caption { get; set; } = null!;

    /// <summary>
    /// Всплывающая подсказка для заголовка столбца
    /// </summary>
    public string? Hint { get; set; }

    /// <summary>
    /// Ключ значения по умолчанию для этого поля
    /// </summary>
    public int? KeyDefValue { get; set; }

    /// <summary>
    /// Текст значения по умолчанию для этого поля
    /// </summary>
    public string? DefValue { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual ICollection<DocNoteTableDumpField> DocNoteTableDumpFields { get; set; } = new List<DocNoteTableDumpField>();

    public virtual DocNoteTable KeyNoteTableNavigation { get; set; } = null!;
}
