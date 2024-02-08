using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocTemplateRelation
{
    public int KeyProcessRelation { get; set; }

    /// <summary>
    /// Инстанция
    /// </summary>
    public int KeyNode { get; set; }

    /// <summary>
    /// Предшественник
    /// </summary>
    public int? KeyParent { get; set; }

    public virtual DocProcessTemplate KeyNodeNavigation { get; set; } = null!;

    public virtual DocProcessTemplate? KeyParentNavigation { get; set; }
}
