using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocProcessTemplate
{
    public int KeyProcessTemplate { get; set; }

    /// <summary>
    /// Маршрут
    /// </summary>
    public int KeyRoute { get; set; }

    /// <summary>
    /// Исполнитель (KSM), если не указывать, при использовании будет подставляться авторизованный пользователь.
    /// </summary>
    public int? KeyUserExecutor { get; set; }

    /// <summary>
    /// Операция
    /// </summary>
    public int? KeyOperation { get; set; }

    /// <summary>
    /// Флаг определяющий возможность изменения инстанции во время движения (исполнитель, операция, доступ)
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Порядковый номер, предназначен для сортировки, если шаблон маршрута используется как шаблон для печати
    /// </summary>
    public int Serial { get; set; }

    public string? CommentSender { get; set; }

    /// <summary>
    /// Разрешения инстанции
    /// </summary>
    public int Permissions { get; set; }

    public string? StateDone { get; set; }

    public string? StateCancel { get; set; }

    /// <summary>
    /// Исполнитель - макрос
    /// </summary>
    public string? ExecutorSysName { get; set; }

    public virtual ICollection<DocTemplateRelation> DocTemplateRelationKeyNodeNavigations { get; set; } = new List<DocTemplateRelation>();

    public virtual ICollection<DocTemplateRelation> DocTemplateRelationKeyParentNavigations { get; set; } = new List<DocTemplateRelation>();

    public virtual DocOperation? KeyOperationNavigation { get; set; }

    public virtual DocRoute KeyRouteNavigation { get; set; } = null!;
}
