using System;
using System.Collections.Generic;

namespace GraduateProjectAPI.Entities.Documents;

/// <summary>
/// Содержит список и значения свойств документа, характерных для вида документа
/// </summary>
public partial class DocProperty
{
    public int KeyProperty { get; set; }

    /// <summary>
    /// Документ
    /// </summary>
    public int KeyDoc { get; set; }

    /// <summary>
    /// Свойство
    /// </summary>
    public int KeyPropertyType { get; set; }

    /// <summary>
    /// Ключ значения свойства
    /// </summary>
    public int? KeyValue { get; set; }

    /// <summary>
    /// Значение свойства
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// Вычисляемое поле. Собирает представление записи.
    /// </summary>
    public string? View { get; set; }

    public virtual DocList KeyDocNavigation { get; set; } = null!;

    public virtual DocPropertyType KeyPropertyTypeNavigation { get; set; } = null!;
}
