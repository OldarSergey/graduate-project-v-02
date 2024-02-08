using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocImage
{
    /// <summary>
    /// PK
    /// </summary>
    public int KeyImage { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    /// <summary>
    /// Файл вложения
    /// </summary>
    public byte[]? Image { get; set; }

    /// <summary>
    /// Имя файла
    /// </summary>
    public string? FileName { get; set; }

    /// <summary>
    /// Время, когда файл был взят на редактирование
    /// </summary>
    public DateTime? CheckOuted { get; set; }

    /// <summary>
    /// Кто взял файл на редактирование
    /// </summary>
    public int? KeyCheckOuter { get; set; }

    /// <summary>
    /// (Application)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Порядковый номер
    /// </summary>
    public string? Serial { get; set; }

    /// <summary>
    /// Наименование вложения
    /// </summary>
    public string? Name { get; set; }

    public byte[] Version { get; set; } = null!;

    public string? Comment { get; set; }

    public int OriginalSize { get; set; }

    public int? KeyArchive { get; set; }

    public string? VersionArchive { get; set; }

    public string? Md5sum { get; set; }

    public int? KeyAttachmentType { get; set; }

    public string? FileExtension { get; set; }

    public long? FileSize { get; set; }

    public virtual DocList KeyDocNavigation { get; set; } = null!;
}
