using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocNote
{
    public int KeyNote { get; set; }

    /// <summary>
    /// Гриф секретности по умолчанию для документов этого вида
    /// </summary>
    public int KeyPrivacy { get; set; }

    /// <summary>
    /// Форма-реализатор структурированного документа.
    /// </summary>
    public int? KeyForm { get; set; }

    public int Flags { get; set; }

    public int SystemFlags { get; set; }

    /// <summary>
    /// Ограничение сверху для создаваемых документов.
    /// </summary>
    public int Restrictions { get; set; }

    /// <summary>
    /// Количество цифр в порядковом номере документа
    /// </summary>
    public int NumberDigits { get; set; }

    public string Name { get; set; } = null!;

    /// <summary>
    /// Краткое наим. (используется при генерации №док-та)
    /// </summary>
    public string? NameK { get; set; }

    public string? NameE { get; set; }

    /// <summary>
    /// Заголовок для поля &quot;Дата начала&quot; в карточке документов вида.
    /// </summary>
    public string StartCaption { get; set; } = null!;

    /// <summary>
    /// Всплывающая подсказка для поля &quot;Дата начала&quot; в карточке документов вида.
    /// </summary>
    public string StartHint { get; set; } = null!;

    /// <summary>
    /// Заголовок для поля &quot;Дата окончания&quot; в карточке документов вида.
    /// </summary>
    public string? FinishCaption { get; set; }

    /// <summary>
    /// Всплывающая подсказка для поля &quot;Дата окончания&quot; в карточке документов вида.
    /// </summary>
    public string? FinishHint { get; set; }

    /// <summary>
    /// Системное имя вида документа
    /// </summary>
    public string? Sn { get; set; }

    /// <summary>
    /// Наименование компонента TPopupMenu, предоставляющего характерный контекст документов вида
    /// </summary>
    public string? PopupMenu { get; set; }

    /// <summary>
    /// Наименование хранимой процедуры SQL, вызываемой при расчёте разрешений к документу, предоставляемых подсистемой.
    /// </summary>
    public string? OnPermissions { get; set; }

    /// <summary>
    /// Наименование хранимой процедуры SQL, вызываемой при регистрации документа посредством SQL API.
    /// </summary>
    public string? OnInsert { get; set; }

    /// <summary>
    /// Наименование хранимой процедуры SQL, вызываемой при обновлении Doc_List посредством UI.
    /// </summary>
    public string? OnUpdate { get; set; }

    public string? Comment { get; set; }

    /// <summary>
    /// Шаблон
    /// </summary>
    public byte[]? FormDoc { get; set; }

    /// <summary>
    /// Имя файла шаблона
    /// </summary>
    public string? FormDocFileName { get; set; }

    public int KeyNotes { get; set; }

    public string? SysName { get; set; }

    public int? CreatorOwns { get; set; }

    public int? InstanceDefault { get; set; }

    public int? InstanceRequired { get; set; }

    /// <summary>
    /// Ограничения архивного документа
    /// </summary>
    public int? StoredTakes { get; set; }

    public string? NumberMask { get; set; }

    public int? LimitedFlags { get; set; }

    public string? LimitedFunction { get; set; }

    /// <summary>
    /// Форма мастер создания документа
    /// </summary>
    public int? KeyWizard { get; set; }

    /// <summary>
    /// Статус при создании документа
    /// </summary>
    public int? KeyStateNew { get; set; }

    /// <summary>
    /// Статус при запуске документа
    /// </summary>
    public int? KeyStatePlay { get; set; }

    /// <summary>
    /// Статус при остановке документа
    /// </summary>
    public int? KeyStateStop { get; set; }

    /// <summary>
    /// Статус при отклонении документа
    /// </summary>
    public int? KeyStateCancel { get; set; }

    /// <summary>
    /// Статус при сдаче документа в архив
    /// </summary>
    public int? KeyStateArhive { get; set; }

    public virtual ICollection<DocList> DocLists { get; set; } = new List<DocList>();

    public virtual ICollection<DocNoteContragentType> DocNoteContragentTypes { get; set; } = new List<DocNoteContragentType>();

    public virtual ICollection<DocNoteCounter> DocNoteCounters { get; set; } = new List<DocNoteCounter>();

    public virtual ICollection<DocNoteOperation> DocNoteOperations { get; set; } = new List<DocNoteOperation>();

    public virtual ICollection<DocNotePropertyType> DocNotePropertyTypes { get; set; } = new List<DocNotePropertyType>();

    public virtual ICollection<DocNoteRelationType> DocNoteRelationTypes { get; set; } = new List<DocNoteRelationType>();

    public virtual ICollection<DocNoteRole> DocNoteRoles { get; set; } = new List<DocNoteRole>();

    public virtual ICollection<DocNoteTable> DocNoteTables { get; set; } = new List<DocNoteTable>();

    public virtual ICollection<DocOrigin> DocOrigins { get; set; } = new List<DocOrigin>();

    public virtual ICollection<DocPrivatePermission> DocPrivatePermissions { get; set; } = new List<DocPrivatePermission>();

    public virtual ICollection<DocRoute> DocRoutes { get; set; } = new List<DocRoute>();

    public virtual DocPrivacy KeyPrivacyNavigation { get; set; } = null!;
}
