using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocSelection
{
    public int KeySelection { get; set; }

    /// <summary>
    /// Подборка
    /// </summary>
    public int KeyPrivateSelection { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    public int Flags { get; set; }

    public virtual DocList KeyDocNavigation { get; set; } = null!;

    public virtual DocPrivateSelection KeyPrivateSelectionNavigation { get; set; } = null!;
}
