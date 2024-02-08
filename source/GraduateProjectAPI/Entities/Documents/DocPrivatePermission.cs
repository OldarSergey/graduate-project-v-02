using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocPrivatePermission
{
    public int KeyPrivatePermission { get; set; }

    /// <summary>
    /// Кто разрешил (KSM)
    /// </summary>
    public int KeyUserOwner { get; set; }

    /// <summary>
    /// Кому разрешил ( KSM)
    /// </summary>
    public int KeyUserPermited { get; set; }

    /// <summary>
    /// На какой вид документа. NULL - на все виды документов.
    /// </summary>
    public int? KeyNotes { get; set; }

    /// <summary>
    /// Ссылка на документ-основание для делегирования разрешений
    /// </summary>
    public int? KeyBase { get; set; }

    /// <summary>
    /// Что разрешил
    /// </summary>
    public int Permissions { get; set; }

    /// <summary>
    /// (Substitution)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Время начала действия делегирования
    /// </summary>
    public DateTime? Start { get; set; }

    /// <summary>
    /// Время окончания действия делегирования
    /// </summary>
    public DateTime? Finish { get; set; }

    public int? KeyNote { get; set; }

    public virtual DocList? KeyBaseNavigation { get; set; }

    public virtual DocNote? KeyNotesNavigation { get; set; }
}
