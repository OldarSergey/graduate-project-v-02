using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

public partial class DocPrivateListSearch
{
    public int KeyPrivateList { get; set; }

    /// <summary>
    /// Владелец значения (KSM)
    /// </summary>
    public int KeyUserOwner { get; set; }

    /// <summary>
    /// Свойство документа
    /// </summary>
    public int KeyPropertyType { get; set; }

    /// <summary>
    /// Key значения
    /// </summary>
    public int? KeyValue { get; set; }

    /// <summary>
    /// Значение свойства
    /// </summary>
    public string? Value { get; set; }

    public virtual DocPropertyType KeyPropertyTypeNavigation { get; set; } = null!;

    public virtual SSubject KeyUserOwnerNavigation { get; set; } = null!;
}
