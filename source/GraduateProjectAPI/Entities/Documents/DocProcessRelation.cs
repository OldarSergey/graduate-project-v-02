using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocProcessRelation
{
    public int KeyProcessRelation { get; set; }

    /// <summary>
    /// Инстанция
    /// </summary>
    public int KeyNode { get; set; }

    /// <summary>
    /// Предшественник... Почему NULL ?? если есть связь, значит есть предшественник ведь
    /// </summary>
    public int? KeyParent { get; set; }

    public virtual DocProcessing KeyNodeNavigation { get; set; } = null!;

    public virtual DocProcessing? KeyParentNavigation { get; set; }
}
