using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocVersionProcessing
{
    public int KeyVersionProcessing { get; set; }

    /// <summary>
    /// Версия
    /// </summary>
    public int KeyVersion { get; set; }

    /// <summary>
    /// Действие
    /// </summary>
    public int KeyOperation { get; set; }

    /// <summary>
    /// Исполнитель
    /// </summary>
    public int KeyUserExecutor { get; set; }

    /// <summary>
    /// Когда исполнитель начал работу. Определяется по дате просмотра документа.
    /// </summary>
    public DateTime? Started { get; set; }

    /// <summary>
    /// Дата выполнения действия
    /// </summary>
    public DateTime? Executed { get; set; }

    /// <summary>
    /// Комментарий исполнителя действия
    /// </summary>
    public string? CommentExecutor { get; set; }

    public virtual DocOperation KeyOperationNavigation { get; set; } = null!;

    public virtual DocVersion KeyVersionNavigation { get; set; } = null!;
}
