using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class SSubject
{
    public int KeySub { get; set; }

    /// <summary>
    /// Группа
    /// </summary>
    public int? KeySubMaster { get; set; }

    /// <summary>
    /// Класс
    /// </summary>
    public int KeyClass { get; set; }

    /// <summary>
    /// Deleted
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Дата начала актуальности версии
    /// </summary>
    public DateTime Date { get; set; }

    public string Name { get; set; } = null!;

    public string NameK { get; set; } = null!;

    /// <summary>
    /// Код
    /// </summary>
    public string Code { get; set; } = null!;

    public string? Comment { get; set; }

    public int? KeySubActual { get; set; }

    public string? NameActual { get; set; }

    public string? ShortNameActual { get; set; }

    /// <summary>
    /// Универсальное полное представление записи для использования в метаданных
    /// </summary>
    public string? View { get; set; }

    /// <summary>
    /// ИЗБАВИТЬСЯ...Логическое удаление
    /// </summary>
    public byte PDel { get; set; }

    public string CodSub { get; set; } = null!;

    public string? CodeActual { get; set; }

    /// <summary>
    /// Если задано, вместо сбора представления из формализованной инфы используется это
    /// </summary>
    public string? AsContragentView { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Дата создания записи
    /// </summary>
    public DateTime? DateCreate { get; set; }

    public virtual ICollection<DocContragent> DocContragents { get; set; } = new List<DocContragent>();

    public virtual ICollection<DocList> DocLists { get; set; } = new List<DocList>();

    public virtual ICollection<DocNoteCounter> DocNoteCounters { get; set; } = new List<DocNoteCounter>();

    public virtual ICollection<DocPrivateListSearch> DocPrivateListSearches { get; set; } = new List<DocPrivateListSearch>();

    public virtual ICollection<DocPrivatePermission> DocPrivatePermissionKeyUserOwnerNavigations { get; set; } = new List<DocPrivatePermission>();

    public virtual ICollection<DocPrivatePermission> DocPrivatePermissionKeyUserPermitedNavigations { get; set; } = new List<DocPrivatePermission>();

    public virtual ICollection<DocPrivateSelection> DocPrivateSelections { get; set; } = new List<DocPrivateSelection>();

    public virtual ICollection<DocProcessTemplate> DocProcessTemplates { get; set; } = new List<DocProcessTemplate>();

    public virtual ICollection<DocProcessing> DocProcessingKeyUserExecutorNavigations { get; set; } = new List<DocProcessing>();

    public virtual ICollection<DocProcessing> DocProcessingKeyUserSenderNavigations { get; set; } = new List<DocProcessing>();

    public virtual ICollection<DocRoute> DocRoutes { get; set; } = new List<DocRoute>();

    public virtual ICollection<DocSupervision> DocSupervisions { get; set; } = new List<DocSupervision>();

    public virtual ICollection<DocVersionProcessing> DocVersionProcessings { get; set; } = new List<DocVersionProcessing>();

    public virtual ICollection<SSubject> InverseKeySubActualNavigation { get; set; } = new List<SSubject>();

    public virtual ICollection<SSubject> InverseKeySubMasterNavigation { get; set; } = new List<SSubject>();

    public virtual SSubject? KeySubActualNavigation { get; set; }

    public virtual SSubject? KeySubMasterNavigation { get; set; }
}
