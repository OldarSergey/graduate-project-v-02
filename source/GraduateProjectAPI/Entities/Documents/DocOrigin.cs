using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocOrigin
{
    public int KeyOrigin { get; set; }

    /// <summary>
    /// Вид документа (если Null - для всех видов)
    /// </summary>
    public int? KeyNote { get; set; }

    /// <summary>
    /// Оригинальный флаг
    /// </summary>
    public int Origin { get; set; }

    /// <summary>
    /// Что разрешает оригинальный флаг
    /// </summary>
    public string? Permits { get; set; }

    /// <summary>
    /// (CreatorOwns, Restrictable, DelegateAllowed, DelegateRestricted, DelegateNecessary, DelegateOptional, etc.)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Базовое системное разрешение (только для дополнительных разрешений)
    /// </summary>
    public int Basis { get; set; }

    public int? KeyNotes { get; set; }

    public virtual DocNote? KeyNoteNavigation { get; set; }
}
