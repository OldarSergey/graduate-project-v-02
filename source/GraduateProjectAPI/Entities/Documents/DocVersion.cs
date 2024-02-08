using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocVersion
{
    /// <summary>
    /// Версия.
    /// </summary>
    public int KeyVersion { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    /// <summary>
    /// Документ-основание, инициировавший создание версии
    /// </summary>
    public int? KeyBasis { get; set; }

    public int Flags { get; set; }

    /// <summary>
    /// Дата начала актуальности версии
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Автоинкрементный номер версии
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    /// Примечание.
    /// </summary>
    public string? Comment { get; set; }

    public virtual ICollection<DocVersionProcessing> DocVersionProcessings { get; set; } = new List<DocVersionProcessing>();

    public virtual DocList? KeyBasisNavigation { get; set; }

    public virtual DocList KeyDocNavigation { get; set; } = null!;
}
