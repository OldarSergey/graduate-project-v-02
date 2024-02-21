using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocProcessing
{
    public int KeyProcessing { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    /// <summary>
    /// Операция
    /// </summary>
    public int? KeyOperation { get; set; }

    /// <summary>
    /// Отправитель (KSM) - кто указал действие
    /// </summary>
    public int KeyUserSender { get; set; }

    /// <summary>
    /// Исполнитель
    /// </summary>
    public int KeyUserExecutor { get; set; }

    /// <summary>
    /// (Ownership, FixedOperation, FixedPermissions, FixedExecutor)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Разрешения для инстанции
    /// </summary>
    public int Permissions { get; set; }

    /// <summary>
    /// Когда исполнитель начал работу. Определяется по дате просмотра документа.
    /// </summary>
    public DateTime? Started { get; set; }

    /// <summary>
    /// Дата выполнения действия
    /// </summary>
    public DateTime? Executed { get; set; }

    /// <summary>
    /// Дата контроля выполнения работы, инициализируется UserSender&apos;ом
    /// </summary>
    public DateTime? Controlled { get; set; }

    /// <summary>
    /// Комментарий отправителя
    /// </summary>
    public string? CommentSender { get; set; }

    /// <summary>
    /// Комментарий исполнителя действия
    /// </summary>
    public string? CommentExecutor { get; set; }

    /// <summary>
    /// Контрольная сумма всей важной* информации документа на момент выполнения действия по алгоритму MD5. Для разных видов документов считается посвоему. Выдержка из справки: BINARY_CHECKSUM(*) will return a different value for most, but not all, changes to the row, and can be used to detect most row modifications.
    /// </summary>
    public string? CheckSum { get; set; }

    /// <summary>
    /// Вычисляемое поле. Собирает представление записи.
    /// </summary>
    public string? View { get; set; }

    public DateTime? Created { get; set; }

    /// <summary>
    /// Дата когда до инстанции дошла очередь
    /// </summary>
    public DateTime? Received { get; set; }

    public DateTime? Limited { get; set; }

    public int? LimitedDays { get; set; }

    public string? StateDone { get; set; }

    public string? StateCancel { get; set; }

    public virtual ICollection<DocProcessRelation> DocProcessRelationKeyNodeNavigations { get; set; } = new List<DocProcessRelation>();

    public virtual ICollection<DocProcessRelation> DocProcessRelationKeyParentNavigations { get; set; } = new List<DocProcessRelation>();

    public virtual DocList KeyDocNavigation { get; set; } = null!;

    public virtual DocOperation? KeyOperationNavigation { get; set; }

    public virtual SSubject KeyUserExecutorNavigation { get; set; } = null!;

    public virtual SSubject KeyUserSenderNavigation { get; set; } = null!;
}
