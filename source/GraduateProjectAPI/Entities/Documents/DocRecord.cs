using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocRecord
{
    public int KeyRecord { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    /// <summary>
    /// Характерная таблица
    /// </summary>
    public int KeyNoteTable { get; set; }

    public int Flags { get; set; }

    /// <summary>
    /// Порядковый номер записи
    /// </summary>
    public string Serial { get; set; } = null!;

    /// <summary>
    /// Поле с ключом данных № 0
    /// </summary>
    public int? I0 { get; set; }

    /// <summary>
    /// Поле с значением данных № 0
    /// </summary>
    public string? S0 { get; set; }

    public int? I1 { get; set; }

    public string? S1 { get; set; }

    public int? I2 { get; set; }

    public string? S2 { get; set; }

    public int? I3 { get; set; }

    public string? S3 { get; set; }

    public int? I4 { get; set; }

    public string? S4 { get; set; }

    /// <summary>
    /// Комментарий к записи характерной таблицы
    /// </summary>
    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual DocList KeyDocNavigation { get; set; } = null!;

    public virtual DocNoteTable KeyNoteTableNavigation { get; set; } = null!;
}
