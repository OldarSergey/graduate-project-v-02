using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocContragent
{
    public int KeyContragent { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    /// <summary>
    /// Тип контрагента
    /// </summary>
    public int KeyContragentType { get; set; }

    /// <summary>
    /// Субъект (KS)
    /// </summary>
    public int KeySub { get; set; }

    /// <summary>
    /// (Default)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Если задано, в документах вместо информации из субъектов используется эта.
    /// </summary>
    public string? AsContragentView { get; set; }

    public byte[] Version { get; set; } = null!;

    /// <summary>
    /// Универсальное полное представление записи для использования в метаданных
    /// </summary>
    public string? View { get; set; }

    public virtual ICollection<DocContragentAccount> DocContragentAccounts { get; set; } = new List<DocContragentAccount>();

    public virtual DocContragentType KeyContragentTypeNavigation { get; set; } = null!;

    public virtual DocList KeyDocNavigation { get; set; } = null!;

    public virtual SSubject KeySubNavigation { get; set; } = null!;
}
