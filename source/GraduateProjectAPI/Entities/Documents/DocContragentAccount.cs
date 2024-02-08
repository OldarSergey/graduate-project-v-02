using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocContragentAccount
{
    public int KeyContragentAccount { get; set; }

    /// <summary>
    /// Контрагент документа
    /// </summary>
    public int KeyContragent { get; set; }

    /// <summary>
    /// Счет контрагента
    /// </summary>
    public int KeyAccount { get; set; }

    /// <summary>
    /// (Default)
    /// </summary>
    public int Flags { get; set; }

    public byte[] Version { get; set; } = null!;

    public virtual DocContragent KeyContragentNavigation { get; set; } = null!;
}
