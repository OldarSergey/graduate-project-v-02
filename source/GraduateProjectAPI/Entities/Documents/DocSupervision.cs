using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocSupervision
{
    public int KeySupervision { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    /// <summary>
    /// Кто взял на контроль
    /// </summary>
    public int KeyUserSupervisor { get; set; }

    public virtual DocList KeyDocNavigation { get; set; } = null!;
}
