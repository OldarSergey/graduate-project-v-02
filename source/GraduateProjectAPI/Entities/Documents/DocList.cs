using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocList
{
    public int KeyDoc { get; set; }

    /// <summary>
    /// иерархия
    /// </summary>
    public int? KeyParent { get; set; }

    /// <summary>
    /// Вид документа
    /// </summary>
    public int KeyNote { get; set; }

    /// <summary>
    /// Создатель (KSM)
    /// </summary>
    public int KeyUsers { get; set; }

    /// <summary>
    /// Гриф секретности
    /// </summary>
    public int KeyPrivacy { get; set; }

    /// <summary>
    /// Набор бинарных флагов. Младшие два байта зарезервированы документооборотом, старшие два байта предоставлены подсистемам.
    /// </summary>
    public int Flags { get; set; }

    /// <summary>
    /// Ограничения сверху
    /// </summary>
    public int Restrictions { get; set; }

    /// <summary>
    /// Дата регистрации в ИСУП
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Фактическая дата документа (по умолчанию = Created).
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Дата окончания действия документа
    /// </summary>
    public DateTime? Finished { get; set; }

    /// <summary>
    /// Внутренний рег.№
    /// </summary>
    public string RegNumDoc { get; set; } = null!;

    public string? Comment { get; set; }

    public byte[] Version { get; set; } = null!;

    /// <summary>
    /// ... НЕ ПОДДЕРЖИВАЕТСЯ... ??
    /// </summary>
    public int? NumDoc { get; set; }

    /// <summary>
    /// ... НЕ ПОДДЕРЖИВАЕТСЯ... ??
    /// </summary>
    public int? KeySub { get; set; }

    public int KeyNotes { get; set; }

    /// <summary>
    /// Вычисляемое поле. Собирает представление записи.
    /// </summary>
    public string? View { get; set; }

    public string Number { get; set; } = null!;

    /// <summary>
    /// Состояние документа
    /// </summary>
    public int? KeyState { get; set; }

    public virtual ICollection<DocContragent> DocContragents { get; set; } = new List<DocContragent>();

    public virtual ICollection<DocImage> DocImages { get; set; } = new List<DocImage>();

    public virtual ICollection<DocPrivatePermission> DocPrivatePermissions { get; set; } = new List<DocPrivatePermission>();

    public virtual ICollection<DocProcessing> DocProcessings { get; set; } = new List<DocProcessing>();

    public virtual ICollection<DocProperty> DocProperties { get; set; } = new List<DocProperty>();

    public virtual ICollection<DocRecord> DocRecords { get; set; } = new List<DocRecord>();

    public virtual ICollection<DocRelation> DocRelationKeyObjectNavigations { get; set; } = new List<DocRelation>();

    public virtual ICollection<DocRelation> DocRelationKeySubjectNavigations { get; set; } = new List<DocRelation>();

    public virtual ICollection<DocSelection> DocSelections { get; set; } = new List<DocSelection>();

    public virtual ICollection<DocSupervision> DocSupervisions { get; set; } = new List<DocSupervision>();

    public virtual ICollection<DocVersion> DocVersionKeyBasisNavigations { get; set; } = new List<DocVersion>();

    public virtual ICollection<DocVersion> DocVersionKeyDocNavigations { get; set; } = new List<DocVersion>();

    public virtual ICollection<DocList> InverseKeyParentNavigation { get; set; } = new List<DocList>();

    public virtual DocNote KeyNoteNavigation { get; set; } = null!;

    public virtual DocList? KeyParentNavigation { get; set; }

    public virtual DocPrivacy KeyPrivacyNavigation { get; set; } = null!;
}
