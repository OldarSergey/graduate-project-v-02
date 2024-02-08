using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNoteOperation
{
    public int KeyNoteOperation { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Действие
    /// </summary>
    public int KeyOperation { get; set; }

    /// <summary>
    /// (CommentRequired, Controlled, Required, SelectionAllowed, Unique)
    /// </summary>
    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Разрешения по умолчанию
    /// </summary>
    public int Permissions { get; set; }

    /// <summary>
    /// Накладываемые ограничения
    /// </summary>
    public int Restrictions { get; set; }

    public string? CommentOnConfirm { get; set; }

    public string? CommentOnDecline { get; set; }

    /// <summary>
    /// Наименование функции, с помощью котрой будет расчитываться контрольная сумма по документу при выполнении этого действия.
    /// </summary>
    public string? OnChecksum { get; set; }

    /// <summary>
    /// Наименование хранимой процедуры SQL, вызываемой при выполнении действия посредством SQL API.
    /// </summary>
    public string? OnConfirm { get; set; }

    /// <summary>
    /// Наименование хранимой процедуры SQL, вызываемой при отклонении действия посредством SQL API.
    /// </summary>
    public string? OnDecline { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public int KeyNotes { get; set; }

    public string? ChecksumFn { get; set; }

    public int? MaxDelay { get; set; }

    public int DelayFlags { get; set; }

    public string? DelayProcedure { get; set; }

    public virtual ICollection<DocNoteOperationRole> DocNoteOperationRoles { get; set; } = new List<DocNoteOperationRole>();

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;

    public virtual DocOperation KeyOperationNavigation { get; set; } = null!;
}
