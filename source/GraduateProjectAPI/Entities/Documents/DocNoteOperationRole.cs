using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteOperationRole
{
    public int KeyNoteOperationRole { get; set; }

    /// <summary>
    /// Действие
    /// </summary>
    public int KeyNoteOperation { get; set; }

    /// <summary>
    /// Роль, позволяющая Flags
    /// </summary>
    public int KeyRole { get; set; }

    /// <summary>
    /// Confirming, Declining
    /// </summary>
    public int Flags { get; set; }

    public int ConfigFlags { get; set; }

    public string? Comment { get; set; }

    public virtual DocNoteOperation KeyNoteOperationNavigation { get; set; } = null!;
}
