using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocRelation
{
    public int KeyRelation { get; set; }

    /// <summary>
    /// Предшествующий (базовый) документ
    /// </summary>
    public int KeyObject { get; set; }

    /// <summary>
    /// Последующий документ
    /// </summary>
    public int KeySubject { get; set; }

    /// <summary>
    /// Тип отношения
    /// </summary>
    public int KeyRelationType { get; set; }

    public int Flags { get; set; }

    public string? Comment { get; set; }

    public virtual DocList KeyObjectNavigation { get; set; } = null!;

    public virtual DocRelationType KeyRelationTypeNavigation { get; set; } = null!;

    public virtual DocList KeySubjectNavigation { get; set; } = null!;
}
