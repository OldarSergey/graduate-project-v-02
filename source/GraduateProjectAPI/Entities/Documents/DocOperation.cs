using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocOperation
{
    public int KeyOperation { get; set; }

    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Наименование операции
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Автокомментарий при выполнении действия
    /// </summary>
    public string? CommentOnConfirm { get; set; }

    /// <summary>
    /// Автокомментарий при отклонении действия
    /// </summary>
    public string? CommentOnDecline { get; set; }

    public string? Sn { get; set; }

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    public string? SysName { get; set; }

    /// <summary>
    /// Наименование операции в отчёте
    /// </summary>
    public string? ReportName { get; set; }

    public virtual ICollection<DocNoteOperation> DocNoteOperations { get; set; } = new List<DocNoteOperation>();

    public virtual ICollection<DocProcessTemplate> DocProcessTemplates { get; set; } = new List<DocProcessTemplate>();

    public virtual ICollection<DocProcessing> DocProcessings { get; set; } = new List<DocProcessing>();

    public virtual ICollection<DocVersionProcessing> DocVersionProcessings { get; set; } = new List<DocVersionProcessing>();
}
